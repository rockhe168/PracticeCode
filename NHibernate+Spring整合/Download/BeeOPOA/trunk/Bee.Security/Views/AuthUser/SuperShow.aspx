<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="pageContent">
    <form method="post" action="/<%=ControllerName %>/SuperSave.bee" class="required-validate"
    id="content<%=PageId %>">
    <%=HtmlHelper.ForHidden("usergroup") %>
    <%=HtmlHelper.ForHidden("userrole") %>
    <div layouth="36">
        <div class="pageFormContent">
            <dl>
                <dt>Id：</dt>
                <dd>
                <%=HtmlHelper.ForTextBox("Id", "readonly=readonly") %>
                </dd>
            </dl>
            <dl>
                <dt>用户名：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("UserName") %>
                    </dd>
            </dl>
            <dl>
                <dt>昵称：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("NickName") %>
                    </dd>
            </dl>
            <dl>
                <dt>密码：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("Password") %>
                    </dd>
            </dl>
            <dl>
                <dt>工号：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("WorkCode") %>
                    </dd>
            </dl>
            <dl>
                <dt>身份证号：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("cardid") %>
                    </dd>
            </dl>
            <dl>
                <dt>Email：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("email") %>
                    </dd>
            </dl>
            <dl>
                <dt>电话：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("tel") %>
                    </dd>
            </dl>
            <dl>
                <dt>地址：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("address") %>
                    </dd>
            </dl>
            <dl>
                <dt>备注：</dt>
                <dd>
                    <textarea name="remark" ><%=ViewData["remark"] %></textarea>
                    </dd>
            </dl>
            <dl>
                <dt>内置账号：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("InnerFlag") %>
                    </dd>
            </dl>
            <dl>
                <dt>是否删除：</dt>
                <dd>
                <%=HtmlHelper.ForTextBox("DelFlag")%>
                </dd>
            </dl>
            <dl>
                <dt>创建时间：</dt>
                <dd>
                    <%=HtmlHelper.ForTextBox("createtime")%>
                    </dd>
            </dl>
        </div>
        <% System.Data.DataTable dataTable = ViewData["groupinfo"] as System.Data.DataTable;  %>
        <div style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
            border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="240">
            <ul id="grouptree<%=PageId %>" class="tree treeFolder treeCheck expand">
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
            <li><a class="button" href="javascript:" onclick="javascript:saveUser();"><span>保存</span>
            </a></li>
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

