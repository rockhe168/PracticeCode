<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs"
    Inherits="Member_OrderDetail" Title="��������" %>

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
                    <li class="done current-prev "><span class="first">1. �鿴���ﳵ</span></li>
                    <li class="current"><span>2. ȷ�϶�����Ϣ</span></li>
                    <li><span>3. ���֧����</span></li>
                    <li><span>4. ȷ���ջ�</span></li>
                    <li class="last"><span>5. ����</span></li>
                </ul>
            </div>
            <form id="form1">
            <div class="adress">
                <h3>
                    ��д��ַ��Ϣ</h3>
                <table width="903" class="ad_table1">
                    <tr>
                        <td class="td_left">
                            ��ַ��
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
                            �ջ���������
                        </td>
                        <td colspan="4" class="style2">
                            <input type="text" id="ConsigneeRealName" disabled="disabled" name="ConsigneeRealName" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            �绰��
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneeTel" name="ConsigneeTel" disabled="disabled" />
                            (��ʽ������-�绰����)
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            Email��
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneeEmail" name="ConsigneeEmail" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            �ֻ���
                        </td>
                        <td colspan="4">
                            <input type="text" id="ConsigneePhone" name="ConsigneePhone" disabled="disabled" />
                        </td>
                    </tr>
                    <tr>
                        <td class="td_left">
                            �������룺
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
                ������Ϣ</h3>
        </div>
        <div class="charge-info">
            ��Ʒ�ܼ�(�����˷�):<span>
                <label id="lbCountNum">
                </label>
            </span>Ԫ</div>
        <div id="datagrid1" class="mini-datagrid" style="width: 700px; height: 250px;" allowresize="true"
            url="Data/GetMemberInfo.ashx?method=SearchOrders" idfield="Id">
            <div property="columns" style="color: Black">
                <div field="OrderId" width="140" headeralign="center" allowsort="true">
                    ������</div>
                <div field="ProImg" width="80" align="center" headeralign="center" renderer="onReaderPic">
                    ͼƬ</div>
                <div field="ProName" width="80" headeralign="center" allowsort="true" renderer="onRenderProductName">
                    ��Ʒ����</div>
                <div field="SupperlierName" renderer="RendererSupperlierName" width="120">
                    ��Ӧ��</div>
                <div field="ShopDate" width="80" dateformat="yy/MM/dd">
                    ����ʱ��</div>
                <div field="ProPrice" width="100" allowsort="true">
                    ��Ʒ�ۼ�(Ԫ)</div>
                <div field="ProNum" width="100" headeralign="center">
                    ��������(��)</div>
                <div name="Sum" width="100" headeralign="center" align="center" renderer="onSumRenderer"
                    cellstyle="padding:0;">
                    С��(Ԫ)</div>
                <div field="TotalPrice" width="100" allowsort="true">
                    �ܽ��(Ԫ)</div>
                <div field="FactPrice" width="100" allowsort="true">
                    ʵ�ʸ���(Ԫ)</div>
            </div>
            <ul class="back_gwc" style="margin-top: 13px">
                <li><a class="mini-button" iconcls="icon-undo" href='<%=URLManage.GetURL("~/Member/OrderManage","")%>'>�����ҵĶ���</a></li>
            </ul>
        </div>

        <script type="text/javascript">
    var OrderId=$.query.get("OrderId"); 
  $(function(){
        //�����û���Ϣ
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

           var PayStatus = [{ id: 0, text: '�ȴ�����' }, { id: 1, text: '�Ѵ���'}, { id: 2, text: '�Ѹ���'}, { id: 3, text: '���˿�'}, { id: 4, text: '�Ѿܾ�'}, { id: 5, text: '��ȡ��'}];
        </script>
</asp:Content>
