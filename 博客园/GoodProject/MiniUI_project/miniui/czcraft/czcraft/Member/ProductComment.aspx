<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="ProductComment.aspx.cs" Inherits="Member_ProductComment" Title="����" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="../css/buy.css" rel="stylesheet" type="text/css" />
    <link href="../css/comment.css" rel="stylesheet" type="text/css" />
  <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script>

    <link href="../Admin/scripts/miniui/themes/default/miniui2.css" rel="stylesheet"
        type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/css/validationEngine.jquery.css" rel="stylesheet" type="text/css" />

    <script src="../js/queryUrlParams.js" type="text/javascript"></script>
    <script src="../js/jquery.validationEngine.js" type="text/javascript"></script>

    <script src="../js/languages/jquery.validationEngine-zh_CN.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/OrdersInfo.js" type="text/javascript"></script>
    <script src="../js/AjaxJsDeal/comment.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/ProductComment.js" type="text/javascript"></script>
    <script type="text/javascript">
  var MasterInfoURL='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>';
   
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="gouwuche">
       <div class="flow-steps">
                <ul class="num5">
                    <li class="done"><span class="first">1. �鿴���ﳵ</span></li>
                    <li class="done"><span>2. ȷ�϶�����Ϣ</span></li>
                    <li class="done"><span>3. ���֧����</span></li>
                    <li class="done"><span>4. ȷ���ջ�</span></li>
                    <li class="last current"><span>5. ����</span></li>
                </ul>
            </div>
             
           
            <div id="comment">
            <div class="wp_table">
                <div id="datagrid1" class="mini-datagrid" style="width: 700px; height: 400px;" allowresize="true"
                    url="Data/GetMemberInfo.ashx?method=SearchOrders" idfield="Id">
                    <div property="columns" style="color: Black">
                      <div field="#"  renderer="onRenderOrders" width="80"  >
                            ��������</div>
                             <div field="#" renderer="onRenderComment" width="80">
                            ����</div>
                        <div field="OrderId" width="140" headeralign="center" allowsort="true">
                            ������</div>
                        <div field="ProImg" width="80" align="center" headeralign="center" renderer="onReaderPic">
                            ͼƬ</div>
                        <div field="ProName" width="80" headeralign="center" allowsort="true" renderer="onRenderProductName">
                            ��Ʒ����</div>
                        <div field="ShopDate" width="80" dateformat="yy/MM/dd">
                            ����ʱ��</div>
                        <div field="ProPrice" width="100" allowsort="true">
                            ��Ʒ�ۼ�(Ԫ)</div>
                        <div field="ProNum" width="100" headeralign="center">
                            <input property="editor" class="mini-spinner" minvalue="1" renderer="onRenderQuantity"
                                maxvalue="9999" value="1" style="width: 100%;" />
                            ��������(��)</div>
                        <div name="Sum" width="100" headeralign="center" align="center" renderer="onSumRenderer"
                            cellstyle="padding:0;">
                            С��(Ԫ)</div>
                              <div field="TotalPrice" width="100" allowsort="true">
                            �ܽ��(Ԫ)</div>
                             <div field="FactPrice" width="100" allowsort="true">
                            ʵ�ʸ���(Ԫ)</div>
                          
                    </div>
                </div>
            </div>
            <input type="hidden" id="OrderProId" />
       <!--�û����ۿ�ʼ-->
			<div class="commentform mini-window" id="comment"  title="��Ʒ����" style="width:580px;height:270px;" showMaxButton="true" showToolbar="true" showFooter="true" showModal="true" allowResize="true" allowDrag="true">
				<form id="comment_form" name="comment_form">
					<dl>
						<dt>��Ʒ���֣�</dt>

						<dd style="width:300px">
                          <span id="stars" class="star star0">
                            <a title="һ�Ǽ�">1</a>
                            <a class="a2" title="���Ǽ�">2</a>
                            <a class="a3" title="���Ǽ�">3</a>
                            <a class="a4" title="���Ǽ�">4</a>
                            <a class="a5" title="���Ǽ�">5</a>
                          </span>&nbsp;
                          <input id="hidStar" name="hidStar" type="hidden" value="" class="validate[required]"  />
                        </dd>
					</dl>
					<dl>
						<dt>�������ݣ�</dt>
						<dd>
							<textarea name="txtContent" class="textarea " minlength="5" maxlength="3000" class="validate[required]" id="txtContent"></textarea>
							&nbsp;</dd>
					</dl>
					<dl>
						<dt>��֤�룺</dt>
						<dd style="width:385px;">
							<input name="txtCheckCode" id="txtCheckCode" type="text" class="input2 validate[required]" minlength="4" maxlength="5" style="width:50px;">
							<a href="javascript:changeImg();" onclick="#"><img src="../Admin/FileManage/VerifyChars.ashx" width="80" id="img" height="22" alt="����л���֤��" style="vertical-align:middle;" onclick="changeImg()"> ���������</a> </dd>
                     
						<dd>
							<input id="btnSubmit" name="btnSubmit" type="button" class="submit2" value="�ύ����">
						</dd>
					</dl>
					<div class="clear"></div>
				</form>
			</div>
			<!--�û����۽���-->
            </div>
    </div>
        <script type="text/javascript">
          mini.parse();
        var grid = mini.get("datagrid1");
            var PayStatus = [{ id: 0, text: '�ȴ�����' }, { id: 1, text: '�Ѵ���'}, { id: 2, text: '�Ѹ���'}, { id: 3, text: '���˿�'}, { id: 4, text: '�Ѿܾ�'}, { id: 5, text: '��ȡ��'}];
           //��ȡ״̬
           function GetStatus(id){
                for (var i = 0, l = PayStatus.length; i < l; i++) {
                var g = PayStatus[i];
                if (id == g.id) return g.text;
                }
            return "";
           }

        
    </script>
</asp:Content>

