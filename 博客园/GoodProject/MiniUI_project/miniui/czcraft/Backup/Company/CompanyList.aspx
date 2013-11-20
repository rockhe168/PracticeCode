<%@ Page Language="C#" MasterPageFile="~/InfoPage.master" AutoEventWireup="true" CodeFile="CompanyList.aspx.cs" Inherits="Company_CompanyList" Title="企业展示" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/other.css" rel="stylesheet" type="text/css" />
    <script src="../Admin/scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../css/pager.css" rel="stylesheet" type="text/css" />
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="list">
        <div class="list_load">
            <h3>
                企业展示</h3>
            <span><a href='<%=URLManage.GetURL("~/Default","")%>'>首页</a> > 企业展示</span>
        </div>
        <div class="ol">
            <table width="680" border="0" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="160">
                            企业名称
                        </th>
                        <th width="310">
                            企业简介
                        </th>
                        <th width="210">
                            企业网页
                        </th>
                    </tr>
                </thead>
                <tbody id="tBodyCompany">
                    <asp:Repeater ID="rpData" runat="server">
                        <ItemTemplate>
                           
                             <tr>
                          <td><a href='<%=URLManage.GetURL("~/Company/CompanyInfo","")%>?CompanyId=<%#Eval("Id") %>'><img src='../Admin/FileManage/GetImg.ashx?method=GetCompanyPic&type=medium&fileName=<%#Eval("Picturepath") %>' title='<%#Eval("Name") %>' alt='<%#Eval("Name") %>' /><br /><%#Eval("Name") %></a></td>
                          <td class="jianjie"><a href='<%=URLManage.GetURL("~/Company/CompanyInfo","")%>?CompanyId=<%#Eval("Id") %>'><%#Eval("Introduction") %></a></td>
                          <td><a href='<%=URLManage.GetURL("~/Company/CompanyInfo","")%>?CompanyId=<%#Eval("Id") %>'><%#Eval("Name") %>主页</a></td>
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
