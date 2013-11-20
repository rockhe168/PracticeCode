<%@ Application Language="C#" %>

<script runat="server">

	private static readonly string XmlDbFilePath =
		System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\MyNorthwindDataBase.xml");
	
    void Application_Start(object sender, EventArgs e) 
    {
		WebSiteDB.LoadDbFromXml(XmlDbFilePath);
    }
    
    void Application_End(object sender, EventArgs e) 
    {
		WebSiteDB.SaveDbToXml(XmlDbFilePath);
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
		Exception ex = Server.GetLastError();
		WebSiteCommonLib.AppHelper.SafeLogException(ex);

		//Server.ClearError();		
		// 这里不对异常做任何处理，就让它出现黄页。
    }


	protected void Application_BeginRequest(object sender, EventArgs e)
	{
		// 不允许直接访问特定样式的页面。
		// 因为那样会绕过MyMVC框架，导致Page的Model成员没有机会赋值。
		
		HttpApplication app = (HttpApplication)sender;
		if( app.Request.FilePath.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase)
			&& app.Request.FilePath.StartsWith("/Pages/Style", StringComparison.OrdinalIgnoreCase) )
			app.Response.Redirect("/Pages/" + app.Request.FilePath.Substring(14), true);
	}


	//protected void Application_PostResolveRequestCache(object sender, EventArgs e)
	//{
	//    // 这里只是一个演示。
	//    // 主要是将诸如：/mvc/Customers 这类请求映射到MyMVC框架的处理器

	//    HttpApplication app = (HttpApplication)sender;
	//    if( app.Request.FilePath.StartsWith("/mvc/") ) {
	//        IHttpHandler myHandler = MyMVC.MvcPageHandlerFactory.TryGetHandler(app.Context);
	//        if( myHandler != null )
	//            app.Context.RemapHandler(myHandler);
	//    }
	//}
	
	
	
</script>
