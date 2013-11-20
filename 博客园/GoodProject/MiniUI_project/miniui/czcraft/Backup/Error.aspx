<%@ Page Language="C#" MasterPageFile="~/Top_Down.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" Title="出错了" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/gr.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">
    <div class="left_side">
        <div class="logo_bottom"></div>
    </div>
    <div class="zz">
        <div class="xgmm">
            <div class="xgmm_tt"><h3>出错了!</h3></div>
            <p class="xgmm_tip"></p>
            <ul class="xgmm_ul">
               <li></li>
                <li class="zhmm_yz" style=" text-align:center; font-size:large; color:Red;  font-weight:bold"><asp:Literal ID="ltError"  runat="server">对不起,页面未找到!</asp:Literal></li>
                <li style=" text-align:center"><a href='<%=URLManage.GetURL("~/Default","")%>' runat="server" id="aURL" >返回</a></li>
             <li></li>
            </ul>
        </div>
    </div>
</div>

</asp:Content>

