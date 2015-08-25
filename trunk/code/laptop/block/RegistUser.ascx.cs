using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using facade.list;
using framework.list.common;
public partial class block_RegistUser : System.Web.UI.UserControl
{
    public string mtitle = "";
    public string tblregister = "";
    public string merr = "";
    public string mpass = "";
    public string mpasserr = "";
    public string mcode = "";
    public string merruser = "";
    public string muser = "";
    public string memail = "";
    public string merremail = "";
    public string tbregister = "";
    public string tusername = "";
    public string tpass1 = "";
    public string tpass2 = "";
    public string tname = "";
    public string tjob = "";
    public string temail = "";
    public string tmobile = "";
    public string thome = "";
    public string taddress = "";
    public string tcode1 = "";
    public string tcode2 = "";
    public string terrConnect = "";
    string code = "";
    public string tlhome = "";
    public string tCurrentAccess = "";
    CGetDataCommon GetCodeRandom = new CGetDataCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tblregister = hash["blregister"].ToString();
            mtitle = hash["mtregister"].ToString();
            tusername = hash["maccount"].ToString();
            tpass1 = hash["mpass"].ToString();
            tpass2 = hash["mcpass"].ToString();
            tname = hash["mfname"].ToString();
            tjob = hash["mjob"].ToString();
            temail = hash["memail"].ToString();
            tmobile = hash["mmobile"].ToString();
            thome = hash["mhomep"].ToString();
            taddress = hash["maddress"].ToString();
            tcode1 = hash["mcode"].ToString();
            tcode2 = hash["mccode"].ToString();
            tbregister = hash["bsubmit"].ToString();
            merr = hash["merrcommon"].ToString();
            mpass = hash["mpassl"].ToString();
            mpasserr = hash["merrpass"].ToString();
            mcode = hash["merrcode"].ToString();
            merruser = hash["merraccount"].ToString();
            muser = hash["meaccount"].ToString();
            memail = hash["meemail"].ToString();
            merremail = hash["merremail"].ToString();
            terrConnect = hash["merrsql"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            tlhome = hash["home"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + tlhome + "</a> &raquo; " + tblregister;
        }
        catch
        { 
            
        }
        if (!IsPostBack)
        {
            register.Value = tbregister;
            divErrors.Disabled = true;
            code = GetCodeRandom.CreateCodeRanDom(5);
            Session["RamDomCodeRegister"] = code;
        }
    }
    protected void register_Click(object sender, EventArgs e)
    {
        string username = txtusername.Value.Trim();
        string pass1 = txtpass.Value.Trim();
        string pass2 = txtpass1.Value.Trim();
        string fullname = txtname.Value.Trim();
        string jobtitle = txtjobtitle.Value.Trim();
        string email = txtemail.Value.Trim();
        string mobile = txtmobile.Value.Trim();
        string homephone = txthomephone.Value.Trim();
        string address = txtaddress.Value.Trim();
        string code = txtcoderegister.Value.Trim();
        CManageError errors = ValidateForm(username, pass1, pass2, fullname, jobtitle, address, email, mobile, homephone, code);
        if (errors.GetNumberErr() > 0)
        {
            divErrors.Disabled = false;
            divErrors.InnerHtml = "<div class='diverror'>" + errors.GetAllError() + "</div>";
        }
        else
        {
            MD5 md5 = new MD5();
            pass1 = md5.Encrypt(pass1);
            UserManagerSystem managerUser = new UserManagerSystem();
            Boolean test = managerUser.UserInsert(username, pass1, fullname, "", jobtitle, address, "", "", "", address, "", "", "", mobile, "", homephone, "", "", email, "", "");
            if (test)
            {
                DataSet dsUser = managerUser.GetUserAccount(username);
                if (dsUser.Tables.Count > 0)
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        string[] userAcount = new string[3];
                        userAcount[0] = dsUser.Tables[0].Rows[0]["id"].ToString();
                        userAcount[1] = dsUser.Tables[0].Rows[0]["UserName"].ToString();
                        userAcount[2] = dsUser.Tables[0].Rows[0]["ContactName"].ToString();
                        Session["infoUser"] = userAcount;
                        //Send email:

                        Response.Redirect("Default.aspx");
                    }
                }
            }
            else
            {
                divErrors.Disabled = false;
                divErrors.InnerHtml = "<div class='diverror'>" + terrConnect + "</div>";
            }
        }
    }
    public CManageError ValidateForm(string username,string pass1,string pass2,string fullname,string jobtitle,string address,string email,string mobile,string homephone,string code)
    {
        CManageError errors = new CManageError();
        int numErr = 0;
        CValidate validate = new CValidate();
        if (username.Length > 0)
        {
            if (validate.TestUserName(username) > 0)
            {
                numErr++;
                errors.AddError(merruser);
                return errors;
            }
        }
        else
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (pass1.Length > 0)
        {
            if (pass1.Length < 4)
            {
                numErr++;
                errors.AddError(mpass);
                return errors;
            }
        }
        else
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (pass2.Length > 0)
        {
        }
        else
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (fullname.Length == 0)
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (address.Length == 0)
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (email.Length > 0)
        {

        }
        else
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (!pass1.Equals(pass2))
        { 
            numErr++;
            errors.AddError(mpasserr);
            return errors;
        }
        if (code.Length > 0)
        {
            string subcode = Session["RamDomCodeRegister"].ToString();
            if (!subcode.Equals(code))
            {
                numErr++;
                errors.AddError(mcode);
                subcode = GetCodeRandom.CreateCodeRanDom(5);
                Session["RamDomCodeRegister"] = subcode;
                return errors;
            }
        }
        else
        {
            numErr++;
            errors.AddError(merr);
            return errors;
        }
        if (!validate.TestAddressEmail(email))
        { 
            numErr++;
            errors.AddError(merremail);
            return errors;
        }
        //TestExsit Username, or Email:
        DataSet Ds = new UserManagerSystem().UserSelectUsernameandEmail(username, email);
        if (Ds.Tables.Count > 0)
        {
            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (!Ds.Tables[0].Rows[0]["count"].ToString().Equals("0"))
                {
                    numErr++;
                    errors.AddError(muser);
                }
                if (!Ds.Tables[1].Rows[0]["count"].ToString().Equals("0"))
                {
                    numErr++;
                    errors.AddError(memail);
                }
            }
        }
        return errors;
    }
}