<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="PayCallBack.aspx.cs"
    Inherits="Member_PayCallBack" Title="支付回调" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />
      <link href="../css/AliPay.css" rel="stylesheet" type="text/css" />
       <script src="../js/queryUrlParams.js" type="text/javascript"></script>

<style type="text/css">
  .MoneyFont
  {
  	font-family:Verdana, Geneva, sans-serif;
	font-size:18px;
	font-weight:bold;
	color:#F60;
  }
  	
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div class="zz">
        <div class="gouwuche">
            <div class="flow-steps">
                <ul class="num5">
                    <li class="done"><span class="first">1. 查看购物车</span></li>
                    <li class="done current-prev"><span>2. 确认订单信息</span></li>
                    <li class="current"><span>3. 付款到支付宝</span></li>
                    <li><span>4. 确认收货</span></li>
                    <li class="last"><span>5. 评价</span></li>
                </ul>
            </div>
            <div id="main">
                <div id="head">
                    <div id="logo">
                    </div>
                    <dl class="alipay_link">
                        <a target="_blank" href="http://www.alipay.com/"><span>支付宝首页</span></a>| <a target="_blank"
                            href="https://b.alipay.com/home.htm"><span>商家服务</span></a>| <a target="_blank" href="http://help.alipay.com/support/index_sh.htm">
                                <span>帮助中心</span></a>
                    </dl>
                    <span class="title">支付宝纯担保交易付款快速通道</span>
                    <!--<div id="title" class="title">支付宝纯担保交易付款快速通道</div>-->
                </div>
                <div class="cashier-nav">
                    <ol>
                        <li>1、确认付款信息 →</li>
                        <li>2、付款 →</li>
                        <li class="last current">3、付款完成</li>
                    </ol>
                </div>
                <div id="body" style="clear: left">
                    <dl class="content1">
                        <dt>订单号：</dt>
                        <dd>
                           
                            <span id="OrderId"></span>
                        </dd>
                        <dt>付款金额：</dt>
                        <dd>
                       
                            ￥:<span  class="MoneyFont" id="PayFre"></span>
                        </dd>
                        <dt>支付状态：</dt>
                        <dd>
                          
                  <span style="color:Red" id="Msg"></span>
                        </dd>
                        <dt></dt>
                        <dd>
                            <span class="new-btn-login-sp">
                                <input type="button" id="BtnAlipay" name="BtnAlipay" class="new-btn-login" value="确认收货"
                                    style="text-align: center" />
                            </span>
                        </dd>
                    </dl>
                </div>
                <div id="foot1">
                    <ul class="foot-ul">
                        <li>支付宝版权所有 2011-2015 ALIPAY.COM </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
         //获得回调过来的信息
         $(function(){
     var ReturnCode=$.query.get("ReturnCode"); 
     var Msg=$.query.get("Msg");
     var OrderId=$.query.get("OrderId");
     var PayFre=$.query.get("PayFre");
         if(ReturnCode=="ok")
         $("#Msg").text("恭喜您,支付成功!我们会尽快发货!如果您收货就可以继续确认收货!");
         else
         $("#Msg").text("对不起,支付失败!!失败信息 :"+Msg+"请联系支付宝有关人员!");
        $("#OrderId").text(OrderId);
         $("#PayFre").text(PayFre);
         $("#BtnAlipay").click(function(){
         window.location.href="ComfirmGetGoods.aspx";
         
         });
         });
    
     
    </script>
</asp:Content>
