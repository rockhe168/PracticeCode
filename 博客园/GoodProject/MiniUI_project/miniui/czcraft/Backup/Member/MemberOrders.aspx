<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="MemberOrders.aspx.cs"
    Inherits="Member_MemberOrders" Title="订单" %>

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

    <script src="../js/AjaxJsDeal/MemberInfo.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/ShoppingCart.js" type="text/javascript"></script>

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
                        <td width="71" class="td_left">
                            省： 
                        </td>
                        <td width="128">
                            <select id="selProvince" name="selProvince" class="validate[required]" style="width: 100px">
                            </select>
                        </td>
                        <td width="31" class="td_left">
                            市：
                        </td>
                        <td width="133">
                            <select id="selCity" name="selCity" class="validate[required]" style="width: 100px">
                            </select>
                        </td>
                        <td width="24" class="td_left">
                            区：
                        </td>
                        <td width="151">
                            <select id="selCountry" name="selCountry" class="validate[required]" style="width: 100px">
                            </select>
                        </td>
                        <td width="65" class="td_left">
                        </td>
                        <td width="199">
                            <%--<input type="text" id="txtZipCode" name="txtZipCode" class="grxx_text2 validate[required,custom[Zipcode]] text-input" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            街道地址：
                        </td>
                        <td colspan="7" class="textarea">
                            <textarea id="txtHomeBase" name="txtHomeBase" class="grxx_text1 validate[required]"
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
                            <input type="text" id="Name" class="validate[required]" name="Name" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            电话：
                        </td>
                        <td colspan="4">
                            <input type="text" id="txtTelPhone" name="txtTelPhone" class="xgmm_text validate[required,custom[phone]] text-input" />
                            (格式：区号-电话号码)
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Email：
                        </td>
                        <td colspan="4">
                            <input type="text" id="txtEmail" name="txtEmail" class="xgmm_text validate[required,custom[email]] text-input"  />
                            
                        </td>
                  
                    </tr>
                    <tr>
                        <td class="td_left">
                            手机：
                        </td>
                        <td colspan="4">
                            <input type="text" id="txtMobilePhone" name="txtMobilePhone" class="xgmm_text validate[required,custom[Mobile]] text-input" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            邮政编码：
                        </td>
                        <td colspan="4">
                            <input type="text" id="txtZipCode" name="txtZipCode" class="grxx_text2 validate[required,custom[Zipcode]] text-input" />
                        </td>
                    </tr>
                </table>
            </form>
            <div>
            </div>
        </div>
        <div class="dingdan">
            <h3>
                确认订单信息</h3>
        </div>
        <div class="charge-info">
            商品总价(不含运费):<span>
                <label id="lbCountNum">
                </label>
            </span>元</div>
        <div id="datagrid1" class="mini-datagrid" style="width: 700px; height: 250px;" allowresize="true"
            url="Data/GetMemberInfo.ashx?method=SearchShoppingCart" idfield="Id">
            <div property="columns" style="color: Black">
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
                <div field="Quantity" width="80" headeralign="center">
                    <input property="editor" class="mini-spinner" minvalue="1" renderer="onRenderQuantity"
                        maxvalue="9999" value="1" style="width: 100%;" />
                    购买数量</div>
                <div name="Sum" width="80" headeralign="center" align="center" renderer="onSumRenderer"
                    cellstyle="padding:0;">
                    小计</div>
            </div>
        </div>
        <ul class="back_gwc" style="margin-top: 13px">
            <li><a class="mini-button" iconcls="icon-undo" href='<%=URLManage.GetURL("~/Member/ShopingCart","")%>'>返回购物车</a></li>
        </ul>
        <div class="correct">
            <div class="fukuan">
                <a id="btnCommit" href="#">
                    <img src="../images/correct.jpg" /></a>
            </div>
        </div>
    </div>

    <script type="text/javascript">
  $(function(){
 	
 	 //购物车信息加载
 	 GetCartInfo();
 	  //省市数据初始化
        GetProvince();
        //获取民族信息
        GetNation();
        //绑定事件  
        $("#selProvince").change(function(){
        GetCity();
        });
        $("#selCity").change(function(){
        GetCountry();
        });
        //加载用户信息
          GetUserInfo();
        $("#form1").validationEngine();
        //表单提交事件
        Comit();
  });
    mini.parse();
        var grid = mini.get("datagrid1");
        grid.load({
            key: "",
            pageIndex: 0,
            pageSize: 10,
            sortField: "Id",
            sortOrder: "asc"
            })

    </script>

</asp:Content>
