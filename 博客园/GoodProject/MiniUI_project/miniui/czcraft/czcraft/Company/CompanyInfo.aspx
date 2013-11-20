<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true"
    CodeFile="CompanyInfo.aspx.cs" Inherits="Company_CompanyInfo" Title="企业展示" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/gs_ms.css" rel="stylesheet" type="text/css" />

    <script src="../js/c_show_pic.js" type="text/javascript"></script>

    <script src="../Admin/scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../js/queryUrlParams.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/CompanyInfo.js" type="text/javascript"></script>

    <script type="text/javascript">
   //获得企业id信息
     var id=$.query.get("CompanyId"); 
     $(function(){
     GetCompanyInfo();
     GetCompanyIntro();
     //绑定获取企业简介事件
     $("#Company_Intro").click(function(){
     GetCompanyIntro();
     });
     $("#Company_Award").click(function(){
     GetCompanyReward();
     });
     $("#Company_Work").click(function(){
     //需要传递2个参数,一个是产品URL,一个是更多企业产品URL
     //调用URLManage.getURL重写定制ajax访问
     GetCompanyWork('<%=URLManage.GetURL("~/Product/Product","")%>','<%=URLManage.GetURL("~/Product/Company_MoreProduct","")%>');
     });
     });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="gs">
        <div class="gs_top">
            <div class="c_load">
                <h4>
                    企业简介</h4>
                <span><a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > <a href='CompanyList.aspx'>企业展示</a> > 企业简介</span></div>
            <div class="gst_c">
                <ul class="gst_ul">
                    <li class="gs_li1"><a href="#" id="Company_Intro">
                        <p class="hide">
                            企业简介</p>
                    </a></li>
                    <li class="gs_li2"><a href="#" id="Company_Work">
                        <p class="hide">
                            企业作品</p>
                    </a></li>
                    <li class="gs_li3"><a href="#" id="Company_Award">
                        <p class="hide">
                            企业荣誉</p>
                    </a></li>
                </ul>
                <div id="myFocus">
                    <div class="loading">
                        <span>请稍候...</span></div>
                    <ul class="pic" id="ulCompanyPic">
                      
                    </ul>
                </div>
            </div>
        </div>
        <div class="gs_nr" id="CompanyContent">
          
        </div>
    </div>
</asp:Content>
