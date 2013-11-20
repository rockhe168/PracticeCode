﻿<%@ Page Title="订单管理" Language="C#" MasterPageFile="MasterPage.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%= HtmlExtension.RefJsFileHtml("/js/MyPage/Orders.js")%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<fieldset id="myQueryForm">
<legend>查询条件</legend>
<table cellpadding="4" cellspacing="0" >
<tr><td>订单日期 从</td>
	<td><input type="text" id="txtStartDate" name="StartDate" value='2010-11-01' 
			class="myTextbox easyui-datebox" style="width: 120px" /></td>
	<td style="width: 35px; text-align: right">到</td>
	<td><input type="text" id="txtEndDate" name="EndDate" value='<%= DateTime.Now.ToString("yyyy-MM-dd") %>'
		 class="myTextbox easyui-datebox" style="width: 120px" /></td>
	<td><a href="#" id="btnQuery" class="easyui-linkbutton" iconCls="icon-find">查找订单</a></td>
</tr>
</table>
</fieldset>


<div id="divResultList" style="padding: 8px 0px">
<div id="divResultList_inner"></div>
</div>


<div id="divCustomerInfo" title="查看客户资料" style="padding: 8px; display: none;">
<div id="divCustomerInfo_inner"></div>
</div>

<div id="divOrderInfo" title="订单明细" style="padding: 8px; display: none;">
<div id="divOrderInfo_inner"></div>
</div>

<div id="divProductInfo" title="查看商品资料" style="padding: 8px; display: none;">
<div id="divProductInfo_inner"></div>
</div>


</asp:Content>

