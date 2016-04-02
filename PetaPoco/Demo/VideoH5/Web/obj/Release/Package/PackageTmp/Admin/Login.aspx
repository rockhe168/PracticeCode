<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
    <title>登&nbsp;&nbsp;录</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Le styles -->
    <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
	<link href="css/login.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
</head>
<body>
     <div class="container">
         <form id="form1" class="form-signin" runat="server">
        <h2 class="form-signin-heading">登录</h2>
		       姓名： <input type="text" id="txtUserName"  name='user' value=''  class="input-block-level" placeholder="请输入姓名" runat="server">
		       密码： <input type="password" id="txtPass"  name='pass' value=''  class="input-block-level" placeholder="请输入密码" runat="server">
               <%--<button id="btnlogin" type="button">登&nbsp;&nbsp;录</button> &nbsp;&nbsp;--%>
             <asp:Button ID="btnlogin" class="btn btn-large btn-primary"  runat="server" Text="登&nbsp;&nbsp;录" OnClick="btnlogin_Click" />&nbsp;&nbsp;<span visible="false" class='error' id="errorMsg" runat="server">用户名或者密码错误！</span>
         </form>

    </div>

    <script src="bootstrap/js/jquery.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.js" type="text/javascript"></script>
</body>
</html>
