<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  

%>
<div class="pageHeader">
    <form id="pageForm<%=PageId %>" action="<%=HtmlHelper.ForActionLink("List4") %>" method="post"
    class="required-validate alertMsg">
    <%=HtmlHelper.ForHidden("pageNum")%>
    <%=HtmlHelper.ForHidden("pageSize")%>
    <%=HtmlHelper.ForHidden("orderField")%>
    <%=HtmlHelper.ForHidden("orderDirection")%>
    <%=HtmlHelper.ForHidden("recordCount")%>
    <div class="searchBar">
        <ul class="searchContent">
            <li>
                <label>
                    姓名：</label>
                <%=HtmlHelper.ForTextBox("UserName") %>
            </li>
            <li>
                <label>
                    部门：</label>
                <%=HtmlHelper.ForSelect("DepartmentId", "DepartmentInfo") %>
            </li>
            <li>
                <label>
                    生日：</label><input type='text' style='width: 70px' name='Birthdaybegin' value='' class='date' />
                -
                <input style='width: 70px' type='text' name='Birthdayend' value='' class='date' />
            </li>
        </ul>
    </div>
    </form>
</div>
<div class="pageContent">
    <div class="panelBar">
        <ul class="toolBar">
            <li><a class="add" href="<%=HtmlHelper.ForActionLink("show") %>?id=-1" target="dialog"
                mask="true" title="创建" rel="CD<%=PageId %>"><span>添加</span></a></li>
        </ul>
        <ul class="searchBar">
            <li><a class="button" href="javascript:" onclick="javascript:autoList();"><span>检索</span>
            </a></li>
        </ul>
    </div>
    <table id="table<%=PageId %>" class="table" width="1000" layouth="112">
        <thead>
            <th width='25'>
                <input type='checkbox' group='ids' class='checkboxCtrl'>
            </th>
            <th <%=HtmlHelper.ForSortOrder("Id") %>>
                Id
            </th>
            <th <%=HtmlHelper.ForSortOrder("UserName") %>>
                姓名
            </th>
            <th>
                部门
            </th>
            <th>
                性别
            </th>
            <th>
                生日
            </th>
            <th>
                民族
            </th>
            <th>
                政治面貌
            </th>
            <th>
                文化程度
            </th>
            <th>
                籍贯
            </th>
            <th>
                婚姻状况
            </th>
            <th>
                健康状况
            </th>
            <th>
                身份证号
            </th>
            <th width='70'>
                操作
            </th>
        </thead>
        <tbody>
            <%
                if (dataTable != null)
                {
                    foreach (System.Data.DataRow row in dataTable.Rows)
                    {%>
            <tr>
                <td>
                    <input name='ids' value='<%=row[0] %>' type='checkbox'>
                </td>
                <%
                    foreach (System.Data.DataColumn column in dataTable.Columns)
                    {
                %>
                <td>
                    <%=HtmlHelper.AutoFormatRowItem(row, column.ColumnName)%>
                </td>
                <%} %>
                <td>
                    <a title='删除' target='ajaxTodo' href='<%=HtmlHelper.ForActionLink("delete") %>?id=<%=row[0].ToString() %>'
                        class='btnDel'>删除</a> <a title='编辑' target="dialog" mask="true" rel="CD<%=PageId %>"
                            href='<%=HtmlHelper.ForActionLink("show") %>?id=<%=row[0].ToString() %>' class='btnEdit'>
                            编辑</a>
                </td>
            </tr>
            <%}
                } %>
        </tbody>
    </table>
    <div class='panelBar'>
        <div class='pages'>
            <span>显示</span>
            <select class='combox' name='numPerPage' onchange="javascript:autoChangePageSize(this);">
                <% int pageSize = int.Parse(ViewData["pageSize"].ToString());

                   List<int> pageSizeList = new List<int>();
                   pageSizeList.Add(20);
                   pageSizeList.Add(40);
                   pageSizeList.Add(80);
                   if (!pageSizeList.Contains(pageSize))
                   {
                       if (pageSize < 80)
                       {
                           for (int i = 0; i < pageSizeList.Count; i++)
                           {
                               if (pageSizeList[i] > pageSize)
                               {
                                   pageSizeList.Insert(i, pageSize);
                                   break;
                               }
                           }
                       }
                       else
                       {
                           pageSizeList.Add(pageSize);
                       }
                   }
                   foreach (int item in pageSizeList)
                   {
                       Response.Write(string.Format(@"
                <option value='{0}' {1}>{0}</option>", item, item == pageSize ? "selected" : ""));
                   }
                %>
            </select>
            <span>条，共<%=ViewData["recordcount"] %>条</span>
        </div>
        <div class='pagination' totalcount='<%=ViewData["recordCount"] %>' numperpage='<%=ViewData["pagesize"] %>'
            pagenumshown='10' currentpage='<%=ViewData["pagenum"] %>' click="javascript:autoJumpTo(#pageNum#);">
        </div>
    </div>
</div>
