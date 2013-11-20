<%@ Page Language="C#" MasterPageFile="~/CompanyZone.master" AutoEventWireup="true"
    CodeFile="AddProduct.aspx.cs" Inherits="CompanyZone_AddProduct" Title="添加商品" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />

    <script src="../Admin/scripts/PluginForm.js" type="text/javascript"></script>

    <script src="../Admin/scripts/jquery.MultiFile.pack.js" type="text/javascript"></script>

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script>

    <script src="../Admin/scripts/isValid.js" type="text/javascript"></script>

    <link href="../Admin/scripts/miniui/themes/default/miniui.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Admin/kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../Admin/kindeditor/plugins/code/prettify.css" />

    <script charset="utf-8" type="text/javascript" src="../Admin/kindeditor/kindeditor.js"></script>

    <script charset="utf-8" type="text/javascript" src="../Admin/kindeditor/lang/zh_CN.js"></script>

    <script charset="utf-8" type="text/javascript" src="../Admin/kindeditor/plugins/code/prettify.js"></script>

    <script src="../js/AjaxJsDeal/CompanyZoneAddProduct.js" type="text/javascript"></script>

    <style type="text/css">
        html, body
        {
            font-size: 12px;
            padding: 0;
            margin: 0;
            text-align: center;
            border: 0;
        }
        .style2
        {
            width: 100px;
            height: 25px;
        }
        .style3
        {
            width: 200px;
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="nav">
        <ul class="TabBarLevel1" id="Ul1">
            <li class="selected"><a style="color: #FFF" href='<%=URLManage.GetURL("~/CompanyZone/AddProduct","")%>'>商品添加</a></li>
            <li><a href='<%=URLManage.GetURL("~/CompanyZone/ProductManage","")%>'>产品管理</a></li>
            <li><a href='<%=URLManage.GetURL("~/CompanyZone/CompanyInfo","")%>'>个人简介</a></li>
            <li><a href='<%=URLManage.GetURL("~/CompanyZone/Reward","")%>'>获奖情况</a></li>
              <li><a  href='<%=URLManage.GetURL("~/CompanyZone/CompanyPic","")%>'>企业美景图</a></li>
        </ul>
    </div>
    <form id="form1" action="Data/CompanyZoneInfo.ashx?method=SaveProduct" enctype="multipart/form-data">
    <div style="width: 960px; margin: 30px 0;">
        <fieldset style="border: solid 1px #aaa; margin-left: 180px; padding: 3px; width: 600px;">
            <legend>产品信息</legend>
            <input type="hidden" id="Id" name="Id" />
            <div style="padding: 5px;">
                <table>
                    <tr>
                        <td class="style2">
                            产品名称：
                        </td>
                        <td class="style3">
                            <input name="Name" id="Name" class="mini-textbox" requirederrortext="产品名不能为空" required="true"
                                maxlength="30" onvalidation="isRegisterUserName" />
                        </td>
                        <td class="style2">
                            产品简称：
                        </td>
                        <td class="style3">
                            <input name="Simplename" id="Simplename" maxlength="16" onvalidation="isRegisterUserName"
                                requirederrortext="产品简称不能为空" required="true" class="mini-textbox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            材质：
                        </td>
                        <td class="style3">
                            <input name="Material" class="mini-textbox" maxlength="16" id="Material" />
                        </td>
                        <td class="style2">
                            重量：
                        </td>
                        <td class="style3">
                            <input name="Weight" id="Weight" maxlength="8" class="mini-textbox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            体积：
                        </td>
                        <td class="style3">
                            <input name="Volume" class="mini-textbox" maxlength="20" id="Volume" />
                        </td>
                        <td class="style2">
                            规格：
                        </td>
                        <td class="style3">
                            <input name="Specification" id="Specification" maxlength="20" class="mini-textbox" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            型号：
                        </td>
                        <td class="style3">
                            <input name="Model" class="mini-textbox" maxlength="20" id="Model" />
                        </td>
                        <td class="style2">
                            类别：
                        </td>
                        <td class="style3">
                            <input id="btnEdit1" class="mini-buttonedit" requirederrortext="类别不能为空" required="true"
                                onbuttonclick="onButtonEdit" />
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
        <fieldset style="border: solid 1px #aaa; margin-left: 180px; padding: 3px; width: 600px;
            text-align: center">
            <legend>产品管理</legend>
            <div style="padding: 5px;">
                <table>
                    <td class="style2">
                        非遗：
                    </td>
                    <td class="style3">
                        <input type="checkbox" id="Nongenetic" name="Nongenetic" class="mini-checkbox">
                    </td>
                    <td class="style2">
                        非卖品：
                    </td>
                    <td class="style3">
                        <input type="checkbox" id="Issell" name="Issell" class="mini-checkbox">
                    </td>
                    </tr>
                </table>
        </fieldset>
        <fieldset style="border: solid 1px #aaa; margin-left: 180px; padding: 3px; width: 600px;
            text-align: center">
            <legend>详细信息</legend>
            <div style="padding: 5px;">
                <table>
                    <tr>
                        <td class="style2">
                            总量：
                        </td>
                        <td class="style3">
                            <input name="Num" id="Num" class=" mini-spinner" minvalue="1" maxvalue="1000000" />
                        </td>
                        <td rowspan="4">
                            产品图片：
                        </td>
                        <td rowspan="4" colspan="2">
                            <img width="100" id="pic" name="pic" height="100px" style="margin-left: 10px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            销量：
                        </td>
                        <td class="style3">
                            <input name="Soldnum" id="Soldnum" class="mini-spinner" minvalue="1" maxvalue="1000000" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            零售价：
                        </td>
                        <td class="style3">
                            <input name="Lsprice" id="Lsprice" decimalplaces="2" class=" mini-spinner" minvalue="1.00"
                                maxvalue="1000000" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            批发价：
                        </td>
                        <td class="style3">
                            <input name="Pfprice" id="Pfprice" decimalplaces="2" class=" mini-spinner" minvalue="1.00"
                                maxvalue="1000000" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            会员价：
                        </td>
                        <td class="style3">
                            <input name="Vipprice" id="Vipprice" decimalplaces="2" class=" mini-spinner" minvalue="1.00"
                                maxvalue="1000000" />
                        </td>
                        <td class="style2">
                            图片上传：
                        </td>
                        <td class="style3">
                            <input class="multi" style="width: 180px" type="file" id="fileupload" name="fileupload"
                                maxlength="1" accept="gif|jpg|bmp|png" />
                            <input type="hidden" name="Picturepath" id="Picturepath" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            市场价:
                        </td>
                        <td colspan="style3">
                            <input name="MarketPrice" value="1.00" decimalplaces="2" id="MarketPrice" class="mini-spinner "
                                minvalue="1.00" maxvalue="1000000" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            价格1：
                        </td>
                        <td class="style3">
                            <input name="Price1" value="1.00" id="Price1" decimalplaces="2" class=" mini-spinner"
                                minvalue="1.00" maxvalue="1000000" />
                        </td>
                        <td class="style2">
                            价格2：
                        </td>
                        <td class="style3">
                            <input name="Price2" id="Price2" decimalplaces="2" class=" mini-spinner" minvalue="1.00"
                                maxvalue="1000000" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            价格3：
                        </td>
                        <td class="style3">
                            <input name="Price3" id="Price3" decimalplaces="2" class=" mini-spinner" minvalue="1.00"
                                maxvalue="1000000" />
                        </td>
                        <td class="style2">
                            价格4：
                        </td>
                        <td class="style3">
                            <input name="Price4" id="Price4" decimalplaces="2" class=" mini-spinner" minvalue="1.00"
                                maxvalue="1000000" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            产品介绍：
                        </td>
                        <td colspan="3">
                            <textarea id="Explain" name="Explain" cols="100" rows="8" style="width: 450px; height: 200px;
                                visibility: hidden;"></textarea>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
        <div style="padding: 3px; width: 600px; text-align: center; margin-left: 150px;">
            <a class="mini-button" id="ajaxButton" style="width: 60px; margin-left: 150px; margin-right: 10px"
                onclick="onUpload">上传</a> <a class="mini-button" id="ok" onclick="onOk" style="width: 60px;
                    margin-right: 10px">确定</a> <a class="mini-button" id="cancel" onclick="onCancel"
                        style="width: 60px;">取消</a>
        </div>
    </div>
    </form>

    <script type="text/javascript">
       
       var form = new mini.Form("form1");
        var formData = {};
        var btnEdit1 = mini.get("btnEdit1");
        var editor1;
	    KindEditor.ready(function(K) {
			editor1 = K.create('#Explain', {
				cssPath : '../Admin/kindeditor/plugins/code/prettify.css',
				uploadJson : '../Admin/kindeditor/asp.net/upload_json.ashx',
				fileManagerJson : '../Admin/kindeditor/asp.net/file_manager_json.ashx',
				allowFileManager : true,
				afterCreate : function() {
					var self = this;
					K.ctrl(document, 13, function() {
						self.sync();
						K('form[name=form1]')[0].submit();
					});
					K.ctrl(self.edit.doc, 13, function() {
						self.sync();
						K('form[name=form1]')[0].submit();
					});
				}
			});
			prettyPrint();
		});


    </script>

</asp:Content>
