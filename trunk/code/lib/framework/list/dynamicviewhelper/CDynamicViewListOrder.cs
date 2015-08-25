using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using facade.list;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewListOrder:CDynamicViewHelper
    {
        private DataSet dsOrder = new DataSet();
        private string iduser = "";
        private string where = "";
        private UserManagerSystem ManageUser = new UserManagerSystem();
        public void SetWhere(string where)
        {
            this.where = where;
        }
        public void SetListOrderAllTop()
        {
            this.dsOrder = new UserManagerSystem().OrderSelectIdUser(iduser);
            SetNumOrder();
        }
        public void SetNumOrder()
        {
            if (this.dsOrder.Tables.Count > 0)
            {
                SetNumberRecord(this.dsOrder.Tables[0].Rows.Count);
            }
        }
        public void SetNumOrderUser()
        {
            this.SetNumberRecord(ManageUser.OrderUserCount(where));
        }
        public string GetOderUserFromTo()
        {
            string strorder = "";
            dsOrder = ManageUser.OrderUserFromTo(where, this.GetFromRow(), this.GetToRow());
            try
            {
                if (dsOrder.Tables.Count > 0)
                {
                    int numorder = dsOrder.Tables[0].Rows.Count;
                    DateTime time = new DateTime();
                    DateTime timenow = new DateTime();
                    timenow = DateTime.Now;
                    TimeSpan subtime = new TimeSpan();
                    if (numorder > 0)
                    {
                        strorder = "<table border='0' cellpadding='1' cellspacing='0' width='100%'>";
                        strorder += "<tr height='5'><td width='92'></td><td width='75'></td><td width='100'></td><td width='200'></td><td></td></tr>";

                        for (int i = 0; i < numorder; i++)
                        {
                            string idorder = dsOrder.Tables[0].Rows[i]["idorder"].ToString();
                            try
                            {
                                time = (DateTime)dsOrder.Tables[0].Rows[i]["shipdate"];
                                subtime = time - timenow;
                            }
                            catch
                            {

                            }
                            string id = dsOrder.Tables[0].Rows[i]["id"].ToString();
                            if (id.Equals("2") || id.Equals("3"))
                            {
                                strorder += "<tr align='center' bgcolor='#DDFFEE'>";
                            }
                            else if (id.Equals("4") || id.Equals("5"))
                            {
                                strorder += "<tr align='center' bgcolor='#EEEEEE'>";
                            }
                            else
                            {
                                strorder += "<tr align='center'>";
                            }
                            if (id.Equals("6"))
                            {
                                strorder += "<td><a href='?menu=dorder&id=" + idorder + "'>" + dsOrder.Tables[0].Rows[i]["ordernumber"].ToString() + "</a></td>";
                                strorder += "<td>" + time.ToString("dd-MM-yyyy") + "</td>";
                                strorder += "<td>" + dsOrder.Tables[0].Rows[i]["shippingname"].ToString() + "</td>";
                            }
                            else if (subtime.Days >= 0 && subtime.Days <= 3)
                            {
                                strorder += "<td class='text_title'><a href='?menu=dorder&id=" + idorder + "'>" + dsOrder.Tables[0].Rows[i]["ordernumber"].ToString() + "</a></td>";
                                strorder += "<td class='price'>" + time.ToString("dd-MM-yyyy") + "</td>";
                                strorder += "<td class='price'>" + dsOrder.Tables[0].Rows[i]["shippingname"].ToString() + "</td>";
                            }
                            else
                            {
                                strorder += "<td class='text_2'><a href='?menu=dorder&id=" + idorder + "'>" + dsOrder.Tables[0].Rows[i]["ordernumber"].ToString() + "</a></td>";
                                strorder += " <td class='price'>" + time.ToString("dd-MM-yyyy") + "</td>";
                                strorder += "<td class='price'>" + dsOrder.Tables[0].Rows[i]["shippingname"].ToString() + "</td>";
                            }
                            strorder += "<td align='left'>" + dsOrder.Tables[0].Rows[i]["shippingaddress"].ToString() + "</td>";
                            strorder += "<td align='right'>" + dsOrder.Tables[0].Rows[i]["name"].ToString() + "</td></tr>";
                            if (i < numorder - 1)
                            {
                                strorder += "<tr><td colspan='5' class='bg_line3'></td></tr>";
                            }
                        }
                        strorder += " <tr><td colspan='5' height='6'></td></tr>";
                        strorder += "</table>";
                    }
                }
            }
            catch
            { }
            return strorder;
        }
        public void SetIduser(string iduser)
        {
            this.iduser = iduser;
        }
        public string GetOrderFromTo()
        {
            string strorder = "";
            try
            {
                if (dsOrder.Tables.Count > 0)
                {
                    int numorder = dsOrder.Tables[0].Rows.Count;
                    DateTime time = new DateTime();
                    DateTime timenow = new DateTime();
                    timenow = DateTime.Now;
                    TimeSpan subtime = new TimeSpan();
                    if (numorder > 0)
                    {
                        strorder = "<table border='0' cellpadding='1' cellspacing='0' width='100%'>";
                        strorder += "<tr height='5'><td width='92'></td><td width='75'></td><td width='100'></td><td width='200'></td><td></td></tr>";
                        int from = GetFromRow();
                        int to = GetToRow();
                        for (int i = from; i < to; i++)
                        {
                            string idorder = dsOrder.Tables[0].Rows[i]["idorder"].ToString();
                            try
                            {
                                time = (DateTime)dsOrder.Tables[0].Rows[i]["shipdate"];
                                subtime = time - timenow;
                            }
                            catch
                            {
                            
                            }
                            string id=dsOrder.Tables[0].Rows[i]["id"].ToString();
                            if (id.Equals("2") || id.Equals("3"))
                            {
                                strorder += "<tr align='center' bgcolor='#DDFFEE'>";
                            }
                            else if (id.Equals("4") || id.Equals("5"))
                            {
                                strorder += "<tr align='center' bgcolor='#EEEEEE'>";
                            }
                            else
                            {
                                strorder += "<tr align='center'>";
                            }
                            if (id.Equals("6"))
                            {
                                strorder += "<td><a href='?menu=dorder&id=" + idorder + "'>" + dsOrder.Tables[0].Rows[i]["ordernumber"].ToString() + "</a></td>";
                                strorder += " <td>" + time.ToString("dd-MM-yyyy") + "</td>";
                                strorder += "<td>" + dsOrder.Tables[0].Rows[i]["shippingname"].ToString() + "</td>";
                            }else if (subtime.Days>=0 && subtime.Days <= 3)
                            {
                                strorder += "<td class='text_title'><a href='?menu=dorder&id=" + idorder + "'>" + dsOrder.Tables[0].Rows[i]["ordernumber"].ToString() + "</a></td>";
                                strorder += " <td class='price'>" + time.ToString("dd-MM-yyyy") + "</td>";
                                strorder += "<td class='price'>" + dsOrder.Tables[0].Rows[i]["shippingname"].ToString() + "</td>";
                            }
                            else
                            {
                                strorder += "<td class='text_2'><a href='?menu=dorder&id=" + idorder + "'>" + dsOrder.Tables[0].Rows[i]["ordernumber"].ToString() + "</a></td>";
                                strorder += " <td class='price'>" + time.ToString("dd-MM-yyyy") + "</td>";
                                strorder += "<td class='price'>" + dsOrder.Tables[0].Rows[i]["shippingname"].ToString() + "</td>";
                            }
                            strorder += "<td align='left'>" + dsOrder.Tables[0].Rows[i]["shippingaddress"].ToString() + "</td>";
                            strorder += "<td align='right'>" + dsOrder.Tables[0].Rows[i]["name"].ToString() + "</td></tr>";
                            if (i < to - 1)
                            {
                                strorder += " <tr><td colspan='5' class='bg_line3'></td></tr>";
                            }
                        }
                        strorder += " <tr><td colspan='5' height='6'></td></tr>";
                        strorder += "</table>";
                    }
                }
            }
            catch
            { }
            return strorder;
        }
    }
}
