<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true" CodeFile="ViewCraftKnowledge.aspx.cs" Inherits="CraftKnowledge_ViewCraftKnowledge" Title="工艺知识内容" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="../css/other.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="complate">
        <p class="load"><span></span>当前位置：<a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > <a href='<%=URLManage.GetURL("~/CraftKnowledge/CraftKnowledgeList","")%>'>工艺知识中心</a> > 内容</p>
        <div class="complate_zw">
            <h3 id="InfoTitle"><%=CraftKnowledgeInfo.Title %></h3>
            <p class="zw_xx">
                <span>发布人：潮州工艺品网站</span>
                <span>发布时间：<%=CraftKnowledgeInfo.Time%></span>
            </p>
            <div class="zw_nr" >
                <div id="craft">
                
                <%=CraftKnowledgeInfo.Content%>
                </div>
 
               <p class="zw_nr_foot">上一篇文章：<a href='<%=PreCraftKnowledge.ArticleHtmlUrl%>'><%=PreCraftKnowledge.Title %></a><br />
               下一篇文章：<a href='<%=NextCraftKnowledge.ArticleHtmlUrl%>'><%=NextCraftKnowledge.Title %> </a> </p>
            </div>
        </div>
    </div>
</asp:Content>

