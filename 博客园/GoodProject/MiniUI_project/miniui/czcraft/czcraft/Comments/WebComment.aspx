<%@ Page Language="C#" MasterPageFile="~/Left_Top_Dwon.master" AutoEventWireup="true"
    CodeFile="WebComment.aspx.cs" Inherits="Comments_WebComment" Title="在线留言" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/other.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/template.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>

    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>

    <script type="text/javascript">
      function changeImg(){
      $("#img").attr("src","../Admin/FileManage/VerifyChars.ashx?date="+new Date());
      }
     $(function(){
     $("#form1").validationEngine();
     });
     //留言
    function Comit(){
    $("#btncomit").click(function(){
    
    var Data={"UserName":$("#txtUser").val(),"TelePhone":$("#txtTelePhone").val(),"Email":$("#txtEmail").val(),"CheckCode":$("#txtCheckCode").val(),"Content":$("#txtContent").val()};
		     $.ajax({ 
            url:"/Comments/Data/CommentInfo.ashx?method=SaveWebComment", 
            type:"post", 
            data:Data, 
            success:function(ReturnData){ 
              var DataJson=$.parseJSON(ReturnData);
              if(DataJson.Status=='True') 
              { 
                alert(DataJson.Data+"我们的会尽快把您的意见反馈信息发送到您的邮箱!");
                window.location.href="../Default.aspx";
              } 
              else{ 
              alert("留言失败!"+DataJson.Data); 
              } 
             
            } 
             
         }); 
    
    });
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1">
    <div class="liuyan">
        <div class="list_title">
            <h4>
                在线留言</h4>
            <span>当前位置：<a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > 在线留言</span></div>
        <p class="ly_p">
            如果您需要什么帮助或者建议，请填写以下表单，我们将在最短时间内答复</p>
        <ul class="ly_ul">
            <li class="ly_li1"><span>用户名：</span><input type="text"    id="txtUser"  class="validate[required]" name="txtUserName" />
            </li>
            <li class="ly_li2"><span>联系电话：</span><input type="text" class="validate[required,custom[Mobile]]"
                id="txtTelePhone"  name="txtTelePhone"/></li>
            <li class="ly_li3"><span>E—mail：</span><input type="text" class="validate[required,custom[email]]"
                id="txtEmail"  name="txtEmail"/></li>
            <li class="ly_li4"><span>留言内容：</span><textarea class="validate[required,maxSize[200]]"
                id="txtContent" name="txtContent"></textarea></li>
            <li><span>验证码：</span><input style="width: 100px;" class="validate[required]" type="text"
                id="txtCheckCode" name="txtCheckCode" /><img src="../Admin/FileManage/VerifyChars.ashx" id="img" onclick="changeImg()" /></li>
            <li class="ly_li5">
                <input type="button" class="ly_sumbit" id="btncomit" name="submit"  onclick="Comit()"/></li>
        </ul>
    </div>
    </form>
</asp:Content>
