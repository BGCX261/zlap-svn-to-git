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
using Microsoft.Reporting.WebForms;
using framework.list.common;
public partial class block_RptProductPrice : System.Web.UI.UserControl
{
    string[] arrInfor = new string[] { "", "" };
    public string titleBlock = "Báo giá sản phẩm";
    string nameForm = "";
    Hashtable hActive = new Hashtable();
    public string strError = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            nameForm = Request.QueryString["key"].ToString();
            if (!IsPostBack)
            {
                DataSet dsType = new CManageProductSystem().ProductTypeAll("");
                int numType = dsType.Tables[0].Rows.Count;
                for (int i = 0; i < numType; i++)
                {
                    slProductType.Items.Add(new ListItem(dsType.Tables[0].Rows[i]["Name"].ToString(), dsType.Tables[0].Rows[i]["Id"].ToString()));
                }
                //DataSet dsProducts = new DsProductPrice();
                int ProducttypeId = 1;
                if (slProductType.Text.Length > 0)
                {
                    ProducttypeId = int.Parse(slProductType.Text);
                }
                DataSet dsProducts = new CManageProductSystem().ReportProduct(ProducttypeId, 1);
                //Xu ly kho chua hang:
                int NumWH = dsProducts.Tables[1].Rows.Count;
                Hashtable HWareHouse=new Hashtable();
                for (int i = 0; i < NumWH; i++)
                {
                    int idstate = int.Parse(dsProducts.Tables[1].Rows[i]["id"].ToString());
                    string message = "";
                    DateTime time = CTime.GetTimeHaNoi();
                    if (idstate <= 5)
                    {
                        message = "(Đang có hàng)";
                    }
                    else
                    {
                        if (idstate == 6)
                        {
                            time = time.AddHours(24);
                            message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                        }
                        else if (idstate == 7)
                        {
                            time = time.AddHours(24);
                            message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                        }
                        else if (idstate == 8)
                        {
                            time = time.AddHours(48);
                            message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                        }
                        else if (idstate == 9)
                        {
                            if (dsProducts.Tables[1].Rows[i]["DisContinued"].ToString().Equals("7"))
                            {
                                time = (DateTime)dsProducts.Tables[1].Rows[i]["FirstImportDate"];
                                message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                            }
                            else
                            {
                                time = time.AddHours(72);
                                message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                            }
                        }
                        else
                        {
                        }
                    }
                    if (HWareHouse[dsProducts.Tables[1].Rows[i]["ProductId"].ToString()] != null)
                    {
                        HWareHouse[dsProducts.Tables[1].Rows[i]["ProductId"].ToString()] += "* " + dsProducts.Tables[1].Rows[i]["Address"].ToString() + " " + message + "\n";
                    }
                    else
                    {
                        HWareHouse[dsProducts.Tables[1].Rows[i]["ProductId"].ToString()] = "* " + dsProducts.Tables[1].Rows[i]["Address"].ToString() + " " + message + "\n";
                    }
                }
                string strSource = Server.MapPath("report/rptProductPrice.rdlc");
                rptProductPrice.LocalReport.ReportPath = strSource;
                // you need to set this to show multi column output in report viewer
                rptProductPrice.ZoomMode = ZoomMode.Percent;
                rptProductPrice.ZoomPercent = 100;
                int num = dsProducts.Tables[0].Rows.Count;
                for (int i = 0; i < num; i++)
                {
                    string strwh = "";
                    if (HWareHouse[dsProducts.Tables[0].Rows[i]["Id"].ToString()]!=null)
                    {
                        strwh = HWareHouse[dsProducts.Tables[0].Rows[i]["Id"].ToString()].ToString();
                    }
                    dsProducts.Tables[0].Rows[i]["WareHouse"] = strwh;
                    double Price = double.Parse(dsProducts.Tables[0].Rows[i]["SellingPrice2"].ToString());
                    string StrPrice = Price.ToString("N").Split('.')[0];
                    dsProducts.Tables[0].Rows[i]["SellingPrice2"] = StrPrice;
                }
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DsProductPrice_Products";
                rds.Value = dsProducts.Tables[0];
                rptProductPrice.LocalReport.DataSources.Add(rds);
            }
        }
        catch (Exception ex)
        {
            strError = ex.ToString();
        }
    }
    protected void tbReport_click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsProducts = new DsProductPrice();
            int ProducttypeId = 1;
            if (slProductType.Text.Length > 0)
            {
                ProducttypeId = int.Parse(slProductType.Text);
            }
            dsProducts = new CManageProductSystem().ReportProduct(ProducttypeId, 1);
            //Xu ly kho chua hang:
            int NumWH = dsProducts.Tables[1].Rows.Count;
            Hashtable HWareHouse = new Hashtable();
            for (int i = 0; i < NumWH; i++)
            {
                int idstate = int.Parse(dsProducts.Tables[1].Rows[i]["id"].ToString());
                string message = "";
                DateTime time = CTime.GetTimeHaNoi();
                if (idstate <= 5)
                {
                    message = "(Đang có hàng)";
                }
                else
                {
                    if (idstate == 6)
                    {
                        time = time.AddHours(24);
                        message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                    }
                    else if (idstate == 7)
                    {
                        time = time.AddHours(24);
                        message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                    }
                    else if (idstate == 8)
                    {
                        time = time.AddHours(48);
                        message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                    }
                    else if (idstate == 9)
                    {
                        if (dsProducts.Tables[1].Rows[i]["DisContinued"].ToString().Equals("7"))
                        {
                            time = (DateTime)dsProducts.Tables[1].Rows[i]["FirstImportDate"];
                            message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                        }
                        else
                        {
                            time = time.AddHours(72);
                            message = "(Sẽ có thêm hàng ngày " + time.ToString("dd/MM") + ")";
                        }
                    }
                    else
                    {
                    }
                }
                if (HWareHouse[dsProducts.Tables[1].Rows[i]["ProductId"].ToString()] != null)
                {
                    HWareHouse[dsProducts.Tables[1].Rows[i]["ProductId"].ToString()] += "* " + dsProducts.Tables[1].Rows[i]["Address"].ToString() + " " + message + "\n";
                }
                else
                {
                    HWareHouse[dsProducts.Tables[1].Rows[i]["ProductId"].ToString()] = "* " + dsProducts.Tables[1].Rows[i]["Address"].ToString() + " " + message + "\n";
                }
            }
            string strSource = Server.MapPath("report/rptProductPrice.rdlc");
            rptProductPrice.LocalReport.ReportPath = strSource;
            rptProductPrice.ZoomMode = ZoomMode.Percent;
            rptProductPrice.ZoomPercent = 100;
            int num = dsProducts.Tables[0].Rows.Count;
            for (int i = 0; i < num; i++)
            {
                string strwh = "";
                if (HWareHouse[dsProducts.Tables[0].Rows[i]["Id"].ToString()] != null)
                {
                    strwh = HWareHouse[dsProducts.Tables[0].Rows[i]["Id"].ToString()].ToString();
                }
                dsProducts.Tables[0].Rows[i]["WareHouse"] = strwh;
                double Price = double.Parse(dsProducts.Tables[0].Rows[i]["SellingPrice2"].ToString());
                string StrPrice = Price.ToString("N").Split('.')[0];
                dsProducts.Tables[0].Rows[i]["SellingPrice2"] = StrPrice;
            }
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DsProductPrice_Products";
            rds.Value = dsProducts.Tables[0];
            rptProductPrice.LocalReport.DataSources.Add(rds);
        }
        catch
        { }
    }
}
