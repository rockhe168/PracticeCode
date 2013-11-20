<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true" CodeFile="CraftKnowledgeList.aspx.cs" Inherits="CraftKnowledge_CraftKnowledgeList" Title="工艺知识列表" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/other.css" rel="stylesheet" type="text/css" />
    <link href="../css/Pager.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="list">
        <div class="list_title"><h4>工艺知识列表</h4><span>当前位置：<a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > 工艺知识列表</span></div>
        <ul>
            <asp:Repeater ID="rpData" runat="server">
            <ItemTemplate>
             <li><a href='<%#Eval("ArticleHtmlUrl") %>'>[<%#Eval("TypeName")%>]<%#Eval("Title") %></a><span><%#Eval("Time") %></span></li>
            </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="page">
              <p><div class="pager"><%=PagerHtml%></div></p>
               
        </div>
    </div>

</asp:Content>

