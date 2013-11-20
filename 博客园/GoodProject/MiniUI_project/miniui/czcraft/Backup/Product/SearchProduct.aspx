<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true" CodeFile="SearchProduct.aspx.cs" Inherits="Product_SearchProduct" Title="产品显示" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <link href="../css/other.css" rel="stylesheet" type="text/css" />
    <link href="../css/pager.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="show">
        <div class="show_title1">
            <h4>
                <asp:Literal ID="ltTitle" runat="server"></asp:Literal></h4>
            <p class="hide">
                <a href='<%=URLManage.GetURL("~/Default","")%> %>'>首页</a></p>
        </div>
        <div class="show_t">
            <ul id="IsRecomment">
                <asp:Repeater ID="rpData" runat="server">
                    <ItemTemplate>
                        <li><a href=='<%=URLManage.GetURL("~/Product/Product","")%>?ProductId=<%#Eval("Id") %>' class="c_pic_a">
                            <img src='../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName=<%#Eval("Picturepath") %>'
                                alt='<%#Eval("Name") %>' title='<%#Eval("Name") %>' /></a> <a href=='<%=URLManage.GetURL("~/Product/Product","")%>?ProductId=<%#Eval("Id") %>' class="a_title">
                                    <%#Eval("Name") %><br />
                                    <span class="rad2">￥<%#Eval("Lsprice")%></span></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
             <div class="page">
             <div class="pager"><%=PagerHtml%></div>
               
        </div>
        </div>
        <div class="show_b">
       
        </div>
        </div>
      
</asp:Content>

