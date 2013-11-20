<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="ForgetSercret.aspx.cs" Inherits="Member_ForgetSercret" Title="找回密码" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../js/AjaxJsDeal/MemberZoneInfo.js" type="text/javascript"></script>
      <script type="text/javascript">
      function changeImg(){
      $("#img").attr("src","../Admin/FileManage/VerifyChars.ashx?date="+new Date());
      
      }
     $(function(){
            $("#btnSend").click(function(){
           ForgetSercret();
         });
        });
       
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="zz">
        <div class="xgmm">
            <div class="xgmm_tt"><h3>找回密码</h3></div>
            <p class="xgmm_tip">请记住:找回密码功能可以根据您的用户名和最初注册的邮箱将重置密码发送到您的邮箱!然后您尽快修改自己的密码!</p>
            <ul class="xgmm_ul">
                <li class="xgmm_ul_li1"><span>用户名：</span><input type="text" class="xgmm_text" id="txtUserName" /></li>
                <li class="xgmm_ul_li1"><span>邮箱：</span><input type="text" class="xgmm_text" id="txtEmail" /></li>
                <li class="zhmm_yz"><span>验证码：</span><input type="text"  id="txtCheckCode"/><img src="../Admin/FileManage/VerifyChars.ashx" onclick="changeImg()" id="img" alt="验证码" /></li>
                <li><input type="button" class="xgmm_bt3" id="btnSend" /></li>
            </ul>
        </div>
    </div>
</asp:Content>

