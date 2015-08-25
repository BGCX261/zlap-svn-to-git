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

using framework.list.bean;
using facade.list;
public partial class block_AddNewProductToCart : System.Web.UI.UserControl
{
    public ProInCart proIncart = new ProInCart();
    public ManagerProcart ManagerCart = new ManagerProcart();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ProductInCart"] != null)
            {
                ManagerCart = (ManagerProcart)Session["ProductInCart"];
            }
            try
            {
                string id = Request.QueryString["id"].ToString();
                string type = Request.QueryString["type"].ToString();
                if (type.Equals("1") || type.Equals("3") || type.Equals("4"))
                {
                    if (id.Length > 0)
                    {
                        ProductSystem Product = new ProductSystem();
                        DataSet ds = Product.ProductToCart(id,"");
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                proIncart.type = int.Parse(type);
                                proIncart.name = ds.Tables[0].Rows[0]["Name"].ToString() + " " + ds.Tables[0].Rows[0]["state"].ToString();
                                proIncart.urlImage = ds.Tables[0].Rows[0]["UrlImage"].ToString();
                                string strPrice = ds.Tables[0].Rows[0]["SellingPrice"].ToString();
                                if (strPrice.Length > 0)
                                {
                                    proIncart.price = float.Parse(strPrice);
                                }
                                string strwarranty = ds.Tables[0].Rows[0]["WarrantyMonth"].ToString();
                                if (strwarranty.Length > 0)
                                {
                                    proIncart.warranty = int.Parse(strwarranty);
                                }
                                proIncart.id = int.Parse(id);
                                proIncart.number = 1;
                                proIncart.currency = ds.Tables[0].Rows[0]["currency"].ToString();
                                proIncart.rate = float.Parse(ds.Tables[0].Rows[0]["rate"].ToString());
                                proIncart.setTotal();
                                ManagerCart.AddNewPro(proIncart);
                                Session["ProductInCart"] = ManagerCart;
                            }
                        }
                    }
                }
                else if(type.Equals("2"))
                { 
                    //add component:
                    ComponentProductSystem Compoent = new ComponentProductSystem();
                    DataSet ds = Compoent.ComponenttoCart(id, Application["idtypeproduct"].ToString());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            proIncart.type = 2;
                            proIncart.name = ds.Tables[0].Rows[0]["Name"].ToString();
                            proIncart.urlImage = ds.Tables[0].Rows[0]["UrlImage"].ToString();
                            string strPrice = ds.Tables[0].Rows[0]["SellingPrice"].ToString();
                            if (strPrice.Length > 0)
                            {
                                proIncart.price = float.Parse(strPrice);
                            }
                            string strwarranty = ds.Tables[0].Rows[0]["WarrantyMonth"].ToString();
                            if (strwarranty.Length > 0)
                            {
                                proIncart.warranty = int.Parse(strwarranty);
                            }
                            proIncart.id = int.Parse(id);
                            proIncart.number = 1;
                            proIncart.currency = ds.Tables[0].Rows[0]["currency"].ToString();
                            proIncart.rate = float.Parse(ds.Tables[0].Rows[0]["rate"].ToString());
                            proIncart.setTotal();
                            ManagerCart.AddNewPro(proIncart);
                            Session["ProductInCart"] = ManagerCart;
                        }
                    }
                }
                else if (type.Equals("11") || type.Equals("13") || type.Equals("14"))
                {
                    //delete product:
                    if (id.Length > 0)
                    {
                        proIncart.id = int.Parse(id);
                        if (type.Equals("11"))
                        {
                            proIncart.type = 1;
                        }
                        else if(type.Equals("13"))
                        {
                            proIncart.type = 3;
                        }
                        else if (type.Equals("14"))
                        {
                            proIncart.type = 4;
                        }
                        ManagerCart.DeletePro(proIncart);
                        Session["ProductInCart"] = ManagerCart;
                    }
                }
                else if (type.Equals("12"))
                {
                    //delete com:
                    if (id.Length > 0)
                    {
                        proIncart.id = int.Parse(id);
                        proIncart.type = 2;
                        ManagerCart.DeletePro(proIncart);
                        Session["ProductInCart"] = ManagerCart;
                    }
                }
            }
            catch
            {

            }
        }
        Response.Redirect("Default.aspx?menu=shoppingcart");
    }
}