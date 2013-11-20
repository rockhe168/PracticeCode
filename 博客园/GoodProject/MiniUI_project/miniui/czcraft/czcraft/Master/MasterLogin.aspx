﻿<%@ Page Language="C#" MasterPageFile="~/Top_Down.master" AutoEventWireup="true" CodeFile="MasterLogin.aspx.cs" Inherits="Master_MasterLogin" Title="大师登陆" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../js/AjaxJsDeal/MasterRegister.js" type="text/javascript"></script>
<script type="text/javascript">
$(function(){
CheckUserName();
Login();
CheckLogin();
});
      
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="content">
    <div class="left_side">
        <div class="logo_bottom"></div>       
    </div>
</div>
<div class="content">
    <div class="denglu">
        <div class="dl_title"><p class="hide">用户登录</p></div>
        <div class="dl_table">
            <table width="300">
                  <tr>
                       <td width="85" class="zc_tar">用户名：</td>
                       <td width="206" class="zc_tal"><input type="text" name="txtUserName"  id="txtUserName" class="zc_input1"/></td>
                  </tr>
                  <tr>
                       <td class="zc_tar">密码：</td>
                       <td class="zc_tal"><input type="password" id="txtPwd" name="txtPwd" class="zc_input2" /></td>
                  </tr>                  
             </table>
             <table width="308">
                  <tr>
                       <td width="64">&nbsp;</td>
                       <td width="90"><input type="checkbox" id="cbUserName" name="cbUserName" /><span>记住用户名</span></td>
                       <td width="90" class="zc_tar"><input type="checkbox" name="cbPwd" id="cbPwd" /><span>记住密码</span></td>
                       <td width="64">&nbsp;</td>   
                  </tr>
                  <tr>
                       <td>&nbsp;</td>
                       <td><a href="#" id="aLogin"><img src="../images/dl_sumbit.png" /></a></td>
                       <td class="zc_tar"><a href='<%=URLManage.GetURL("~/MasterZone/ForgetSercret","")%>'>忘记密码？</a></td>
                       <td>&nbsp;</td>   
                  </tr>
             </table>
             <table width="250" class="tr_border">
                  <tr>
                       <td align="center">还不是大师？请点击这里<a href='<%=URLManage.GetURL("~/Master/MasterRegister","")%>'><img src="../images/dl_zc.png" /></a></td>   
                  </tr>
             </table>
      </div>
    </div>
</div>

</asp:Content>

