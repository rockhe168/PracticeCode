<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="OrderManage.aspx.cs"
    Inherits="Member_OrderManage" Title="订单管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script>

    <link href="../Admin/scripts/miniui/themes/default/miniui2.css" rel="stylesheet"
        type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>

    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/OrdersInfo.js" type="text/javascript"></script>
    <script type="text/javascript">
    var OrderDetailURL='<%=URLManage.GetURL("~/Member/OrderDetail","")%>';
    var ProductURL='<%=URLManage.GetURL("~/Product/Product","")%>';
    var MasterInfoURL='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>';
   
    var CompanyInfoURL='<%=URLManage.GetURL("~/CompanyZone/CompanyInfo","")%>';
   
    </script>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        <div class="wait_pay">
            <h3>
                您的订单信息</h3>
            <div class="wp_table">
                <div id="datagrid1" class="mini-datagrid" style="width: 700px; height: 400px;" allowresize="true"
                    url="Data/GetMemberInfo.ashx?method=SearchOrders" idfield="Id">
                    <div property="columns" style="color: Black">
                      <div field="#"  renderer="onRenderOrders" width="80"  >
                            订单详情</div>
                             <div field="#" renderer="onRenderDeal" width="80">
                            操作</div>
                        <div field="OrderId" width="140" headeralign="center" allowsort="true">
                            订单号</div>
                        <div field="ProImg" width="80" align="center" headeralign="center" renderer="onReaderPic">
                            图片</div>
                        <div field="ProName" width="80" headeralign="center" allowsort="true" renderer="onRenderProductName">
                            产品名称</div>
                        <div field="ShopDate" width="80" dateformat="yy/MM/dd">
                            购买时间</div>
                        <div field="ProPrice" width="100" allowsort="true">
                            商品售价(元)</div>
                        <div field="ProNum" width="100" headeralign="center">
                            <input property="editor" class="mini-spinner" minvalue="1" renderer="onRenderQuantity"
                                maxvalue="9999" value="1" style="width: 100%;" />
                            购买数量(个)</div>
                        <div name="Sum" width="100" headeralign="center" align="center" renderer="onSumRenderer"
                            cellstyle="padding:0;">
                            小计(元)</div>
                              <div field="TotalPrice" width="100" allowsort="true">
                            总金额(元)</div>
                             <div field="FactPrice" width="100" allowsort="true">
                            实际付款(元)</div>
                          
                    </div>
                </div>
            </div>
            
        </div>
    </div>
    <script type="text/javascript">
      mini.parse();
        var grid = mini.get("datagrid1");
        grid.load({
            key: "",
            pageIndex: 0,
            pageSize: 10,
            sortField: "ShopDate",
            sortOrder: "desc"
            })
            var PayStatus = [{ id: 0, text: '等待付款' }, { id: 1, text: '已处理'}, { id: 2, text: '已付款'}, { id: 3, text: '已退款'}, { id: 4, text: '已拒绝'}, { id: 5, text: '已取消'}];
              //获取状态
              function GetStatus(id){
                for (var i = 0, l = PayStatus.length; i < l; i++) {
                var g = PayStatus[i];
                if (id == g.id) return g.text;
            }
            return "";
              }
  
        
    </script>
</asp:Content>
