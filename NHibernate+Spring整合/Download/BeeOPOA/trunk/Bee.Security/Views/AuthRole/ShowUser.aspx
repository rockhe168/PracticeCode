<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="/AuthRole/Index.bee" method="post">
<input type="hidden" name="permission" value="<%=ViewData["permission"] %>" />
<input type="hidden" name="id" value="<%=ViewData["id"] %>" />
<div class="formBar">
    <ul style="float: left;">
        <li><a class="button close" href="javascript:"><span>
            关闭</span> </a></li>
        <li><span>
            <%Bee.Models.AuthRole authRole = ViewData["roleinfo"] as Bee.Models.AuthRole; %>
            <%=authRole.Name %></span></li>
    </ul>
</div>
</form>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
    border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="56">
    <ul id="<%=PageId %>tree" class="tree treeFolder treeCheck expand readonly">
        <%=HtmlHelper.ForTree(dataTable, "id", "nickname", "id", "dispindex asc") %>
    </ul>
</div>


