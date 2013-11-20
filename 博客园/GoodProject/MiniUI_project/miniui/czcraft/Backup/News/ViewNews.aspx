<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true" CodeFile="ViewNews.aspx.cs" Inherits="News_ViewNews" Title="新闻" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="../css/other.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="complate">
        <p class="load"><span></span>当前位置：<a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > <a href='<%=URLManage.GetURL("~/News/NewsList","")%>'>新闻中心</a> > 内容</p>
        <div class="complate_zw">
            <h3><%=NewInfo.Title %></h3>
            <p class="zw_xx">
                <span>发布人：潮州工艺品网站</span>
                <span>发布时间：<%=NewInfo.Time%></span>
            </p>
            <div class="zw_nr">
                <div>
                
                <%=NewInfo.Content%>
                </div>
 
               <p class="zw_nr_foot">上一篇文章：<a href='<%=PreNews.ArticleHtmlUrl%>'><%=PreNews.Title %></a><br />
               下一篇文章：<a href='<%=NextNews.ArticleHtmlUrl%>'><%=NextNews.Title %> </a> </p>
            </div>
        </div>
    </div>

</asp:Content>

