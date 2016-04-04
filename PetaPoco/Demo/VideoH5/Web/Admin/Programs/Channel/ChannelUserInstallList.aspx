<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelUserInstallList.aspx.cs" Inherits="Web.Admin.Programs.Channel.ChannelUserInstallList" %>
<%@ Import Namespace="videoContext" %>

<form id="pagerForm" method="post" action="Programs/Channel/ChannelUserInstallList.aspx">
<input type="hidden" name="pageNum" value="1" />
<input type="hidden" name="numPerPage" value="<%=DefaultListPagination.PageSize %>" />
</form>
<div class="pageHeader">
    <form id="pageHeader" onsubmit="return navTabSearch(this);" action="Programs/Channel/ChannelUserInstallList.aspx"
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
                     <label>结算状态：</label>
                    <select class="combox" name="paymentstate">
                        <option value="" <%=OutPutSelectChecked((Request["paymentstate"]??string.Empty).ToLower().Equals("")) %>>请选择</option>
					    <option value="true" <%=OutPutSelectChecked((Request["paymentstate"]??string.Empty).ToLower().Equals("true")) %>>已结算</option>
					    <option value="false" <%=OutPutSelectChecked((Request["paymentstate"]??string.Empty).ToLower().Equals("false")) %>>未结算</option>
				    </select>
                </td>
               <%-- <td>
                    包ID：<input type="text" name="ChannelNo" value="<%=Request["ChannelNo"] ?? string.Empty %>" />
                </td>--%>
               
            </tr>
        </table>
        <div class="subBar">
            <ul>
                <li>
                    <div class="buttonActive">
                        <div class="buttonContent">
                            <button type="submit">
                                数据查询</button></div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    </form>
</div>
<div class="pageContent">
    <div class="panelBar">
        <ul class="toolBar">
            <%--<li <%=CheckFunOutDisplay(FunType.Add) %>><a class="add" href="#" onclick="$.RockDwz.OpenDialogWindow('Programs/SysManager/UserInfoAdd.aspx','UserInfoAdd','新增')">
                <span>添加</span></a></li>--%>
          <%--  <li><a class="add" href="#" onclick="$.RockDwz.OpenAlertWindowTodoDeleteByPK('Ajax/ChannelHandler.ashx?action=SyncData','确认要同步今天之前的数据吗！')">
                <span>同步数据</span></a></li>--%>
        </ul>
    </div>
    <table class="list" width="100%" layouth="120">
        <thead>
            <tr>
                <th>
                    日期
                </th>
                <th>
                    产品名称
                </th>
             
                <th>
                    安装量
                </th>
                 <th>
                    单价
                </th>
                <th>
                    佣金
                </th>
                <th>
                    结算
                </th>
            
            </tr>
        </thead>
        <tbody>
            <%                
                foreach (channelinstallinfo obj in DefaultList)
                {
            %>
            <tr>
                <td>
                    <%=obj.createdate.ToShortDateString() %>
                </td>
                <td>
                    <%="天使影院" %>
                </td>
                <td>
                   <%=(obj.realinstallcount==0) ? "暂无数据" : "TOTAL:"+obj.realinstallcount%>
                </td>
                
                <td>
                    <%=(obj.realinstallcount==0) ? "暂无数据" : ""+obj.unitprice%>
                </td>
                
                 <td>
                     <%=(obj.realinstallcount==0) ? "暂无数据" : "TOTAL:"+obj.realinstallcount%>
                   TOTAL:  <%=obj.inputmoney%>
                </td>
                 <td>
                    <%=obj.paymentstate ? "已结算" :"未结算" %>
                </td>
            </tr>
            <%
                }
            %>
        </tbody>
    </table>
    <%=OutPutPagerNavigation(DefaultListPagination) %>
</div>