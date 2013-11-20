<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bee OPOA 管理平台</title>
    <link href="/themes/core.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #main{width:760px}
    </style>
</head>
<body>
    <center>
        <div id="main" align="center">
            <div id="center">
                <div id="login_content">
                    <div>
                        <form action="/AuthMain/Login.bee" method="post">
                        <p>
                            <label>
                                用户名：</label>
                            <input type="text" name="username" size="20"/>
                        </p>
                        <p>
                            <label>
                                密码：</label>
                            <input type="password" name="password" size="20"/>
                        </p>
                        
                        <p>
                            <label>
                               校验码：</label>
                            <input type="text" name="validId" size="20"/> <img src="/AuthMain/ValidImage.bee" />
                            <label><%=Session[Bee.Security.Constants.SessionValidId]%></label>
                        </p>
                        <div>
                            <input type="submit" value="登入" />
                        </div>
                        </form>
                    </div>
                    <div><span><%=ViewData["errormsg"]%></span></div>
                </div>
            </div>
        </div>
    </center>
</body>
</html>
