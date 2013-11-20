<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView"  %>
<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="Bee.Data" %>
<%@ Import Namespace="System.Collections.Generic" %>

<% List<Bee.Data.DbObject> list = Model as List<Bee.Data.DbObject>;
    foreach(DbObject item in list)
    { %>
    <li><a onclick="javascript:GetCode('<%=item.DbObjectName %>');"><%=item.DbObjectName %></a></li>
    <%} %>