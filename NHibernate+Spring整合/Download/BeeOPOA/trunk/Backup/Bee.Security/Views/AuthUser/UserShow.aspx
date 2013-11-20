<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="pageContent">
    <form method="post" action="/<%=ControllerName %>/Save.bee" class="required-validate"
    id="content<%=PageId %>">
    <%=HtmlHelper.ForHidden("usergroup") %>
    <%=HtmlHelper.ForHidden("userrole") %>
    <div layouth="36">
        <div class="pageFormContent">
            <%=HtmlHelper.AutoDetailInfo %>
        </div>
        <% System.Data.DataTable dataTable = ViewData["groupinfo"] as System.Data.DataTable;  %>
        <div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
            border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="240">
            <ul id="grouptree<%=PageId %>" class="tree treeFolder treeCheck expand treealone">
                <%=HtmlHelper.ForTree(dataTable, "parentid", "name", "id", "id asc") %>
            </ul>
        </div>
        <% dataTable = ViewData["roleinfo"] as System.Data.DataTable;  %>
        <div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
            border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="240">
            <ul id="roletree<%=PageId %>" class="tree treeFolder treeCheck expand">
                <%=HtmlHelper.ForSingleTree(dataTable, "name", "id", "id asc") %>
            </ul>
        </div>
    </div>
    <div class="formBar">
        <ul>
            <li><a class="button" href="javascript:" onclick="javascript:saveUser();">
                <span>保存</span> </a></li>
            <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
        </ul>
    </div>
    </form>
</div>

<script type="text/javascript">
    var saveUser = function() {
        $form = $("#content<%=PageId %>");
        var usergroup = $("#grouptree<%=PageId %>", $form).treeVal();
        var userrole = $("#roletree<%=PageId %>", $form).treeVal();

        $("input[name='usergroup']", $form).val(usergroup);
        $("input[name='userrole']", $form).val(userrole);
        autoSave("content<%=PageId %>");
    }

    $(document).ready(function() {
        var $form = $("#content<%=PageId %>");
        var permission = $("input[name='usergroup']", $form).val();
        $("#grouptree<%=PageId %>").treeVal(permission);

        permission = $("input[name='userrole']", $form).val();
        $("#roletree<%=PageId %>").treeVal(permission);
    });
</script>
