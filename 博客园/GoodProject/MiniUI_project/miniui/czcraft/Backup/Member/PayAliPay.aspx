<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="PayAliPay.aspx.cs"
    Inherits="Member_PayAliPay" Title="֧����-����" %>

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
                        <li class="current">1��ȷ�ϸ�����Ϣ ��</li>
                        <li>2������ ��</li>
                        <li class="last">3���������</li>
                    </ol>
                </div>
                <div id="body" style="clear: left">
                    <dl class="content1">
                        <dt>�����ţ�</dt>
                        <dd>
                            <span class="red-star">*</span>
                            <input type="text" id="TxtSubject" name="TxtSubject" /><span>�磺7��5�ն����</span>
                        </dd>
                        <dt>�����</dt>
                        <dd>
                            <span class="red-star">*</span>
                            <input type="text" id="TxtTotal_fee" name="TxtTotal_fee" value="00.00" onfocus="if(Number(this.value)==0){this.value='';}"
                                maxlength="10" />
                            <span>�磺112.21</span>
                        </dd>
                        <dt>��ע��</dt>
                        <dd>
                            <span class="null-star">*</span>
                            <textarea id="TxtBody" name="TxtBody" rows="3" maxlength="100" cols="90"></textarea>
                            <br />
                            <span>������ϵ��������ƷҪ�������ȡ�100�����ڣ�</span>
                        </dd>
                        <dt></dt>
                        <dd>
                            <span class="new-btn-login-sp">
                                <input type="button" id="BtnAlipay" name="BtnAlipay" class="new-btn-login" value="ȷ�ϸ���"
                                    style="text-align: center" />
                            </span>
                        </dd>
                    </dl>
                </div>
                <div id="foot1">
                    <ul class="foot-ul">
                        <li><font class="note-help">����������ȷ�ϸ����ť������ʾ��ͬ�������ҹ������Ʒ��
                            <br />
                            �������β�����������Ʒ��¼���ϣ��������ҵ�˵���ͽ��ܵĸ��ʽ�����ұ���е���Ʒ��Ϣ��ȷ��¼�����Σ� </font></li>
                        <li>֧������Ȩ���� 2011-2015 ALIPAY.COM </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
