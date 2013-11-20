<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView"  %>
<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="Bee.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>

<pre class='brush: c#; toolbar: true;' name='code'>
<% TableSchema tableSchema = Model as TableSchema;  %>
public class <%= tableSchema.TableName %>
{
    #region Properties
    
    <%
        foreach(ColumnSchema column in tableSchema.ColumnList)
        {
            if (!string.IsNullOrEmpty(column.Description))
            {
    %>[ModelProperty(Description = "<%= column.Description%>")]
    <%} %>public <%= (column.Type.Name) %> <%=(column.ColumnName)%> {  get; set; }
    <%}%>
    #endregion

}
</pre>

<pre class='brush: sql; toolbar: true;' name='code'>
    <%=ViewData["sqlcode"] %>
</pre>