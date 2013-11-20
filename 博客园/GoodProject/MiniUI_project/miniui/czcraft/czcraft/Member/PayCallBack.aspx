<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="PayCallBack.aspx.cs"
    Inherits="Member_PayCallBack" Title="֧���ص�" %>

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
                    <li class="done"><span class="first">1. �鿴���ﳵ</span></li>
                    <li class="done current-prev"><span>2. ȷ�϶�����Ϣ</span></li>
                    <li class="current"><span>3. ���֧����</span></li>
                    <li><span>4. ȷ���ջ�</span></li>
                    <li class="last"><span>5. ����</span></li>
                </ul>
            </div>
            <div id="main">
                <div id="head">
                    <div id="logo">
                    </div>
                    <dl class="alipay_link">
                        <a target="_blank" href="http://www.alipay.com/"><span>֧������ҳ</span></a>| <a target="_blank"
                            href="https://b.alipay.com/home.htm"><span>�̼ҷ���</span></a>| <a target="_blank" href="http://help.alipay.com/support/index_sh.htm">
                                <span>��������</span></a>
                    </dl>
                    <span class="title">֧�������������׸������ͨ��</span>
                    <!--<div id="title" class="title">֧�������������׸������ͨ��</div>-->
                </div>
                <div class="cashier-nav">
                    <ol>
                        <li>1��ȷ�ϸ�����Ϣ ��</li>
                        <li>2������ ��</li>
                        <li class="last current">3���������</li>
                    </ol>
                </div>
                <div id="body" style="clear: left">
                    <dl class="content1">
                        <dt>�����ţ�</dt>
                        <dd>
                           
                            <span id="OrderId"></span>
                        </dd>
                        <dt>�����</dt>
                        <dd>
                       
                            ��:<span  class="MoneyFont" id="PayFre"></span>
                        </dd>
                        <dt>֧��״̬��</dt>
                        <dd>
                          
                  <span style="color:Red" id="Msg"></span>
                        </dd>
                        <dt></dt>
                        <dd>
                            <span class="new-btn-login-sp">
                                <input type="button" id="BtnAlipay" name="BtnAlipay" class="new-btn-login" value="ȷ���ջ�"
                                    style="text-align: center" />
                            </span>
                        </dd>
                    </dl>
                </div>
                <div id="foot1">
                    <ul class="foot-ul">
                        <li>֧������Ȩ���� 2011-2015 ALIPAY.COM </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
         //��ûص���������Ϣ
         $(function(){
     var ReturnCode=$.query.get("ReturnCode"); 
     var Msg=$.query.get("Msg");
     var OrderId=$.query.get("OrderId");
     var PayFre=$.query.get("PayFre");
         if(ReturnCode=="ok")
         $("#Msg").text("��ϲ��,֧���ɹ�!���ǻᾡ�췢��!������ջ��Ϳ��Լ���ȷ���ջ�!");
         else
         $("#Msg").text("�Բ���,֧��ʧ��!!ʧ����Ϣ :"+Msg+"����ϵ֧�����й���Ա!");
        $("#OrderId").text(OrderId);
         $("#PayFre").text(PayFre);
         $("#BtnAlipay").click(function(){
         window.location.href="ComfirmGetGoods.aspx";
         
         });
         });
    
     
    </script>
</asp:Content>
