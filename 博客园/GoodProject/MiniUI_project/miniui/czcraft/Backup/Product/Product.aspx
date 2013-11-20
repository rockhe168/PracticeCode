<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true"
    CodeFile="Product.aspx.cs" Inherits="Product_Product" Title="产品信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/gs_ms.css" rel="stylesheet" type="text/css" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />
    <script src="../js/queryUrlParams.js" type="text/javascript"></script>

  
    <script type="text/javascript" src="../js/tabchoose.js"> </script>
    <script src="../js/fangdajing.base.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/fangdajing_canshu.js"></script>
    <script src="../js/fangdajing.lib.js" type="text/javascript"></script>
    <script src="../js/fangdajing.js" type="text/javascript"></script>

    <script src="../js/users.js" type="text/javascript"></script>
      <script src="../js/AjaxJsDeal/ProductShow.js" type="text/javascript"></script>

<script type="text/javascript">
 var id=$.query.get("ProductId");
    var MasterInfoURL='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>';
   
    var CompanyInfoURL='<%=URLManage.GetURL("~/CompanyZone/CompanyInfo","")%>';
  $(function(){
  //获取产品信息
    GetProductInfo(id);
   //加入购物车
   AddCart(id)
   AddCollection(id);
   });
  

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<!--隐藏字段-->
<input type="hidden" id="SupperlierName" />
    <div class="ap">
        <div class="fangda">
            <div id="preview">
                <div class="ap_img">
                    <div class="jqzoom" id="spec-n1">
                        <img src="#" id="CurrentPic" jqimg="#" /></div>
                    <div class="ap_360">
                        <a href="#" id="btnShowBig"/>
                            <img src="../images/ap_360.png" alt="360度旋转"  /></a></div>
                </div>
                <div class="ap_p">
                    <h3>
                        <p id="pTitle">
                            梅兰菊竹大家闺秀</p>
                    </h3>
                    <table id="tbProductInfo">
                     
                    </table>
                    <ul class="ap_p_ul">
                       <%-- <li class="ap_input1">
                            <input type="button" value=" "alt="点击购买" />
                           </li>--%>
                        <li class="ap_input2">
                            <input type="button" value=" " id="btnAddCart"   alt="加入购物车" /></li>
                        <li class="ap_input3">
                            <input type="button" value=" " alt="收藏"  id="btnAddCollection"/></li>
                    </ul>
                </div>
                <div id="spec-n5">
                    <div class="control" id="spec-left">
                        <img src="../images/ap_left.png" /></div>
                    <div id="spec-list">
                        <ul class="list-h" id="ulOtherPic">
                        <%ReponseProductPic(); %>
              
                      
                        </ul>
                    </div>
                    <div class="control" id="spec-right">
                        <img src="../images/ap_right.png" /></div>
                </div>
            </div>
              
        </div>
        	<!--加一个登录层-->
        	 <div id="divLogin" style="display: none">
            <div class="loginbox">
                <a href="javascript:ShowNo();">
                    <img src="../images/del1.gif"  style="float:right;" /></a>
               <p>
                    宝贝已成功添加到购物车！</p>
                   
                <div class="jiezhang">
                    <p id="CartMsg">
                      <%--  目前购物车中已有<label id="lbCartCount"></label>件宝贝，合计：<span><label id="lbCartSum"></label></span>元--%></p>
                    <p>
                        <a href='<%=URLManage.GetURL("~/Member/ShopingCart","")%>'>
                            <img src="../images/jiezhang.jpg"  style="float:right"/></a></p>
                </div>
            </div>
          </div>
   
        <div class="ap_tab">
            <ul class="mt" id="TabPage1">
                <li id="Tab11" class="Selected"><a href="#" onmouseover="javascript:switchTab1('TabPage1','Tab11');">
                    产品详情 </a></li>
                <%--<li id="Tab12"><a href="#" onmouseover="javascript:switchTab1('TabPage1','Tab12');">
                    产品评论 </a></li>--%>
            </ul>
            <div id="cnt1">
                <div id="dTab11" class="HackBox" style="display: block">
                    <h3 class="ap_ly_t2">
                        <p class="hide">
                            产品详情</p>
                    </h3>
                    <span class="ap_xq" id="ProductIntro">
                       
                       </span>
                </div>
           <%--   <div id="dTab12" class="HackBox" style="display: none">
                    <h3 class="ap_ly_t2">
                        <p class="hide">
                            产品评论</p>
                    </h3>
                    <span class="ap_ly">
                        <table width="520">
                            <tr>
                                <td width="49" class="zc_tal">
                                    姓名：
                                </td>
                                <td width="120" class="zc_tal">
                                    <input type="text" value=" " id="txtUserName" class="ap_input4" />
                                </td>
                                <td width="55" class="zc_tar">
                                    QQ：
                                </td>
                                <td width="120" class="zc_tal">
                                    <input type="text" value=" " id="txtQQ" class="ap_input4" />
                                </td>
                                <td width="55" class="zc_tar">
                                    电话：
                                </td>
                                <td width="120" class="zc_tal">
                                    <input type="text" value=" " id="txtMobilePhone" class="ap_input4" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" class="zc_tal">
                                    留言内容：
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <textarea name="textarea" id="txtContent"></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td>
                                    验证码：
                                </td>
                                <td class="zc_tal">
                                    <input type="text" value=" " id="txtCheckCode" class="ap_input5" />
                                </td>
                                <td class="zc_tal">
                                    <img src="../Admin/FileManage/VerifyChars.ashx"  id="imgCode"/>
                                </td>
                                <td class="zc_tar">
                                    <input type="button" value=" " alt="提交" id="btnComit" class="ap_input6" />
                                </td>
                            </tr>
                        </table>
                    </span>
                </div>--%>
            </div>
        </div>
    </div>
</asp:Content>
