
$(function() {
	$('#btnCreateItem').click(function(){
	    $("#divCustomerInfo :text").val("");
		ShowEditItemDialog('', 'divCustomerInfo', 570, 300, InsertCustomer);
		return false;
	});
	
	$("table.GridView a.easyui-linkbutton[rowId]").click(ShowCustomerDialog);
});

function ShowCustomerDialog(){
	var dom = this;
	var customerId = $(this).attr("rowId");
	// 首先获取指定的客户资料
	$.ajax({
		url: "/AjaxCustomer/GetById.cspx?id=" + customerId, dataType: "json",
		success: function(json) { 
			$("#txtCustomerName").val(json.CustomerName);
			$("#txtContactName").val(json.ContactName);
			$("#txtAddress").val(json.Address);
			$("#txtPostalCode").val(json.PostalCode);
			$("#txtTel").val(json.Tel);
			
			// 显示编辑对话框
			ShowEditItemDialog(customerId, 'divCustomerInfo', 570, 300, function(j_dialog){
				// 验证输入
				if (ValidateForm() ) {
					var j_waitDialog = ShowWaitMessageDialog();
					$.ajax({	// 这里将演示如果将请求提交给当前页的页面方法。
						type: "POST", 
						// 说明：最新的版本中，页面已没有后置代码，所以取消这个演示。
						// 注意参数：AjaxPageMethod，它指出了要调用页面的哪个方法。
						//data: $.param({AjaxPageMethod: "UpdateCustomerInfo", CustomerID: customerId}) + "&" + $("#divCustomerInfo :text").fieldSerialize(),
						// 也可以使用下面的设置，那么将直接调用一个C#方法
						url: "/AjaxCustomer/Update.cspx",  data: $.param({CustomerID: customerId}) + "&" + $("#divCustomerInfo :text").fieldSerialize(),
						complete: function() { HideWaitMessageDialog(j_waitDialog); },
						success: function(responseText) {
								$.messager.alert(g_MsgBoxTitle, "操作成功。", "info", function(){ 
									// 直接修改页面中的文字
									var j_tr = $(dom).closest("tr");
									j_tr.find("a[rowId]").linkbutton({text: $("#txtCustomerName").val()});
									j_tr.find("span[name=ContactName]").text( $("#txtContactName").val() );
									j_tr.find("span[name=Address]").text( $("#txtAddress").val() );
									j_tr.find("span[name=PostalCode]").text( $("#txtPostalCode").val() );
									j_tr.find("span[name=Tel]").text( $("#txtTel").val() );
									j_dialog.hide().dialog('close');
								});
						}
					});
				}
			});
		}
	});	
	
	return false;
}


function InsertCustomer(j_dialog){
	if( ValidateForm() == false ) return;
	
	var j_waitDialog = ShowWaitMessageDialog();
	$.ajax({
		url: "/AjaxCustomer/Insert.cspx",  type: "POST", 
		data: $("#divCustomerInfo :text").fieldSerialize(),
		complete: function() { HideWaitMessageDialog(j_waitDialog); },
		success: function(responseText) {
				$.messager.alert(g_MsgBoxTitle, "操作成功。", "info", function(){ 
					j_dialog.hide().dialog('close');
					window.location = window.location;
				});
		}
	});
}


function ValidateForm(){
	if( ValidateControl("#txtCustomerName", "客户名称 不能为空。") == false ) return false;
	return true;
}

