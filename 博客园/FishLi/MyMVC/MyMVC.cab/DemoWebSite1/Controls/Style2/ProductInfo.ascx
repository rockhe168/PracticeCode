﻿<%@ Control Language="C#" %>

<form id="formCreateProduct" method="post" action="">
<table cellpadding="4" border="0px">
<tr><td style="width: 70px">商品分类</td><td>
		<select id="ddlCategoryID" name="CategoryID" style="width: 200px"></select>
	</td></tr>
<tr><td>商品名称</td><td>
		<input name="ProductName" type="text" maxlength="50" id="txtProductName" class="myTextbox" style="width:460px;" value="" />
	</td></tr>
<tr><td>单位</td><td>
		<select name="Unit" id="ddlUnit" combobox="editable" style="width:100px;"></select>
	</td></tr>
<tr><td>单价</td><td>
		<input name="UnitPrice" type="text" maxlength="10" id="txtUnitPrice" class="myTextbox" style="width:100px;" value="" />
	</td></tr>
<tr><td>数量</td><td>
		<input name="Quantity" type="text" maxlength="5" id="txtQuantity" class="myTextbox" style="width:100px;" value="" />
	</td></tr>
<tr><td class="vertical">备注</td><td>
		<textarea name="Remark" rows="2" cols="20" id="txtRemark" class="myTextbox" style="height:130px;width:460px;"></textarea>
	</td></tr>
</table>
</form>

