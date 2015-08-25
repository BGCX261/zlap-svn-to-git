using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Web;
using framework.list.common;
namespace framework.list.dynamicviewhelper
{
    public class CDynamicviewHelperXmlLanguageContent : CDynamicViewHelper
    {
        XPathNavigator navigator = null;                 
        string StringSearch = "";
        CValidate validate = new CValidate();
        //Get Node in Navigator to Show:
        public ArrayList GetNodeShow(bool Edit)
        {
                       
            string str = "";
            string str_id = "";
            int first = 0;
            int last = 0;
            ArrayList list = new ArrayList();
            str = str + "<table width='100%' border='1' cellpadding='3' cellspacing='0' bordercolor='#91A7B4' style='background: #EFF5FF; border-collapse:collapse'>";
            str = str + " <colgroup> ";
            str = str + " <col width='5%' align='center' /> ";
            str = str + " <col width='5%' align='center' /> ";
            str = str + " <col width='20%' align='center' /> ";
            str = str + " <col width='60%' align='left'  /> ";
            str = str + " <col width='10%' align='center' /> ";
            str = str + " </colgroup>	";
            str = str + "<TR class='titletbl'>";
            str = str + "<TH height='20' align='center'  >Số TT</TH>";
            str = str + "<TH height='20' align='center' ><input type = 'checkbox' id = 'chkAll' onclick=\"OnchoiceAll('chkAll');return true;\"/></TH>";
            str = str + "<TH height='20' align='center' >Từ khoá</TH>";
            str = str + "<TH height='20' align='center' >Nội dung hiển thị</TH>";
            str = str + "<TH height='20' align='center' >Chỉnh sửa</TH>";
            str = str + "</TR>";
            if (navigator != null)
            {
                XPathNodeIterator nodes = navigator.Select(StringSearch);
                if (Edit == true)
                {
                    if (nodes.Count > 0)
                    {
                        int i = 1;
                        //hien thi du lieu the vi tri               
                        while (first != GetFromRow())
                        {
                            nodes.MoveNext();
                            first = first + 1;
                        }
                        //bat dau hien thi du lieu
                        last = this.GetFromRow();
                        int test = this.GetToRow();
                        while (nodes.MoveNext())
                        {
                            if (last == test)
                            {
                                break;
                            }
                            else
                            {
                                last = last + 1;
                                nodes.Current.MoveToFirstChild();
                                str_id = nodes.Current.Value.ToString();
                                str = str + "<tr>";
                                str = str + "<td class='textcenter'>" + (i++) + "</td>";
                                str = str + "<td class='textcenter'><input type='checkbox' id='" + str_id + "' name='CheckGroup' /></td> ";
                                str = str + "<td align='left'>" + nodes.Current.Value.ToString() + "</td>";
                                nodes.Current.MoveToNext();
                                string des = nodes.Current.InnerXml;
                                des = HttpContext.Current.Server.HtmlDecode(des);
                                if (validate.ExistWordLength(30, des))
                                {
                                    des = validate.ConvertString(30, des);
                                }
                                des = HttpContext.Current.Server.HtmlEncode(des);
                                str = str + "<td>" + des + "</td>";
                                //str = str + "<td><a href='" + str_edit + "&id=" + str_id + "'> Edit </a></td>";
                                str = str + "<td class='textcenter'><a id='" + str_id + "' href='#' title=\"" + des + "\" onclick=\"ShowInfor(this);\"> Edit </a></td>";
                                str = str + "</tr>";
                            }
                        }
                    }
                }
                else
                {
                    if (nodes.Count > 0)
                    {
                        int i = 1;
                        //hien thi du lieu the vi tri               
                        while (first != GetFromRow())
                        {
                            nodes.MoveNext();
                            first = first + 1;
                        }
                        //bat dau hien thi du lieu
                        last = this.GetFromRow();
                        int test = this.GetToRow();
                        while (nodes.MoveNext())
                        {
                            if (last == test)
                            {
                                break;
                            }
                            else
                            {
                                last = last + 1;
                                nodes.Current.MoveToFirstChild();
                                str_id = nodes.Current.Value.ToString();
                                str = str + "<tr>";
                                str = str + "<td class='textcenter'>" + (i++) + "</td>";
                                str = str + "<td class='textcenter'><input type='checkbox' id='" + str_id + "' name='CheckGroup' /></td> ";
                                str = str + "<td align='left'>" + nodes.Current.Value.ToString() + "</td>";
                                nodes.Current.MoveToNext();
                                string des = nodes.Current.InnerXml;
                                des = HttpContext.Current.Server.HtmlDecode(des);
                                if (validate.ExistWordLength(30, des))
                                {
                                    des = validate.ConvertString(30, des);
                                }
                                des = HttpContext.Current.Server.HtmlEncode(des);
                                str = str + "<td>" + des + "</td>";
                                //str = str + "<td><a href='" + str_edit + "&id=" + str_id + "'> Edit </a></td>";
                                str = str + "<td class='textcenter'> No Edit</td>";
                                str = str + "</tr>";
                            }
                        }
                    }                    
                }
                    str = str + "</table>";                                    
            }
            list.Add(str);
        return list;

        }
        public ArrayList GetNodeIteratorToShow(bool Edit)
        {
            string str = "";
            string str_id = "";            
            XPathNodeIterator nodes;
            ArrayList list = new ArrayList();
            str = str + "<table width='100%' border='1' cellpadding='3' cellspacing='0' bordercolor='#91A7B4' style='background: #EFF5FF; border-collapse:collapse'>";
            str = str + " <colgroup> ";
            str = str + " <col width='5%' align='center' /> ";
            str = str + " <col width='5%' align='center' /> ";
            str = str + " <col width='20%' align='center' /> ";
            str = str + " <col width='60%' align='left'  /> ";
            str = str + " <col width='10%' align='center' /> ";
            str = str + " </colgroup>	";


            str = str + "<TR class='titletbl'>";
            str = str + "<TH height='20' align='center'  >Số TT</TH>";
            str = str + "<TH height='20' align='center' ><input type = 'checkbox' id = 'chkAll' onclick=\"OnchoiceAll('chkAll');return true;\"/></TH>";
            str = str + "<TH height='20' align='center' >Từ khoá</TH>";
            str = str + "<TH height='20' align='center' >Nội dung hiển thị</TH>";
            str = str + "<TH height='20' align='center' >Chỉnh sửa</TH>";
            str = str + "</TR>";
            if (navigator != null)
            {
                string xpath = string.Format("/langs/lang[position()>{0} and position()<={1}]", new string[] { GetFromRow().ToString(), GetToRow().ToString() });
                nodes = navigator.Select(xpath);
                if (Edit == true)
                {
                    if (nodes.Count > 0)
                    {
                        int i = 1;
                        while (nodes.MoveNext())
                        {
                            nodes.Current.MoveToFirstChild();
                            str_id = nodes.Current.Value.ToString();
                            str = str + "<tr>";
                            str = str + "<td class='textcenter'>" + (i++) + "</td>";
                            str = str + "<td class='textcenter'><input type='checkbox' id='" + str_id + "' name='CheckGroup' /></td> ";
                            str = str + "<td align='left'>" + nodes.Current.Value.ToString() + "</td>";
                            nodes.Current.MoveToNext();
                            string des = nodes.Current.InnerXml;
                            des = HttpContext.Current.Server.HtmlDecode(des);
                            if (validate.ExistWordLength(30, des))
                            {
                                des = validate.ConvertString(30, des);
                            }
                            des = HttpContext.Current.Server.HtmlEncode(des);
                            str = str + "<td>" + des + "</td>";
                            //str = str + "<td><a href='" + str_edit + "&id=" + str_id + "'> Edit </a></td>";
                            str = str + "<td class='textcenter'><a id='" + str_id + "' href='#' title=\"" + des + "\" onclick=\"ShowInfor(this);\"> Edit </a></td>";
                            str = str + "</tr>";
                        }
                    }
                }
                else
                {
                    if (nodes.Count > 0)
                    {
                        int i = 1;
                        while (nodes.MoveNext())
                        {
                            nodes.Current.MoveToFirstChild();
                            str_id = nodes.Current.Value.ToString();
                            str = str + "<tr>";
                            str = str + "<td>" + (i++) + "</td>";
                            str = str + "<td class='textcenter'><input type='checkbox' id='" + str_id + "' name='CheckGroup' /></td> ";
                            str = str + "<td align='left'>" + nodes.Current.Value.ToString() + "</td>";
                            nodes.Current.MoveToNext();
                            string des = nodes.Current.InnerXml;
                            des = HttpContext.Current.Server.HtmlDecode(des);
                            if (validate.ExistWordLength(30, des))
                            {
                                des = validate.ConvertString(30, des);
                            }
                            des = HttpContext.Current.Server.HtmlEncode(des);
                            str = str + "<td>" + des + "</td>";
                            //str = str + "<td><a href='" + str_edit + "&id=" + str_id + "'> Edit </a></td>";
                            str = str + "<td class='textcenter'>No Edit</td>";
                            str = str + "</tr>";
                        }
                    }
                }
            }
            str = str + "</table>";
            list.Add(str);            
            return list;
        }
        public void SetNavigator(XPathNavigator nav)
        {
            this.navigator = nav;
        }       
        public void SetStringSeach(string String_Search)
        {
            this.StringSearch = "/langs/lang[contains(key,'" + String_Search + "')]";
        }
    }   
}
