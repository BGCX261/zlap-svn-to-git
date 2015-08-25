<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerUser.aspx.cs" Inherits="ManagerUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User View</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%=strTime %>
    <%=strChangePage %>
    <%=tableUser %>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        function Change(index,page)
        {
            if(index==1)
            {
                if(page>1)
                {
                    page=page-1;
                }
                location.href="?page="+ page + "&size=20";
             }else
             {
                page=page+1;
                location.href="?page="+ page + "&size=20";
             }
        }
    </script>
</body>
</html>
