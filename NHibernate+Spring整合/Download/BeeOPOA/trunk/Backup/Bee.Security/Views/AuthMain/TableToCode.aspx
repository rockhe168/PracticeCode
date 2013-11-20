<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>

<link type="text/css" rel="Stylesheet" href="/js/syntaxhighlighter/shCore.css" />
<link type="text/css" rel="Stylesheet" href="/js/syntaxhighlighter/shThemeDefault.css" />

<script type="text/javascript" src="/js/syntaxhighlighter/shCore.js"></script>
<script type="text/javascript" src="/js/syntaxhighlighter/shBrushCSharp.js"></script>
<script type="text/javascript" src="/js/syntaxhighlighter/shBrushCss.js"></script>
<script type="text/javascript" src="/js/syntaxhighlighter/shBrushJScript.js"></script>
<script type="text/javascript" src="/js/syntaxhighlighter/shBrushSql.js"></script>
<script type="text/javascript" src="/js/syntaxhighlighter/shBrushXml.js"></script>

<form id='pageForm<%=PageId %>' action="<%=HtmlHelper.ForActionLink() %>" method="post">
<div class="formBar">
    <ul style="float: left; margin-right: 350px;">
        <li>
            <select id="conn">
                <option value="">请选择</option>
                <%
                    List<string> list = ViewData["ConnectionString"] as List<string>;
                    foreach (string item in list)
                    { %>
                <option value="<%=item %>"><%=item %></option>
                <%} %>
            </select>
        </li>
    </ul>
</div>
</form>

<div id="treediv" style="float: left; display: block; margin: 10px; overflow: auto; width: 350px;
    border: solid 1px #CCC; line-height: 21px; background: #FFF;" layouth="56">
    <ul id="tree1" class="tree treeFolder expand">
        
    </ul>
</div>
<div region="center" id="divFileBody" title="文件源代码" layouth="56">
</div>

<script type="text/javascript">

    $(document).ready(function() {
        $("#conn").change(function() {
            $("#tree1").loadUrl("/AuthMain/GetDbSchema.bee", { connString: $(this).val() },
            function() {
                bee.initUI($("#treediv"));
            }
            );
        });
    });

    function GetCode(item) {
        $("#divFileBody").loadUrl("/AuthMain/GetCode.bee", { connString: $("#conn").val(), dbObject: item },
        function() {
            SyntaxHighlighter.highlight();
        });
    }
</script>

