﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMVC;


namespace WebSiteController
{
	public class TestAuthorizeController
	{
		[Action]
		[PageUrl(Url = "/user/Login.aspx")]
		public object Login(string username)
		{
			if( string.IsNullOrEmpty(username) == false ) 
				// 为了简单，我就直接使用ASP.NET提供的方法了。
				System.Web.Security.FormsAuthentication.SetAuthCookie(username, false);

			return new RedirectResult("/Pages/Demo/TestAuthorize/default.aspx");

			// 注意：下面的方法也是可以的。但是会有F5的重复提交问题。
			//return new PageResult("/Pages/Demo/TestAuthorize/default.aspx", null);
		}

		[Action]
		[PageUrl(Url = "/user/Logout.aspx")]
		public object Logout()
		{
			System.Web.Security.FormsAuthentication.SignOut();

			return new RedirectResult("/Pages/Demo/TestAuthorize/default.aspx");
		}


		[Action]
		[Authorize(Users="fish")]
		[PageUrl(Url = "/Pages/Demo/TestAuthorize/Fish.aspx")]
		public object ShowFishPage()
		{
			// 仅当当前用户是 fish 时，才允许访问这个PageAction

			// 注意：第一参数为null，表示使用当前地址。
			return new PageResult(null, null);
		}

		[Action]
		[Authorize]
		[PageUrl(Url = "/Pages/Demo/TestAuthorize/LoginUser.aspx")]
		public object ShowLoginUserPage()
		{
			// 仅当当前用户是已登录用户时，才允许访问这个PageAction

			// 注意：第一参数为null，表示使用当前地址。
			return new PageResult(null, null);
		}

	}
}
