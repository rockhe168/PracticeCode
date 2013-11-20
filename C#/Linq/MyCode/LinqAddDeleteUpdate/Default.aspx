﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinqAddDeleteUpdate.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        姓名
        <asp:TextBox ID="tb_UserName" runat="server"></asp:TextBox><br />
        <br />
        留言
        <asp:TextBox ID="tb_Message" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox><br />
        <br />
        <asp:Button ID="btn_SendMessage" runat="server" Text="发表留言" OnClick="btn_SendMessage_Click" /><br />
        <br />
        <asp:Repeater ID="rpt_Message" runat="server">
        <ItemTemplate>
        <table width="600px" style="border:solid 1px #666666; font-size:10pt; background-color:#f0f0f0">
            <tr>
            <td align="left" width="400px">
            <%# Eval("Message")%>
            </td>
            <td align="right" width="200px">
            <%# Eval("PostTime")%> - <%# Eval("UserName")%>
            </td>
            </tr>
            <tr>
            <td colspan="2" align="right">
            <hr width="300px" />
            管理员回复：<%# Eval("IsReplied").ToString() == "False" ? "暂无" : Eval("Reply")%>
            </td>
            </tr>          
        </table>
        <br/>
        </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
