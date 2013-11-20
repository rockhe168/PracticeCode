<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="PayAliPay.aspx.cs"
    Inherits="Member_PayAliPay" Title="支付宝-付款" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />
    <link href="../css/AliPay.css" rel="stylesheet" type="text/css" />
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
                        <li class="current">1、确认付款信息 →</li>
                        <li>2、付款 →</li>
                        <li class="last">3、付款完成</li>
                    </ol>
                </div>
                <div id="body" style="clear: left">
                    <dl class="content1">
                        <dt>订单号：</dt>
                        <dd>
                            <span class="red-star">*</span>
                            <input type="text" id="TxtSubject" name="TxtSubject" /><span>如：7月5日定货款。</span>
                        </dd>
                        <dt>付款金额：</dt>
                        <dd>
                            <span class="red-star">*</span>
                            <input type="text" id="TxtTotal_fee" name="TxtTotal_fee" value="00.00" onfocus="if(Number(this.value)==0){this.value='';}"
                                maxlength="10" />
                            <span>如：112.21</span>
                        </dd>
                        <dt>备注：</dt>
                        <dd>
                            <span class="null-star">*</span>
                            <textarea id="TxtBody" name="TxtBody" rows="3" maxlength="100" cols="90"></textarea>
                            <br />
                            <span>（如联系方法，商品要求、数量等。100汉字内）</span>
                        </dd>
                        <dt></dt>
                        <dd>
                            <span class="new-btn-login-sp">
                                <input type="button" id="BtnAlipay" name="BtnAlipay" class="new-btn-login" value="确认付款"
                                    style="text-align: center" />
                            </span>
                        </dd>
                    </dl>
                </div>
                <div id="foot1">
                    <ul class="foot-ul">
                        <li><font class="note-help">如果您点击“确认付款”按钮，即表示您同意向卖家购买此物品。
                            <br />
                            您有责任查阅完整的物品登录资料，包括卖家的说明和接受的付款方式。卖家必须承担物品信息正确登录的责任！ </font></li>
                        <li>支付宝版权所有 2011-2015 ALIPAY.COM </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
