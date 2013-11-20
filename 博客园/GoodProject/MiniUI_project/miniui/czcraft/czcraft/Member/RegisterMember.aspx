﻿<%@ Page Language="C#" MasterPageFile="~/Top_Down.master" AutoEventWireup="true" CodeFile="RegisterMember.aspx.cs" Inherits="Member_RegisterMember" Title="注册用户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Admin/css/template.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/MemberZoneInfo.js" type="text/javascript"></script>
    
    <script type="text/javascript">
     var IsCheck=false;

    $(function(){
			// binds form submission and fields to the validation engine
			$("#form1").validationEngine();
			CheckUserName();
		});

		 </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" method="post">
    <div class="content">
    <div class="left_side">
        <div class="logo_bottom"></div>       
    </div>
    <div class="right_side zhuce">
        <div class="zhuce_title"><p class="hide">注册新用户</p></div>
        <div class="zhuce_p">
            <table width="578" class="zc_table1">
                  <tr>
                      <td width="93" class="zc_tar">用户名：</td>
                      <td width="200" class="zc_tal"><input type="text" class="zc_input1 validate[required,custom[LoginName]] text-input" name="txtUserName" id="txtUserName"/><!--LoginName-->
</td>
                      <td width="269" class="zc_font" id="tdUser"></td>
                  </tr>
                  <tr>
                      <td class="zc_tar">密码：</td>
                      <td class="zc_tal"><input type="password" class="zc_input2  validate[required,custom[LoginPwd]] text-input"  id="txtPwd" name="txtPwd"/></td>
                      <td class="zc_font"></td>
                  </tr>
                  <tr>
                      <td class="zc_tar">确认密码：</td>
                      <td class="zc_tal"><input type="password" class="zc_input3 validate[required,equals[txtPwd]] text-input" /></td>
                      <td class="zc_font"></td>
                  </tr>
                  <tr>
                      <td class="zc_tar">E-mail：</td>
                      <td class="zc_tal"><input type="text" class="zc_input4 validate[required,custom[email]] text-input"  name="txtEmail" id="txtEmail"/></td>
                      <td class="zc_font"></td>
                  </tr>
                  <tr>
                      <td class="zc_tar">验证码：</td>
                      <td class="zc_tal" colspan="2"><input type="text" class="zc_input5 validate[required]"  name="txtCheckCode" id="txtCheckCode"/><img src="../Admin/FileManage/VerifyChars.ashx" onclick="changeImg()" id="img" alt="验证码" /></td>
                  </tr>
                  <tr><td>&nbsp;</td></tr>
                  <tr>
                      <td colspan="3" align="center"><a href="javascript:CheckForm1()"><img src="../images/zhuce_sumbit.png" /></a></td>
                  </tr>
              </table>
      </div>
    </div>
</div>
</form>
</asp:Content>

