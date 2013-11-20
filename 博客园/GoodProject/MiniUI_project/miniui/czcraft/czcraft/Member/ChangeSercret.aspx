<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="ChangeSercret.aspx.cs" Inherits="Member_ChangeSercret" Title="修改密码" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../Admin/css/template.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/MemberZoneInfo.js" type="text/javascript"></script>
<script type="text/javascript">
        $(function(){
        $("#form1").validationEngine();
        $("#btnUpdate").click(function(){
           //如果验证不通过,就不提交
        if(!$("#form1").validationEngine('validate'))
        return;
         //修改密码
         ChangeSercret();
         });
          });
        
          
        
   
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <form id="form1">
  <div class="zz">
        <div class="xgmm">
            <div class="xgmm_tt"><h3>修改密码</h3></div>
            <p class="xgmm_tip">密码由6-15个字符组成，为了您账号的安全，禁止使用全数字或连续字符作为密码。</p>
            <ul class="xgmm_ul">
                <li class="xgmm_ul_li1"><span>当前密码：</span><input type="text" class="xgmm_text validate[required,custom[LoginPwd]]" name="txtOldPwd"  id="txtOldPwd"/> </li><%----%>

                <li><span>新密码：</span><input type="text" class="xgmm_text validate[required,custom[LoginPwd]]"  id="txtNewPwd"/></li>
                <li><span>确认密码：</span><input type="text" class="xgmm_text validate[required,equals[txtNewPwd]]" id="txtConfirmPwd" /></li>
                <li class="xgmm_bt"><input type="button" class="xgmm_bt1" id="btnUpdate" /><input type="reset" value="" class="xgmm_bt2" /></li>
            </ul>
        </div>
    </div>    </form>
</asp:Content>

