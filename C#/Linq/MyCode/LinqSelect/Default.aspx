<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinqSelect.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvMain" runat="server"></asp:GridView>
        <br />
        <br />

        <asp:GridView ID="gvPager" runat="server" AllowPaging="True" 
            onpageindexchanging="gvPager_PageIndexChanging"></asp:GridView>
       
    </div>
    </form>
</body>
</html>
