<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>

<div class="topFormBar">
        <ul>
            <li><a class="button" href="javascript:" onclick="javascript:autoSave();">
                <span>保存</span> </a></li>
            <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
        </ul>
    </div>
    
<div class="pageContent">
    <form method="post" action="/AuthMain/ChangeUserInfo.bee" class="required-validate alertMsg noRefresh"
    id="content<%=PageId %>">
    <div layouth="36">
        <div class="pageFormContent">
            <dl class="nowrap">
				<dt>昵称：</dt>
				<dd>
                <input name='nickname' type='text' size='30' value='<%=ViewData["nickname"] %>' class="required"/>
                </dd>
			</dl>
            
            <dl>
				<dt>Email：</dt>
				<dd>
                <input name='Email' type='text' size='30' value='<%=ViewData["email"] %>' class="required email"/>
                </dd>
			</dl>
			
        </div>
        

    </div>
    
    </form>
</div>

