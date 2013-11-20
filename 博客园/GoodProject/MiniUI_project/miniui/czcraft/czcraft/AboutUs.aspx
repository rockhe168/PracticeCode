<%@ Page Language="C#" MasterPageFile="~/Top_Down.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" Title="关于我们" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link href="css/other.css" rel="stylesheet" type="text/css" /> <script type="text/javascript">
    $(function(){
      //获取关于我们的信息
    GetOutInfo();
    });
   
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">

    <div class="left_side">

        <div class="logo_bottom"></div>       

    </div>

    <div class="us"></div>

    <div class="us_fs">

        <div class="us_b"></div>

        <div class="us_c">

            <div class="uc1">

                <h3><p class="hide">在线客服</p></h3>

                <ul id="ulContact">

                    <li class="us_11">QQ:123456789&nbsp;&nbsp;&nbsp;&nbsp;<a class="rad2" target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=455619311&site=qq&menu=yes">点击在线聊天</a></li>

                    <li class="us_12">TEL:28281688</li>

                    <li class="us_13">Mobile:13528281688</li>

                </ul>

            </div>

            <div class="uc2">

              <h3><p class="hide">其他方式</p></h3>

              <ul id="ulContactOther">

                  <li class="us_21">联系地址：广东省潮州市湘桥区</li>

                  <li class="us_22">邮政编码：515100</li>

                  <li></li>

                 

              </ul>

            </div>

            <div class="uc3">

              <h3><p class="hide">我们的承诺</p></h3>

              <ul>

                  <li>1 、我们承诺在购物全程照顾您。</li>

                  <li>2 、我们承诺为您提供公平，公正，透明的交易平台。</li>

                  <li>3 、我们承诺在您需要的时候能够快捷地找到我们，我们始终在您身边。</li>

                  <li>4 、我们承诺一心一意地为您提供舒适、满意的服务。</li>

                  <li>5 、我们承诺用公平公正的态度处理您的交易纠纷，保障您在购物过程中的权益。</li>

              </ul>

          </div>

        </div>

        <div class="us_b"></div>

    </div>

</div>

</asp:Content>

