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

using System.Xml;
using facade.list;
public partial class block_AdvanceSearch : System.Web.UI.UserControl
{
    public string tCurrentAccess = "";
    public string tbl_search = "";
    private string tsearch = "";
    private string tPrice = "";
    private string tBrand = "";
    private string tCpu = "";
    private string tHdd = "";
    private string tRam = "";
    private string tScreen = "";
    public string str_search = "";
    private string thome = "";
    private string tpro = "";
    private string tcolor = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Hashtable hash = (Hashtable)Application[Session["langcurrent"].ToString()];
            tsearch = hash["tsearch"].ToString();
            tPrice = hash["slprice"].ToString();
            tBrand = hash["slbrand"].ToString();
            tCpu = hash["slcpu"].ToString();
            tScreen = hash["slscreen"].ToString();
            tHdd = hash["slhdd"].ToString();
            tRam = hash["slram"].ToString();
            tcolor = hash["tcolor"].ToString();
            tbl_search = hash["avsearch"].ToString();
            tCurrentAccess = hash["currentpage"].ToString();
            thome = hash["home"].ToString();
            tpro = hash["product"].ToString();
            tCurrentAccess += ": <a href='?menu=home'>" + thome + "</a> &raquo; <a href='?menu=product'>" + tpro + "</a> &raquo;" + tsearch;
        }
        catch
        { }
        BuildPageSearch();
    }
    public void BuildPageSearch()
    {
        string[] values = GetValueSearch();
        str_search = "<table cellpadding='0' cellspacing='0' border='0' width='400' align='center'>";
        str_search += " <tr><td height='10'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[1] + "</td><td>" + values[3] + "</td></tr>";
        str_search += " <tr><td height='10'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[0] + "</td><td>" + values[4] + "</td></tr>";
        str_search += " <tr><td height='10'></td><td></td></tr>";
        str_search += "<tr align='center'><td>" + values[2] + "</td><td>" + values[5] + "</td></tr>";
        str_search += " <tr><td height='10'></td><td></td></tr>";
        str_search += "<tr align='center'><td></td><td>" + values[6] + "</td></tr>";
        str_search += " <tr><td height='10'></td><td></td></tr>";
        str_search += "</tr><tr align='center'><td colspan='2'><input type='text' class='text_box1' id='txtadvancesearch' onkeydown=\"OnEnterSend(event,'advancesearch');\" /></td></tr>";
        str_search += "<tr><td height='2'></td><td></td></tr>";
        str_search += "<tr align='center'><td colspan='2' class='text_5'><input type='button' class='button3' onclick=\"advancesearch();\" value='" + tsearch + "' /></td></tr>";
        str_search+="</table>";
    }
    public string[] GetValueSearch()
    {
        string[] values = new string[8] { "", "", "", "", "", "", "", "" };
        string str = "";
        string path = Server.MapPath("data/xml/");
        XmlDocument doc = new XmlDocument();
        int numNode = 0;
        try
        {
            XmlTextReader reader = new XmlTextReader(path + "price.xml");
            //Get Price:
            doc.Load(reader);
            reader.Close();
            XmlNodeList nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            //GetPrice:
            str = "<select class='text_box2' id='slprice'>";
            str += "<option value='0'>"+tPrice +"</option>";
            for (int i = 0; i < numNode; i++)
            {
                string value = nodes[i].ChildNodes[1].InnerText + "," + nodes[i].ChildNodes[2].InnerText;
                str += "<option value='" + value + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[0] = str;
            //Get Brand:
            DataSet ds = new BrandProductSystem().BrandProAllType((int)Application["idtypeproduct"]);
            numNode = ds.Tables[0].Rows.Count;
            str = "<select class='text_box2' id='slbrand'>";
            str += "<option value='0'>" + tBrand + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + ds.Tables[0].Rows[i]["id"].ToString() + "'>" + ds.Tables[0].Rows[i]["name"].ToString() + "</option>";
            }
            str += "</select>";
            values[1] = str;
            //Get Cpu:
            reader = new XmlTextReader(path + "cpusearch.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slcpu'>";
            str += "<option value='0'>" + tCpu + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[2] = str;
            //Get Hdd:
            reader = new XmlTextReader(path + "hddsize.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slhdd'>";
            str += "<option value='0'>" + tHdd + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[3] = str;
            //Get Ram:
            reader = new XmlTextReader(path + "ramsize.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slram'>";
            str += "<option value='0'>" + tRam + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[4] = str;
            //Get Screen Size:
            reader = new XmlTextReader(path + "screensize.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slscreen'>";
            str += "<option value='0'>" + tScreen + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[5] = str;

            //Get Color:
            reader = new XmlTextReader(path + "colorsearch.xml");
            doc.Load(reader);
            reader.Close();
            nodes = doc.SelectNodes("/root/search");
            numNode = nodes.Count;
            str = "<select class='text_box2' id='slcolor'>";
            str += "<option value='0'>" + tcolor + "</option>";
            for (int i = 0; i < numNode; i++)
            {
                str += "<option value='" + nodes[i].ChildNodes[1].InnerText + "'>" + nodes[i].ChildNodes[0].InnerText + "</option>";
            }
            str += "</select>";
            values[6] = str;
        }
        catch
        { 
           
        }
        return values;
    }
}
