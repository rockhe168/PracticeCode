<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true" CodeFile="NongeneticProduct.aspx.cs" Inherits="Product_NongeneticProduct" Title="非遗精品" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="../css/other.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="show">
       <%ResponseNongeneticProduct(); %>
     
    </div>
</asp:Content>

