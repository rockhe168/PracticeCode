<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="pageFormContent" layouth="56">
    <form id='content<%=PageId %>' action="<%=HtmlHelper.ForActionLink("DataDictSave") %>"
    method="post" class="required-validate alertMsg">
        <%= %>
    </form>
</div>

<script type="text/javascript">

    
</script>

