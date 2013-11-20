<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%
    List<Bee.Models.BillColumnField> all = ViewData["All"] as List<Bee.Models.BillColumnField>;
    List<Bee.Models.BillColumnField> setting = ViewData["setting"] as List<Bee.Models.BillColumnField>;

    if (all == null || setting == null) return;
%>
<div>
    <div class="pageFormContent">
        <label style="text-align: right">
            方案名称：</label>
        <%=HtmlHelper.ForTextBox("name", "style=width:400px;") %>
        <%=HtmlHelper.ForHidden("id") %>
        
        <label style="text-align:right">是否默认：</label>
                <%=HtmlHelper.ForSelect("settingtype", "是否10", false) %>
        
        </div>
    <div style="float: left;">
        <div style="font-size: large; text-align: center; color: Blue; width: 200px;">
            显示列</div>
        <div id="dest" class="sortDrag" style="width: 200px; border: 1px solid #e66; margin: 5px;
            min-height: 100px;">
            <%
                foreach (Bee.Models.BillColumnField item in setting)
                {%>
            <div style="border: 1px solid #B8D0D6; padding: 5px; margin: 5px" tvalue="<%=item.Name %>">
                <%=item.Title %></div>
            <%} %>
        </div>
    </div>
    <div style="float: left;">
        <div style="font-size: large; text-align: center; color: Blue;">
            未显示列</div>
        <div id="src" class="sortDrag" style="width: 200px; border: 1px solid #e66; margin: 5px;
            min-height: 100px;">
            <%foreach (Bee.Models.BillColumnField item in all)
              {
                  if (!setting.Contains(item))
                  {%>
            <div style="border: 1px solid #B8D0D6; padding: 5px; margin: 5px" tvalue="<%=item.Name %>">
                <%=item.Title%></div>
            <%}
              } %>
        </div>
    </div>
</div>
