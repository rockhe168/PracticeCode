<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="/AuthRole/Index.bee" method="post">
<input type="hidden" name="permission" value="<%=ViewData["permission"] %>" />
<input type="hidden" name="id" value="<%=ViewData["id"] %>" />

</form>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
    border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="56">
    <ul id="<%=PageId %>tree" class="tree treeFolder treeCheck expand readonly">
        <%=HtmlHelper.ForTree(dataTable, "parentid", "title", "id", "dispindex asc") %>
    </ul>
</div>

<script type="text/javascript">

    $(document).ready(function() {
        var $form = $("#pageForm<%=PageId %>");
        var permission = $("input[name='permission']", $form).val();
        $("#<%=PageId %>tree").treeVal(permission);
    });

</script>

