<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="pageContent">
    <div class="topFormBar">
        <ul>
            <li><a class="button" href="javascript:" onclick="javascript:autoSave();">
                <span>保存</span> </a></li>
            <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
        </ul>
    </div>

    <form method="post" action="/AuthMain/ChangePassword.bee" class="required-validate alertMsg noRefresh"
    id="content<%=PageId %>">
    <div layouth="36">
        <div class="pageFormContent">
            <dl class="nowrap">
				<dt>原密码：</dt>
				<dd>
                <input name='password' type='password' size='30' value='' class="required alphanumeric" minlength="1" maxlength="20"/>
                </dd>
			</dl>
            <dl>
				<dt>新密码：</dt>
				<dd>
                <input name='newpassword' type='password' size='30' class="required alphanumeric" minlength="1" maxlength="20"/>
                </dd>
			</dl>
			<dl>
				<dt>重复新密码：</dt>
				<dd>
                <input name='repeatpassword' type='password' size='30' class="required" equalto="input[name='newpassword']"/>
                </dd>
			</dl>
        </div>
    </div>
    
    </form>
</div>
