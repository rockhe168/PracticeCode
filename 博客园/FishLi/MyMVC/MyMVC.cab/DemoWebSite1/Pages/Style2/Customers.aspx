﻿<%@ Page Title="客户管理" Language="C#" MasterPageFile="MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%= HtmlExtension.RefJsFileHtml("/js/MyPage2/Customers.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table id="grid1"></table>


<div id="divCustomerInfo" title="客户" style="padding: 8px; display: none">
<%= UcExecutor.Render("/Controls/Style2/CustomerInfo.ascx", null)%>
</div>

</asp:Content>

