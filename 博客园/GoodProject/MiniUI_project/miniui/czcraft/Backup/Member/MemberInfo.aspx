<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="MemberInfo.aspx.cs"
    Inherits="Member_MemberInfo" Title="会员信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <link href="../Admin/css/template.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>
   
    <script src="../js/AjaxJsDeal/MemberInfo.js" type="text/javascript"></script>
  <script type="text/javascript">
  $(function(){
  $("#form1").validationEngine();
      //省市数据初始化
        GetProvince();
        //获取民族信息
        GetNation();
        //绑定事件  
        $("#selProvince").change(function(){
        GetCity();
        });
        $("#selCity").change(function(){
        GetCountry();
        });
        GetUserInfo();
 	
 
  });
 
  
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<form  id="form1" >
    <div class="zz">
        <div class="xgmm">
            <div class="xgmm_tt">
                <h3>
                    个人信息设置</h3>
            </div>
            <p class="xgmm_tip">
                温馨提示您：内容填写完后请仔细核对。</p>
            <h4 class="grxx_h4">
                会员信息</h4>
            <ul class="xgmm_ul grxx_ul1">
                <li><span>用户名：</span><span><input type="text" id="txtUserName" name="txtUserName"
                    disabled="disabled" /></span></li>
                <li class="zhmm_radio"><span>性别：</span><input type="radio" id="Man" checked="checked" name="sex" />男<input
                    type="radio" name="sex" id="Woman" />女</li>
                <li><span>民族：</span><select id="selNational"></select></li>
                <li><span>QQ：</span><input type="text" id="txtQQ" name="txtQQ" class="xgmm_text validate[required,custom[QQ]] text-input" /></li>
                <li><span>E-mail：</span><input type="text" id="txtEmail" name="txtEmail" class="xgmm_text validate[required,custom[email]] text-input"  disabled="disabled" />
                    (已绑定 <%--| <a id="aChangeEmail" href="#" onclick="ChangeEmail()">更改</a>--%>) </li>
            </ul>
            <h4 class="grxx_h4">
                地址设置</h4>
            <ul class="xgmm_ul grxx_ul1">
                <li><span>所在地区：</span>
                    <select id="selProvince" name="selProvince" class="validate[required]" style="width:100px">
                   
                    </select>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="selCity" name="selCity" class="validate[required]" style="width:100px">
                    
                    </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="selCountry" name="selCountry" class="validate[required]" style="width:100px">
                   
                    </select>
                </li>
                <li><span>街道地址：</span><input type="text" id="txtHomeBase" name="txtHomeBase" class="grxx_text1" />
                    (不需要重复填写省市地区)</li>
                <li><span>邮编：</span><input type="text" id="txtZipCode" name="txtZipCode" class="grxx_text2 validate[required,custom[Zipcode]] text-input" /></li>
                <li><span>手机号码：</span><input type="text" id="txtMobilePhone" name="txtMobilePhone"
                    class="xgmm_text validate[required,custom[Mobile]] text-input" /></li>
                <li><span>电话号码：</span><input type="text" 
                id="txtTelPhone" name="txtTelPhone"  class="xgmm_text validate[required,custom[phone]] text-input" />
                    (格式：区号-电话号码)</li>
                <li class="xgmm_bt">
                    <input type="button" id="btnUpdate" class="xgmm_bt1" onclick="Comit()" /><%--<input type="reset" value="" class="xgmm_bt2" />--%></li>
            </ul>
        </div>
    </div>
    </form>
</asp:Content>
