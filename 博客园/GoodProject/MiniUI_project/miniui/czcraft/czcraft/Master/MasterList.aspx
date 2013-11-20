<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true"
    CodeFile="MasterList.aspx.cs" Inherits="Master_MasterList" Title="大师风采" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/other.css" rel="stylesheet" type="text/css" />
<%--
    <script src="../Admin/scripts/jquery-1.7.1.min.js" type="text/javascript"></script>--%>

   <%-- <script src="../js/jquery-pager-1.0.js" type="text/javascript"></script>--%>

    <link href="../css/pager.css" rel="stylesheet" type="text/css" />

    
<%--<script src="../js/AjaxJsDeal/MasterList.js" type="text/javascript"></script>
  --%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="list">
        <div class="list_load">
            <h3>
                大师风采</h3>
            <span><a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > 大师风采</span>
        </div>
        <div class="ol">
            <table width="680" border="0" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="160">
                            大师名称
                        </th>
                        <th width="310">
                            大师简介
                        </th>
                        <th width="210">
                            大师个人网页
                        </th>
                    </tr>
                </thead>
                <tbody id="tBodyMaster">
                    <asp:Repeater ID="rpData" runat="server">
                        <ItemTemplate>
                           
                             <tr>
                          <td><a href='<%=URLManage.GetURL("~/Master/MasterInfo","")%>?MasterId=<%#Eval("Id") %>'><img src='../Admin/FileManage/GetImg.ashx?method=GetMasterPic&type=medium&fileName=<%#Eval("Picturepath") %>' title='<%#Eval("Name") %>' alt='<%#Eval("Name") %>' /><br />'<%#Eval("Name") %>'</a></td>
                          <td class="jianjie"><a href='<%=URLManage.GetURL("~/Master/MasterInfo","")%>?MasterId=<%#Eval("Id") %>'><%#Eval("Introduction") %></a></td>
                          <td><a href='<%=URLManage.GetURL("~/Master/MasterInfo","")%>?MasterId=<%#Eval("Id") %>'><%#Eval("Name") %>主页</a></td>
                      </tr>
                            
                           
                         
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
       <%-- <div id="Pager">
        </div>--%>
          <div class="page">
              <p><div class="pager"><%=PagerHtml%></div></p>
               
        </div>
    </div>
</asp:Content>
