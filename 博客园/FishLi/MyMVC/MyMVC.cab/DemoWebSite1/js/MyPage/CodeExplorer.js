
$(window).resize(function(){
	var height = $(window).height() - $("#topBanner").height() -2;
	$("#divExplorerContainer").height(height).width( $(window).width() );
	$("#divExplorer").layout("resize");
}); 

$(function(){
	if( window.SyntaxHighlighter )  
		SyntaxHighlighter.defaults['toolbar'] = false;
		
	$("#divBottomBlank").remove();
	$("#contentBody").css("padding", "0px");
	$("#topBanner").css("border-bottom", "0px");
	$(window).resize();
	
	$('#fileFolderTree').tree({
		url: '/AjaxFileTree/GetWebSiteFileNodes.cspx',
		onClick:function(node){
			if( node.attributes.FilePath == "###" )
				return;

			//var j_waitDialog = ShowWaitMessageDialog();
			$.ajax({
				url: "/AjaxFileTree/GetFileText.cspx",  type: "GET", dataType: "text",
				data: {path: node.attributes.FilePath },
				//complete: function() { HideWaitMessageDialog(j_waitDialog); },
				success: function(responseText) {
					var pre = "";
					switch(node.attributes.FileType){
						case ".cs":
						case ".ashx":
						case ".asax":
							pre = "<pre class='brush: c#;' name='code'>"; break;
						case ".css":
							pre = "<pre class='brush: css;' name='code'>"; break;
						case ".js":
							pre = "<pre class='brush: js;' name='code'>"; break;
						case ".sql":
							pre = "<pre class='brush: sql;' name='code'>"; break;
						case ".aspx":
						case ".ascx":
						case ".master":
						case ".config":
						case ".skin":
							pre = "<pre class='brush: xml;' name='code'>"; break;
						default:
							pre = "<pre>";
					}
						
					var html = pre + responseText.replace(/</g, "&lt;") + "</pre>";
					$("#divFileBody").html(html).scrollTop(0).scrollLeft(0);
					SyntaxHighlighter.highlight();
					$("#divFileBody").panel({title: node.text});
				}
			});
		}
	});
});

