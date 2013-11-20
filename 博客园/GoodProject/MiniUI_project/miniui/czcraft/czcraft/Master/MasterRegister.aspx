﻿<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true"
    CodeFile="MasterRegister.aspx.cs" Inherits="Master_MasterRegister" Title="注册大师" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>
    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>
        <script src="../Admin/Scripts/PluginForm.js" type="text/javascript"></script>
    <script src="../Admin/Scripts/jquery.MultiFile.pack.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/MasterRegister.js" type="text/javascript"></script>
    <script type="text/javascript">
      var IsCheck=false;
      var DefaultURL='<%=URLManage.GetURL("~/Default","")%>';
      var MasterInfoURL='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>';
      var MasterLoginURL='<%=URLManage.GetURL("~/Master/MasterLogin","")%>';
      $(function(){
      $("#form1").validationEngine();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<form id="form1">
    <div class="right_side c_zhuce">
        <div class="c_zhuce_title m_zhuce_title">
            <p class="hide">
                注册新大师</p>
        </div>
        <div class="c_zhuce_p">
            <table width="364" class="c_zc_table1">
                <tr>
                    <td width="82" class="zc_tar">
                        用户名：
                    </td>
                    <td width="270" class="zc_tal" >
                        <input type="text" class="zc_input1 validate[required,custom[LoginName]]"  id="txtUserName" /> <label id="ShowExist"></label></td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        密码：
                    </td>
                    <td class="zc_tal">
                        <input type="password" class="zc_input2 validate[required,custom[LoginPwd]]" id="txtPwd" />
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        确认密码：
                    </td>
                    <td class="zc_tal">
                        <input type="password" class="zc_input3 validate[required,equals[txtPwd]]"  />
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        出生年月：
                    </td>
                    <td class="zc_tal">
                        <input type="text" class="zc_input10 validate[custom[date]]"  id="txtBirthday"/>
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        真实姓名：
                    </td>
                    <td class="zc_tal">
                        <input type="text" class="zc_input10 validate[maxSize[20]]" id="txtName" />
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        性别：
                    </td>
                    <td class="zc_tal">
                        <input type="radio" name="Sex" id="Man" checked="checked" class="zc_input9" />男&nbsp;&nbsp;<input type="radio" class="zc_input9" name="Sex" id="Woman" />女
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        手机号码：
                    </td>
                    <td class="zc_tal">
                        <input type="text" class="zc_input10 validate[custom[Mobile]]" id="txtMobilePhone" />
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        电话号码：
                    </td>
                    <td class="zc_tal">
                        <input type="text" class="zc_input10 validate[custom[phone]]" id="txtTelePhone" />
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        E-mail：
                    </td>
                    <td class="zc_tal">
                        <input type="text" class="zc_input4 validate[required,custom[email]]" id="txtEmail" />
                    </td>
                </tr>
                <tr>
                    <td class="zc_tar">
                        Q Q：
                    </td>
                    <td class="zc_tal">
                        <input type="text" class="zc_input10 validate[custom[QQ]]" id="txtQQ" />
                    </td>
                </tr>
              
              
            </table>
            <div class="zc_img">
                <img src="../images/zc_img.gif" id="imgpic" alt="木有头像、赶紧上传" />
                <div class="zc_img_sc">
                    <!--图片上传按钮，sc=shangchuan=上传-->
                      <input class="multi zc_img_input1" style=" width:180px" type="file" id="fileupload"  name="fileupload" maxlength="1" accept="gif|jpg|bmp|png"/  />
     <input type="hidden" name="Picturepath"  id="Picturepath"/>
                 <%--   <input type="text" class="zc_img_input1" />--%><input type="button" value="上传" class="zc_img_input2"  onclick="onUpload()"/>
                    
                </div>
            </div>
            <div class="zc_jianjie">
                <p>
                    大师简介</p>
                <div class="multi">
                    <textarea id="txtIntroduce"></textarea></div>
                <table>
                    <tr>
                        <td width="60" class="zc_tar">
                            验证码：
                        </td>
                        <td width="340" class="zc_tal">
                            <input type="text" class="zc_input5 validate[required]"  id="txtCheckCode"/><img src="../Admin/FileManage/VerifyChars.ashx" alt="验证码" onclick="changeImg()" id="img"/>
                        </td>
                        <td width="100" class="zc_tar">
                            <a href="javascript:CheckForm1()" id="txtSubmit">
                                <img src="../images/zhuce_sumbit.png" /></a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
