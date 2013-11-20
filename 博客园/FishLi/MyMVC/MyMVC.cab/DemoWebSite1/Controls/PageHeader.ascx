﻿<%@ Control Language="C#"  %>

<div id="webSiteLogo">
		<a href="/" title="回到网站首页"><img src="/Images/MyLab-logo.png" /></a></div>
<div id="currentPageTitle">
	<span><%= this.Page.Title %></span></div>
<div id="topRightBar">
	<b class="appName"><%= AppHelper.AppName%></b>
	<span>
		<a class="btnSetStyle easyui-linkbutton" plain="true" ps="Style1" href="javascript:void(0)">
				<img src="/Images/number_1.gif" title="点击此处切换到风格１" /></a>
		<a class="btnSetStyle easyui-linkbutton" plain="true" ps="Style2" href="javascript:void(0)">
				<img src="/Images/number_2.gif" title="点击此处切换到风格２" /></a>
		<a class="btnSetStyle easyui-linkbutton" plain="true" ps="Style3" href="javascript:void(0)">
				<img src="/Images/number_3.gif" title="点击此处切换到风格３" /></a>
	</span>
	<a href="javascript:window.location = window.location;" title="刷新本页面" class="easyui-linkbutton" plain="true">
		<img src="/Images/refresh.gif" alt="refresh" /></a>
</div>
