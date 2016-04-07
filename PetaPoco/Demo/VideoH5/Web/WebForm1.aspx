<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnAdd").click(function () {
                $.get("./Ajax/PaymentInfoHandler.ashx?action=AddPaymentInfo&ip=10.39.553.26&channelNo=111111&orderId=99999&ptype=1", function (data) {
                    $("#msg").html(data);
                });
            });

            $("#btnExists").click(function () {
                $.get("./Ajax/PaymentInfoHandler.ashx?action=IsExists&mac=33333334", function (data) {
                    $("#msg").html(data);
                });
            });

            $("#btnAddChannel").click(function () {
                $.get("./Ajax/ChannelHandler.ashx?action=AddChannelHistory&channelNo=111111&url=baidu.com&ip=12.0.0.1", function (data) {
                    $("#msg").html(data);
                });
            });

            $("#btnAddChannelInstall").click(function () {
                $.get("./Ajax/ChannelHandler.ashx?action=AddChannelInstall&channelNo=111111&mac=dsafdasdfs333323", function (data) {
                    $("#msg").html(data);
                });
            });

            $("#btnAddPv").click(function () {
                $.get("./Ajax/PVHandler.ashx?action=AddPv&channelNo=111111&mac=dsafdasdfs333323&ip=10.39.553.26", function (data) {
                    $("#msg").html(data);
                });
            });
           
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <input type="button" id="btnAdd" value="Add PaymentInfo"/>
      <input type="button" id="btnExists" value="Exists PaymentInfo"/>
      <input type="button" id="btnAddChannel"value="Add Channel" />
      <input type="button" id="btnAddChannelInstall"value="Add ChannelInstall" />
      <input type="button" id="btnAddPv"value="Add Pv" />
    </div>
     <div id="msg">

     </div>
    </form>
</body>
</html>
