<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs"
    Inherits="Member_OrderDetail" Title="订单详情" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script>

    <link href="../Admin/scripts/miniui/themes/default/miniui2.css" rel="stylesheet"
        type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
    <script src="../js/queryUrlParams.js" type="text/javascript"></script>
    <script src="../js/AjaxJsDeal/OrdersInfo.js" type="text/javascript"></script>
    <style type="text/css">
        .New_Button, .Edit_Button, .Delete_Button, .Update_Button, .Cancel_Button
        {
            font-size: 11px;
            color: #1B3F91;
            font-family: Verdana;
            margin-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="zz">
        <div class="gouwuche">
            <div class="flow-steps">
                <ul class="num5">
                    <li class="done current-prev "><span class="first">1. 查看购物车</span></li>
                    <li class="current"><span>2. 确认订单信息</span></li>
                    <li><span>3. 付款到支付宝</span></li>
                    <li><span>4. 确认收货</span></li>
                    <li class="last"><span>5. 评价</span></li>
                </ul>
            </div>
            <form id="form1">
            <div class="adress">
                <h3>
                    填写地址信息</h3>
                <table width="903" class="ad_table1">
                    <tr>
                        <td class="td_left">
                            地址：
                        </td>
                        <td colspan="7" class="textarea">
                            <textarea id="ConsigneeAddress" name="ConsigneeAddress" class="grxx_text1" disabled="disabled"
                                cols="80" rows="3"></textarea>
                            &nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
                <table width="624" class="ad_table2">
                    <tr>
                        <td width="79" class="style1">
                            收货人姓名：
                        </td>
                        <td colspan="4" class="style2">
                            <input type="text" id="ConsigneeRealName" disabled="disabled" name="ConsigneeRealName" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            电话：
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneeTel" name="ConsigneeTel" disabled="disabled" />
                            (格式：区号-电话号码)
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Email：
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneeEmail" name="ConsigneeEmail" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            手机：
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneePhone" name="ConsigneePhone" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            邮政编码：
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneeZip" name="ConsigneeZip" disabled="disabled" />
                        </td>
                    </tr>
                </table>
            </form>
            <div>
            </div>
        </div>
        <div class="dingdan">
            <h3>
                订单信息</h3>
        </div>
        <div class="charge-info">
            商品总价(不含运费):<span>
                <label id="lbCountNum">
                </label>
            </span>元</div>
        <div id="datagrid1" class="mini-datagrid" style="width: 700px; height: 250px;" allowresize="true"
            url="Data/GetMemberInfo.ashx?method=SearchOrders" idfield="Id">
            <div property="columns" style="color: Black">
                <div field="OrderId" width="140" headeralign="center" allowsort="true">
                    订单号</div>
                <div field="ProImg" width="80" align="center" headeralign="center" renderer="onReaderPic">
                    图片</div>
                <div field="ProName" width="80" headeralign="center" allowsort="true" renderer="onRenderProductName">
                    产品名称</div>
                <div field="SupperlierName" renderer="RendererSupperlierName" width="120">
                    供应商</div>
                <div field="ShopDate" width="80" dateformat="yy/MM/dd">
                    购买时间</div>
                <div field="ProPrice" width="100" allowsort="true">
                    商品售价(元)</div>
                <div field="ProNum" width="100" headeralign="center">
                    购买数量(个)</div>
                <div name="Sum" width="100" headeralign="center" align="center" renderer="onSumRenderer"
                    cellstyle="padding:0;">
                    小计(元)</div>
                <div field="TotalPrice" width="100" allowsort="true">
                    总金额(元)</div>
                <div field="FactPrice" width="100" allowsort="true">
                    实际付款(元)</div>
            </div>
            <ul class="back_gwc" style="margin-top: 13px">
                <li><a class="mini-button" iconcls="icon-undo" href='<%=URLManage.GetURL("~/Member/OrderManage","")%>'>返回我的订单</a></li>
            </ul>
        </div>

        <script type="text/javascript">
    var OrderId=$.query.get("OrderId"); 
  $(function(){
        //加载用户信息
          GetOrdersUserInfo();
  });
        mini.parse();
        var grid = mini.get("datagrid1");
        grid.load({
            key: OrderId,
            pageIndex: 0,
            pageSize: 10,
            sortField: "Id",
            sortOrder: "asc"
            })

           var PayStatus = [{ id: 0, text: '等待付款' }, { id: 1, text: '已处理'}, { id: 2, text: '已付款'}, { id: 3, text: '已退款'}, { id: 4, text: '已拒绝'}, { id: 5, text: '已取消'}];
        </script>
</asp:Content>
