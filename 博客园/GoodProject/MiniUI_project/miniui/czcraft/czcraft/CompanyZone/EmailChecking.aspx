<%@ Page Language="C#" MasterPageFile="~/CompanyZone.master" AutoEventWireup="true" CodeFile="EmailChecking.aspx.cs" Inherits="CompanyZone_EmailChecking" Title="邮箱激活" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
.Size
{
	Height:22px; 
	Width:185px;
}
</style>
<link href="../css/gr.css" rel="stylesheet" type="text/css" />
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
<script src="../js/jquery.validationEngine.js" type="text/javascript"></script>
<script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>
 <script src="../js/queryUrlParams.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/CompanyRegister.js" type="text/javascript"></script>
<script type="text/javascript">
//从url中获取用户名和密码
    var UserName=$.query.get("UserName"); 
    var VCode=$.query.get("YZM");
    var Data={"UserName":UserName,"VCode":VCode};
$(function(){
	EmailChecking();

});

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <form id="form1">
  <div class="zz" style="margin-left:250px">
        <div class="xgmm">
            <div class="xgmm_tt"><h3>邮箱验证</h3></div>
            <p class="xgmm_tip">邮箱验证状态:<label id="lbStatus"></label></p>              <ul class="xgmm_ul">
                <li class="xgmm_ul_li1"><label id="lbInfo"></label></li>

            
            </ul>
          
        </div>
    </div>    </form>
</asp:Content>



