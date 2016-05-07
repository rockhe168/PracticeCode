<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelCountList.aspx.cs" Inherits="Web.Admin.Programs.Channel.ChannelCountList" %>
<%@ Import Namespace="videoContext" %>
<form id="pagerForm" method="post" action="Programs/Channel/ChannelCountList.aspx">
<input type="hidden" name="pageNum" value="1" />
<input type="hidden" name="numPerPage" value="<%=DefaultListPagination.PageSize %>" />
</form>
<div class="pageHeader">
    <form id="pageHeader" onsubmit="return navTabSearch(this);" action="Programs/Channel/ChannelCountList.aspx"
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
                
                 <%--<td>
                     <label>结算状态：</label>
                    <select class="combox" name="paymentstate">
                        <option value="" <%=OutPutSelectChecked((Request["paymentstate"]??string.Empty).ToLower().Equals("")) %>>请选择</option>
					    <option value="true" <%=OutPutSelectChecked((Request["paymentstate"]??string.Empty).ToLower().Equals("true")) %>>已结算</option>
					    <option value="false" <%=OutPutSelectChecked((Request["paymentstate"]??string.Empty).ToLower().Equals("false")) %>>未结算</option>
				    </select>
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
            <%--<li><a class="add" href="#" onclick="$.RockDwz.OpenAlertWindowTodoDeleteByPK('Ajax/ChannelHandler.ashx?action=SyncData','确认要同步今天之前的数据吗！')">
                <span>同步数据</span></a></li>--%>
          <%--  <li><a class="add" href="#" onclick="$.RockDwz.OpenAlertWindowTodoDeleteToOptions('Ajax/ChannelInstallHandler.ashx?action=UpdateBalance','id','确认要把选择的标记成已结算吗！')">
                <span>结算勾选</span></a></li>--%>
        </ul>
    </div>
    <table class="list" width="100%" layouth="120">
        <thead>
            <tr>
             <%--   <th style="width: 4%;">
                    <input type="checkbox" group="id"  class="checkboxCtrl" />
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
                    IP流量
                </th>
                <th>
                    真实安装量
                </th>
                
                <th>
                    内容点击
                </th>
                
                <th>
                    支付请求
                </th>
                
                <th>
                    支付成功
                </th>
                
              <%--  <th>
                    支付失败
                </th>--%>
                <%--
                  <th>
                    操作
                </th>--%>
            </tr>
        </thead>
        <tbody>
            <%                
                foreach (channelinstallinfo obj in DefaultList)
                {
            %>
            <tr>
              <%--  <td style="width: 4%;">
                    <input type="checkbox" id="id" name="id" value='<%=obj.id %>' />
                </td>--%>
                <td>
                    <%=obj.createdate.ToShortDateString() %>
                </td>
                <td>
                    <%="极品影音" %>
                </td>
                <td>
                    <%=obj.channelNo %>
                </td>
                 <td>
                   TOTAL:  <%=obj.ipcounttemp%>
                </td>
                <td>
                   TOTAL:  <%=obj.installcounttemp%>
                </td>
                <td>
                   TOTAL: <%=obj.pvcounttemp %>
                </td>
                <td>
                   TOTAL:  <%=obj.paymentcounttemp%>
                </td>
                 <td>
                   TOTAL:  <%=obj.paymentsuccesscounttemp%>
                </td>
              <%--  <td>
                   TOTAL:  <%=obj.paymentfailcount%>
                </td>--%>
                <%--
                <td>
                    <label>
                        <a title="编辑" href="#" class="btnEdit" onclick="$.RockDwz.OpenDialogWindow('Programs/Channel/ChannelInstallEdit.aspx?id=<%=obj.id %>','ChannelInstallEdit','编辑')">
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