<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="<%=HtmlHelper.ForActionLink() %>" method="post">
<div class="formBar">
    <ul style="float: left; margin-right: 350px;">
        <li><a class="button" href="javascript:" onclick="javascript:Create<%=PageId %>();">
            <span>创建子字典项</span> </a></li>
        <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
    </ul>
    <ul style="float: left;">
        <li><a class="button" href="javascript:" onclick="javascript:Save<%=PageId %>();">
            <span>保存</span> </a></li>
        <li><a class="button" href="javascript:" onclick="javascript:Delete();"><span>删除</span>
        </a></li>
    </ul>
</div>
</form>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
    border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="56">
    <ul id="tree1" class="tree treeFolder expand">
        <%=HtmlHelper.ForTree(dataTable, "parentid", "title", "id", "id asc", 0, "<ul>", "</ul>", 
            "<li><a tvalue={1} onclick='Edit" + PageId +"({1});'>{0}</a>", "</li>")%>
    </ul>
</div>
<div class="pageFormContent" layouth="56">
    <form id='content<%=PageId %>' action="<%=HtmlHelper.ForActionLink("DataDictSave") %>"
    method="post" class="required-validate alertMsg">
    <div id="dataDictDetail">
    </div>
    </form>
</div>

<script type="text/javascript">

    var Create<%=PageId %> = function(){
        var $form = $("#content<%=PageId %>");
        var id = $("input[name='id']", $form).val();
        if (id == undefined || id== "") {
            id = 0;
        }
        
        $("#dataDictDetail").loadUrl("/Config/DataDictDetail.bee", {id:0}, function(){
                $("input[name='id']", $form).val("");
                $("input[name='parentid']", $form).val(id);
            });
    }
    
    var Save<%=PageId %> = function(){
        var $form = $("#content<%=PageId %>");
        if ($form.valid()) {
            bee.PostData($form.attr('action'), $form.serializeArray(), function(data) {
            navTab.reloadCurrent();
            alertMsg.correct("操作成功！");
            });
        }
    }
    
    function Edit<%=PageId %>(id) {
        $("#dataDictDetail").loadUrl("/Config/DataDictDetail.bee", {id:id}, null);
    }

    function Delete() {
        var $form = $("#content<%=PageId %>");
        var id = $("input[name='id']", $form).val();
        if (id != "") {
            alertMsg.confirm("是否删除？", {
                okCall: function() {
                    bee.PostData("/Config/DataDictDelete.bee", { id: id }, function() { autoList(); });
                }
            });
        }
    }
</script>

