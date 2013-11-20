<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true"
    CodeFile="MasterInfo.aspx.cs" Inherits="Master_MasterInfo" Title="大师信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/gs_ms.css" rel="stylesheet" type="text/css" />

    <script src="../Admin/scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../js/queryUrlParams.js" type="text/javascript"></script>


    <script src="../js/AjaxJsDeal/MasterInfo.js" type="text/javascript"></script>

    
    <script type="text/javascript">
   //获得大师id信息
     var id=$.query.get("MasterId"); 
     var ProductURL='<%=URLManage.GetURL("~/Product/Product","")%>';
     var Master_MoreProductURL='<%=URLManage.GetURL("~/Product/Master_MoreProduct","")%>';
     $(function(){
     GetMasterInfo();
     GetMasterIntro();
     //绑定获取大师简介事件
     $("#Master_Intro").click(function(){
     GetMasterIntro();
     });
     $("#Master_Award").click(function(){
     GetMasterReward();
     });
     $("#Master_Work").click(function(){
     GetMasterWork();
     });
     });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ms">
        <div class="ms_top">
            <div class="m_load">
                <span><a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > <a href='<%=URLManage.GetURL("~/Master/MasterList","")%>'>大师风采</a> > 大师</span></div>
            <div class="mst_c">
                <ul class="mst_ul">
                    <li><a href="#" id="Master_Intro">
                        <p class="hide">
                            大师简介</p>
                    </a></li>
                    <li><a href="#" id="Master_Award">
                        <p class="hide">
                            获奖情况</p>
                    </a></li>
                    <li><a href="#" id="Master_Work">
                        <p class="hide">
                            大师作品</p>
                    </a></li>
                </ul>
                <div class="mst_img">
                    <img src="../images/master_img.png" id="imgMaster" /></div>
                <div class="mst_xx">
                    <table width="252" height="141" id="tbMasterInfo">
                    </table>
                </div>
            </div>
        </div>
        <div class="gs_nr" id="MasterContent">
          
        </div>
    </div>
</asp:Content>
