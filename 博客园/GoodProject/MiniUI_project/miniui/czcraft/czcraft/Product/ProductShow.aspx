<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true"
    CodeFile="ProductShow.aspx.cs" Inherits="Product_ProductShow" Title="作品展览" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/other.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="show">
        <div class="show_title">
            <h4>
                推荐作品</h4>
            <p class="hide">
                <a href='<%=URLManage.GetURL("~/Product/MoreProduct","Condition=Isrecomment")%>'>更多</a></p>
        </div>
        <div class="show_t">
            <ul id="IsRecomment">
                <asp:Repeater ID="rpRecommentData" runat="server">
                    <ItemTemplate>
                        <li><a href='<%=URLManage.GetURL("~/Product/Product","")%>?ProductId=<%#Eval("Id") %>' class="c_pic_a">
                            <img src='../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName=<%#Eval("Picturepath") %>'
                                alt='<%#Eval("Name") %>' title='<%#Eval("Name") %>' /></a> <a href="#" class="a_title">
                                    <%#Eval("Name") %><br />
                                    <span class="rad2">￥'<%#Eval("Lsprice")%>'</span></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="show_b">
        </div>
        <div class="show_title">
            <h4>
                佳作欣赏</h4>
            <p class="hide">
                <a href='<%=URLManage.GetURL("~/Product/MoreProduct","Condition=Isexcellent")%>?ProductId=<%#Eval("Id") %>'>更多</a></p>
        </div>
        <div class="show_t">
            <ul id="Isexcellent">
                <asp:Repeater ID="rpIsexcellentData" runat="server">
                    <ItemTemplate>
                        <li><a href='<%=URLManage.GetURL("~/Product/Product","")%>?ProductId=<%#Eval("Id") %>' class="c_pic_a">
                            <img src='../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName=<%#Eval("Picturepath") %>'
                                alt='<%#Eval("Name") %>' title='<%#Eval("Name") %>' /></a> <a href='<%=URLManage.GetURL("~/Product/Product","")%>?ProductId=<%#Eval("Id") %>' class="a_title">
                                    <%#Eval("Name") %><br />
                                    <span class="rad2">￥<%#Eval("Lsprice")%></span></a> </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="show_b">
        </div>
    </div>
</asp:Content>
