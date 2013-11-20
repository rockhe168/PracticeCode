<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="Bee.Util" %>
<%@ Import Namespace="System.Collections.Generic" %>
<% System.Data.DataTable dataTable = Model as System.Data.DataTable;  %>
<div class="pageHeader">
    <form id="pageForm<%=PageId %>" action="/<%=ControllerName %>/SuperList.bee" method="post"
    class="required-validate">
    <input type='hidden' name='pageNum' value='<%=ViewData["pageNum"] %>' />
    <input type='hidden' name='pageSize' value='<%=ViewData["pageSize"] %>' />
    <input type='hidden' name='orderField' value='<%=ViewData["orderField"] %>' />
    <input type='hidden' name='orderDirection' value='<%=ViewData["orderDirection"] %>' />
    <input type='hidden' name='recordCount' value='<%=ViewData["recordCount"] %>' />
    <div class="searchBar">
        <ul class="searchContent">
            <%=HtmlHelper.AutoSearchInfo%>
        </ul>
    </div>
    </form>
</div>
<div class="pageContent">
    <div class="panelBar">
        <ul class="toolBar">
            <li><a class="add" href="/<%=ControllerName %>/SuperShow.bee?id=-1" target="dialog" mask="true"
                width="800" height="480" title="创建" rel="CD<%=PageId %>"><span>添加</span></a></li>
        </ul>
        <ul class="searchBar">
            <li><a class="button" href="javascript:" onclick="javascript:autoList();"><span>检索</span>
            </a></li>
        </ul>
    </div>
    <table id="table<%=PageId %>" class="table" width="1000" layouth="156">
        <thead>
            <th width='25'>
                <input type='checkbox' group='ids' class='checkboxCtrl'>
            </th>
            <th orderfield='Id' class='desc'>
                Id
            </th>
            <th>
                员工工号
            </th>
            <th>
                昵称
            </th>
            <th orderfield='UserName'>
                用户名
            </th>
            <th width='80'>
                Email
            </th>
            <th width='80'>
                部门
            </th>
            <th width='80'>
                内置账号
            </th>
            
            <th width='80'>
                是否删除
            </th>
            <th align='center'>
                创建时间
            </th>
            <th width='140'>
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
                <td>
                    <%=row["id"]%>
                </td>
                 <td>
                    <%=row["workcode"]%>
                </td>
                <td>
                    <%=row["nickname"]%>
                </td>
                <td>
                    <%=row["username"]%>
                </td>
                <td>
                    <%=row["email"]%>
                </td>
                <td>
                    部门
                </td>
                <td>
                    <%=row["innerflag"]%>
                </td>
                
                <td>
                    <%=row["delflag"]%>
                </td>
                <td>
                    <%=row.Format("createtime")%>
                </td>
                <td>
                    <a title='删除' target='ajaxTodo' href='/AuthUser/Delete.bee?id=<%=row[0].ToString() %>'
                        class='btnDel'>删除</a> <a title='编辑' target="dialog" mask="true" width="820" height="480"
                            rel="CD<%=PageId %>" href='/AuthUser/SuperShow.bee?id=<%=row[0].ToString() %>' class='btnEdit'>
                            编辑</a> <a title='查看权限--<%=row["UserName"] %>' target="navTab" mask="true" rel="CD<%=PageId %>"
                                href='/AuthUser/ShowPermission.bee?id=<%=row[0].ToString() %>' class="button"><span>
                                    查看权限</span></a>
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
                       for (int i = 0; i < pageSizeList.Count; i++)
                       {
                           if (pageSizeList[i] > pageSize)
                           {
                               pageSizeList.Insert(pageSize, i);
                               break;
                           }
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
