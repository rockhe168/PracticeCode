<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="ShopingCart.aspx.cs"
    Inherits="Member_ShopingCart" Title="购物车" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />

    <script src="../Admin/scripts/jquery-1.6.2.min.js" type="text/javascript"></script>

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script>

    <link href="../Admin/scripts/miniui/themes/default/miniui2.css" rel="stylesheet"
        type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
       <script src="../js/AjaxJsDeal/ShoppingCart.js" type="text/javascript"></script>
    <style type="text/css">
     
        .New_Button, .Edit_Button, .Delete_Button, .Update_Button, .Cancel_Button
        {
            font-size:11px;color:#1B3F91;font-family:Verdana;  
            margin-right:5px;
        }
       
                     
    </style>
    <script type="text/javascript">
       var ProductURL='<%=URLManage.GetURL("~/Product/Product","")%>';
    var MasterInfoURL='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>';
   
    var CompanyInfoURL='<%=URLManage.GetURL("~/CompanyZone/CompanyInfo","")%>';
    var OrderManageURL='<%=URLManage.GetURL("~/Member/OrderManage","")%>';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="zz">
        <div class="gouwuche">
            <div class="flow-steps">
                <ul class="num5">
                    <li class="current"><span class="first">1. 查看购物车</span></li>
                    <li><span>2. 确认订单信息</span></li>
                    <li><span>3. 付款到支付宝</span></li>
                    <li><span>4. 确认收货</span></li>
                    <li class="last"><span>5. 评价</span></li>
                </ul>
            </div>
            <div class="pay_for">
                <div>
                    商品总价(不含运费)：<span>
                        <label id="lbCountNum1" text="" />
                    </span>元</div>
                <div>
                    <a href="MemberOrders.aspx">
                        <img src="../images/js_small_03.jpg" /></a><a href="MemberOrders.aspx"></a></div>
            </div>
            <div id="datagrid1" class="mini-datagrid" style="width: 700px; height: 250px;" allowresize="true" multiSelect="true"     
                url="Data/GetMemberInfo.ashx?method=SearchShoppingCart" idfield="Id">
                <div property="columns" style="color: Black">
                
                    <div type="checkcolumn" width="30">
                    </div>
                    <div field="ProductId" width="60" headeralign="center" allowsort="true" renderer="onRenderProduct">
                        产品Id</div>
                    <div field="Picturepath" width="100" align="center" headeralign="center" renderer="onReaderPic">
                        图片</div>
                    <div field="ProductName" width="100" headeralign="center" allowsort="true" renderer="onRenderProductName">
                        产品名称</div>
                    <div field="SupperlierName" renderer="RendererSupperlierName" width="120">
                        供应商</div>
                    <div field="Price" width="80" allowsort="true">
                        商品售价</div>
                    <div field="Quantity" width="80" headeralign="center" >
                    <input property="editor" class="mini-spinner" minValue="1"  renderer="onRenderQuantity" maxValue="9999"  value="1" style="width:100%;"/>
                        购买数量</div>
                <div name="action" width="80" headerAlign="center" align="center" renderer="onActionRenderer" cellStyle="padding:0;">操作</div>
                </div>
            </div>
            <table width="700" class="order-table" cellpadding="0" cellspacing="0">
                <tfoot>
                    <tr>
                        <td colspan="4" class="point-info">
                        <%--    <input type="button" onclick="remove" value="批量删除" />--%> <a class="mini-button" iconCls="icon-remove" onclick="remove">批量删除</a>
                        </td>
                        <td colspan="4">
                            <div class="charge-info">
                                商品总价(不含运费):<span>
                                    <label id="lbCountNum">
                                    </label>
                                </span>元</div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                        <td colspan="4">
                            <div class="piliang">
                                <a href="MemberOrders.aspx">
                                    <img src="../images/js_big.jpg" /></a></div>
                        </td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        mini.parse();

        var grid = mini.get("datagrid1");
        grid.load({
            key: "",
            pageIndex: 0,
            pageSize: 10,
            sortField: "Id",
            sortOrder: "asc"
            })
            //初始化
            $(function(){
            GetCartInfo();
            });
         
    </script>

</asp:Content>
