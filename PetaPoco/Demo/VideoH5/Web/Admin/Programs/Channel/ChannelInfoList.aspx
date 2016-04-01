<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelInfoList.aspx.cs" Inherits="Web.Admin.Programs.Channel.ChannelInfoList" %>
<%@ Import Namespace="videoContext" %>

<form id="pagerForm" method="post" action="Programs/Channel/ChannelInfoList.aspx">
<input type="hidden" name="pageNum" value="1" />
<input type="hidden" name="numPerPage" value="<%=DefaultListPagination.PageSize %>" />
</form>
<div class="pageHeader">
    <form id="pageHeader" onsubmit="return navTabSearch(this);" action="Programs/Channel/ChannelInfoList.aspx"
    method="post">
    <div class="searchBar">
        <table class="searchContent">
            <tr>
                <td>
                    <label>开始日期：</label>
				    <input type="text" name="StartDate" class="date" value="<%=Request["StartDate"]?? string.Empty %>" readonly="true"/>
				    <a class="inputDateButton" href="javascript:;">选择</a>
                </td>
               
                <td>
                    <label>结束日期：</label>
				    <input type="text" name="EndDate" class="date" value="<%=Request["EndDate"]?? string.Empty %>" readonly="true"/>
				    <a class="inputDateButton" href="javascript:;">选择</a>
                </td>
              
                <td>
                    包ID：<input type="text" name="ChannelNo" value="<%=Request["ChannelNo"] ?? string.Empty %>" />
                </td>
               
            </tr>
        </table>
        <div class="subBar">
            <ul>
                <li>
                    <div class="buttonActive">
                        <div class="buttonContent">
                            <button type="submit">
                                检索</button></div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    </form>
</div>
<div class="pageContent">
    <div class="panelBar">
        <%--<ul class="toolBar">
            <li <%=CheckFunOutDisplay(FunType.Add) %>><a class="add" href="#" onclick="$.RockDwz.OpenDialogWindow('Programs/SysManager/UserInfoAdd.aspx','UserInfoAdd','新增')">
                <span>添加</span></a></li>
            <li <%=CheckFunOutDisplay(FunType.Delete) %>><a class="delete" href="#" onclick="$.RockDwz.OpenAlertWindowTodoDeleteToOptions('Ajax/SysManager/UserInfoService.ashx?action=Delete','UserID','确认要删除此记录吗！')">
                <span>删除</span></a></li>
        </ul>--%>
    </div>
    <table class="list" width="100%" layouth="120">
        <thead>
            <tr>
             <%--   <th style="width: 4%;">
                    <input type="checkbox" group="UserID"  class="checkboxCtrl" />
                </th>--%>
                <th>
                    日期
                </th>
                <th>
                    产品名称
                </th>
                <th>
                    包ID
                </th>
                <th>
                    IP地址
                </th>
            </tr>
        </thead>
        <tbody>
            <%                
                foreach (channelhistory obj in DefaultList)
                {
            %>
            <tr>
               <%-- <td style="width: 4%;">
                    <input type="checkbox" id="UserID" name="UserID" value='<%=row["UserID"] %>' />
                </td>--%>
                <td>
                    <%=obj.date_created.ToShortDateString() %>
                </td>
                <td>
                    <%="天使影院" %>
                </td>
                <td>
                    <%=obj.channelNo %>
                </td>
                <td>
                    <%=obj.ip%>
                </td>
                <%--<td <%=CheckFunOutDisplay(FunType.Update) %>>
                    <label>
                        <a title="修改" href="#" class="btnEdit" onclick="$.RockDwz.OpenDialogWindow('Programs/SysManager/UserInfoEdit.aspx?UserID=<%=row["UserID"] %>','UserInfoEdit','修改')">
                        </a>
                    </label>
                </td>--%>
            </tr>
            <%
                }
            %>
        </tbody>
    </table>
    <%=OutPutPagerNavigation(DefaultListPagination) %>
</div>