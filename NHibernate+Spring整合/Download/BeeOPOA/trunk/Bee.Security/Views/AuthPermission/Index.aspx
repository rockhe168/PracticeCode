<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="<%=HtmlHelper.ForActionLink() %>" method="post">
<div class="formBar">
    <ul style="float: left; margin-right: 350px;">
        <li><a class="button" href="javascript:" onclick="javascript:Create<%=PageId %>();">
            <span>创建子权限</span> </a></li>
        <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
    </ul>
    <ul style="float: left;">
        <li><a class="button" href="javascript:" onclick="javascript:autoSave('content<%=PageId %>');">
            <span>保存</span> </a></li>
        <li><a class="button" href="javascript:" onclick="javascript:Delete();">
            <span>删除</span> </a></li>
    </ul>
</div>
</form>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
    border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="56">
    <ul id="tree1" class="tree treeFolder expand" oncheck="Edit">
        <%=HtmlHelper.ForTree(dataTable, "parentid", "title", "id", "dispindex asc", 0, "<ul>", "</ul>", 
            "<li><a tvalue={1} onclick='Edit" + PageId +"({1});'>{0}</a>", "</li>")%>
    </ul>
</div>
<div class="pageFormContent" layouth="56">
    <form id='content<%=PageId %>' action="<%=HtmlHelper.ForActionLink("save") %>" method="post"
    class="required-validate alertMsg">
    <p>
        <label>
            上级权限编号：</label>
        <input name="parentid" type='text' size='30' class="required" title="上级权限编号不能为空"/>
    </p>
    <p>
        <label>
            权限编号：</label>
        <input name="id" type='text' size='30' readonly="readonly" />
    </p>
    <p>
        <label>
            权限名称：</label>
        <input name="name" type='text' size='30' class="required"  title="权限名称不能为空"/>
    </p>
    <p>
        <label>
            权限标题：</label>
        <input name="title" type='text' size='30' />
    </p>
    <p>
        <label>
            资源：</label>
        <input name="res" type='text' size='30' maxlength="150"/>
    </p>
    <p>
        <label>
            扩展资源：</label>
        <input name="exres" type='text' size='30' />
    </p>
    <p>
        <label>
            显示顺序：</label>
        <input name="dispindex" type='text' size='30' />
    </p>
    <p>
        <label>
            是否显示：</label>
        是：<input name="showflag" type='radio' size='30' value="true" />
        否：<input name="showflag" type='radio' size='30' value="false" />
    </p>
    <p>
        <label>
            是否已删除：</label>
        <select name="delflag">
            <option value="false">false</option>
            <option value="true">true</option>
        </select>
    </p>
    <p>
        <label>
            创建时间：</label>
        <input name="createtime" type='text' size='30' readonly='readonly' />
    </p>
    </form>
</div>

<script type="text/javascript">

    var Create<%=PageId %> = function(){
        var $form = $("#content<%=PageId %>");
        var id = $("input[name='id']", $form).val();
        if (id != "") {
            $form[0].reset();
            $("input[name='parentid']", $form).val(id);
        }
    }
    
    function Edit<%=PageId %>(id) {
        bee.PostData("/AuthPermission/Detail.bee", { id: id }, function(data) {
            var $form = $("#content<%=PageId %>");
            autoFill($form, data);

        });
    }

    function Delete() {
        var $form = $("#content<%=PageId %>");
        var id = $("input[name='id']", $form).val();
        if (id != "") {
            alertMsg.confirm("是否删除？", {
                okCall: function() {
                    bee.PostData("/AuthPermission/Delete.bee", { id: id }, function() { autoList(); });
                }
            });
        }
    }
</script>

