
<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView"  %>
<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="Bee.Util" %>
<%@ Import Namespace="System.Collections.Generic" %>

<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div class="pageHeader">
    <form id="pageForm<%=PageId %>" action="/<%=ControllerName %>/List.bee" method="post" class="required-validate" >
    <input type='hidden' name='pageNum' value='<%=ViewData["pageNum"] %>' />
    <input type='hidden' name='pageSize' value='<%=ViewData["pageSize"] %>' />
    <input type='hidden' name='orderField' value='<%=ViewData["orderField"] %>' />
    <input type='hidden' name='orderDirection' value='<%=ViewData["orderDirection"] %>' />
    <input type='hidden' name='recordCount' value='<%=ViewData["recordCount"] %>' />
    <div class="searchBar">
        <ul class="searchContent">
         <li>
                <label>
                    登入用户：</label>
                <%=HtmlHelper.ForSelect("userid", "authusermapping", "<option value='@id'>@nickname</option>") %>
            </li>
            <li>
                <label>
                    访问时间：</label>
                <input type='text' style='width: 80px' name='createtimebegin' value='<%=ViewData["createtimebegin"] %>' class="date"/>-
                <input type='text' style='width: 80px' name='createtimeend' value='<%=ViewData["createtimeend"] %>' class="date"/>
            </li>
        </ul>
    </div>
    </form>
</div>
<div class="pageContent">
    <div class="panelBar">
        <ul class="searchBar">
            <li> <a class="button" href="javascript:" onclick="javascript:autoList();"><span>检索</span> </a></li>
        </ul>
    </div>
    <table id="table<%=PageId %>" class="table" width="1000" layouth="112">
        <thead>
        
                    <th width='25'><input type='checkbox' group='ids' class='checkboxCtrl'></th>
            <%= HtmlHelper.AutoHeaderInfo%>
                
        </thead>
        <tbody>
        <%
            if(dataTable != null)
            {
            foreach (System.Data.DataRow row in dataTable.Rows)
            {%>
            <tr>
				<td><input name='ids' value='<%=row[0] %>' type='checkbox'></td>
				<%
                    string itemValue = string.Empty;
                    foreach (System.Data.DataColumn column in dataTable.Columns)
                    {
                        if (string.Compare(column.ColumnName, "userid", true) == 0)
                        {
                            itemValue = HtmlHelper.ForDataMapping("authusermapping", row[column], "id", "nickname");
                        }
                        else
                        {
                            itemValue = row.Format(column.ColumnName);
                        }
                        Response.Write(string.Format("<td>{0}</td>", itemValue));
                    }
                %>
				 
			</tr>
			<%}} %>
        </tbody>
    </table>
    <div class='panelBar'>
        <div class='pages'>
            <span>显示</span>
            <select class='combox' name='numPerPage' onchange="javascript:autoChangePageSize(this);">
            <%=HtmlHelper.ForPageSizeSelect() %>
            </select>
            <span>条，共<%=ViewData["recordcount"] %>条</span>
        </div>
        <div class='pagination' totalcount='<%=ViewData["recordCount"] %>' numperpage='<%=ViewData["pagesize"] %>' pagenumshown='10'
            currentpage='<%=ViewData["pagenum"] %>' click="javascript:autoJumpTo(#pageNum#);">
        </div>
    </div>
</div>
