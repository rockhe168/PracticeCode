<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="<%=HtmlHelper.ForActionLink() %>" method="post">
<div class="formBar">
    <ul style="float: left; margin-right: 350px;">
        <li><a class="button" href="javascript:" onclick="javascript:Create<%=PageId %>();">
            <span>创建子组织</span> </a></li>
        <li><a class="button close" href="javascript:">
            <span>取消</span> </a></li>
    </ul>
    <ul style="float: left;">
        <li><a class="button" href="javascript:" onclick="javascript:groupSave();"><span>保存</span>
        </a></li>
        <li><a class="button" href="javascript:" onclick="javascript:Delete<%=PageId %>();">
            <span>删除</span> </a></li>
    </ul>
</div>
</form>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
    border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="56">
    <ul id="<%=PageId %>tree" class="tree treeFolder expand">
        <%=HtmlHelper.ForTree(dataTable, "parentid", "name", "id", "id asc", 0, "<ul>", "</ul>", 
            "<li><a tvalue={1} onclick='Edit" + PageId +"({1});'>{0}</a>", "</li>")%>
    </ul>
</div>
<div layouth="36">
    <div class="pageFormContent">
        <form id='content<%=PageId %>' action="<%=HtmlHelper.ForActionLink("orgsave") %>" method="post"
        class="required-validate">
        <%=HtmlHelper.ForHidden("roleinfo") %>
        <p>
            <label>
                上级组织编号：</label>
            <input name="parentid" type='text' size='30' class="required" />
        </p>
        <p>
            <label>
                组织编号：</label>
            <input name="id" type='text' size='30' readonly="readonly" />
        </p>
        <p>
            <label>
                组织代码：</label>
            <input name="orgcode" type='text' size='30' readonly="readonly" />
        </p>
        <p>
            <label>
                组织名称：</label>
            <input name="name" type='text' size='30' class="required" />
        </p>
        <p>
            <label>
                地址：</label>
            <input name="address" type='text' size='30' />
        </p>
        <p>
            <label>
                备注：</label>
            <textarea name="remark"></textarea>
        </p>
        <p>
            <label>
                是否已删除：</label>
            是：<input name="delflag" type='radio' size='30' value="true" />
            否：<input name="delflag" type='radio' size='30' value="false" />
        </p>
        <p>
            <label>
                创建时间：</label>
            <input name="createtime" type='text' size='30' readonly='readonly' />
        </p>
        </form>
    </div>
    <% dataTable = ViewData["roleinfo"] as System.Data.DataTable;  %>
    <div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
        border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="240">
        <ul id="roletree<%=PageId %>" class="tree treeFolder treeCheck expand">
            <%=HtmlHelper.ForSingleTree(dataTable, "name", "id", "id asc") %>
        </ul>
    </div>
</div>

<script type="text/javascript">

    var groupSave = function(){
        $form = $("#content<%=PageId %>");
        
        var userrole = $("#roletree<%=PageId %>").treeVal();

        $("input[name='roleinfo']", $form).val(userrole);
        autoSave("content<%=PageId %>");
    }

    var Create<%=PageId %> = function(){
        var $form = $("#content<%=PageId %>");
        var id = $("input[name='id']", $form).val();
        if (id != "") {
            $form[0].reset();
            $("input[name='parentid']", $form).val(id);
        }
    }
    
    var Edit<%=PageId %> = function (id) {
        var json = arguments[0];
        bee.PostData("/AuthGroup/OrgDetail.bee", { id: id }, function(data) {
            var $form = $("#content<%=PageId %>");
            autoFill($form, data);
            $("#roletree<%=PageId %>").treeVal(data["roleinfo"]);
        });
    }

    var Delete<%=PageId %> = function() {
        var $form = $("#content<%=PageId %>");
        var id = $("input[name='id']", $form).val();
        if (id != "") {
            alertMsg.confirm("是否删除？", {
                okCall: function() {
                    bee.PostData("/AuthGroup/Delete.bee", { id: id }, function() { autoList(); });
                }
            });
        }
    }
</script>

