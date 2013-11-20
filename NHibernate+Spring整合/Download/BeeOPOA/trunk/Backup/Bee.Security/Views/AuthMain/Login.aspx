<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=Bee.SystemConfigManager.Instance.GetConfigValue("SiteName") %>
        ------Bee OPOA 管理平台</title>
    <link href="/themes/default/style.css" rel="stylesheet" type="text/css" />
    <link href="/themes/core.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery-1.7.1.min.js"></script>

    <script type="text/javascript" src="/js/bee.core.js"></script>

    <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0px;
            text-align: left;
        }
        body
        {
            background: #d1ebf8 url(/images/body_bg.jpg) no-repeat;
            padding-top: 240px;
        }
        .clear
        {
            clear: both;
        }
        ul, li
        {
            list-style: none;
        }
        #login
        {
            width: 400px;
            height: 276px;
            margin: 0px auto;
            background: url(/images/login_bg.jpg) repeat-x;
            border: 1px solid #259bdf;
        }
        #login p
        {
            padding: 10px;
            width: 380px;
            float: left;
            font: 18px/36px Arial;
        }
        #login ul
        {
            width: 340px;
            float: left;
            padding: 10px 30px;
        }
        #login li
        {
            width: 340px;
            float: left;
            margin-bottom: 10px;
            text-align: right;
            font: 13px/24px Arial;
        }
        #login li span
        {
            width: 240px;
            float: right;
            text-align: left;
        }
        .inp
        {
            width: 150px;
            height: 22px;
            border: 1px solid #88bdd7;
            background: #fff;
            line-height: 22px;
            padding: 0px 5px;
        }
        .inp2
        {
            width: 60px;
            height: 22px;
            border: 1px solid #88bdd7;
            background: #fff;
            line-height: 22px;
            padding: 0px 5px;
        }
        #login li a
        {
            color: #3d82a4;
        }
        #login li a:hover
        {
            color: #333;
        }
    </style>

    <script type="text/javascript">

        $(document).ready(function() {
            $("input[name='username']").val($(document).cookie("username"));
        });
        function Login() {

            var $form = $("#loginform");
            if ($("input[name='cookie']:checked", $form).length != 0) {
                $form.cookie("username", $("input[name='username']", $form).val());
            }

            $form.submit();
        }

        function ChangeValidImg() {
            $('#validImg').attr('src', '/ValidImage.bee?rnd=' + Math.random());
        }

        $(document).keydown(function() {
            if (event.keyCode == 13) {
                $("#Login").click();
                return false;
            }
        })
        
    </script>

</head>
<body style="background-image: url(/images/loginbj.jpg); background-repeat: repeat;">
    <div id="main" style="margin-top:120px;">
        <form id="loginform" action="/AuthMain/Login.bee" method="post">
        <div id="login">
            <p>
                <%=Bee.SystemConfigManager.Instance.GetConfigValue("SiteName") %>
                <span id="sysversion"><%=Bee.SystemConfigManager.Instance.GetConfigValue("version") %></span></p>
            <ul>
                <li><span>
                    <input name="username" type="text" class="inp" /></span> 用户名：</li>
                <li><span>
                    <input name="password" type="password" class="inp" /></span>密码：</li>
<%--                <li><span>
                    <b style="display:block; float:left; margin-right:5px;"><input name="validid" type="text" class="inp2" /></b>
                     <b style="display:block; float:left;"><a href="javascript:ChangeValidImg();" style="color:Gray;"><img id="validImg" src="/ValidImage.bee?rnd=<%=PageId %>" />看不清</a></b></span>验证码：</li>--%>

                <li><span> <a onclick="javascript:Login();" id="Login"><img src="/images/btn.jpg" /></a></span></li>
                 <li><span> 
                    <%=ViewData["errormsg"]%></span></li>
                <li><span><a title="保存快捷方式时保存路径请选择为您的计算机桌面" href="/SiteShortCut.bee">创建桌面快捷方式</a></span></li>
            </ul>
            
        </form>
    </div>
</body>
</html>
