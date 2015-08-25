<%@ Control Language="C#" AutoEventWireup="true" CodeFile="searchheader.ascx.cs" Inherits="block_searchheader" %>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
<tr>
  <td class="bg_search1"></td>
  <td class="bg_search2"><table border="0" cellpadding="0" cellspacing="0" width="100%" height="60">
      <tr>
        <td height="31" align="center"><table border="0" cellpadding="0" cellspacing="0">
            <tr>
              <td class="text_search"><%=tsearch%></td>
              <td><input type="text" id="text_quick_search" class="text_box1" value="<%=msearch %>"  onkeydown="OnEnterSend(event,'bqs');" onfocus="this.value='';"/></td>
              <td class="text_menu">&raquo;</td>
              <td width="140" align="left"><select id="select_quick_search" style="width:135px;">
                  <option value="dasp"><%=tpro %></option>
                  <option value="qsc"><%=tcom %></option>
                </select></td>
              <td><div class="button1" id='bqs' onclick="OnQuickSearch();"><%=tsearch%></div></td>
              <td class="text_menu"><a href="?menu=asp"><%=avsearch %></a></td>
            </tr>
          </table></td>
      </tr>
      <tr>
        <td class="text_1" align="center" height="29"><div class="currentpage" id="currentAccess"></div></td>
      </tr>
    </table></td>
  <td class="bg_search3"></td>
</tr>
</table>