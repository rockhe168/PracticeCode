<%@ Page Language="C#" MasterPageFile="~/Top_Down.master" AutoEventWireup="true"
    CodeFile="SearchKnowledge.aspx.cs" Inherits="Search_SearchKnowledge" Title="找找看-工艺知识" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/baidu.css" rel="stylesheet" type="text/css" />
    <link href="../css/other.css" rel="stylesheet" type="text/css" />
    <link href="../css/ui-lightness/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../css/Pager.css" rel="stylesheet" type="text/css" />
    <link href="../css/Search.css" rel="stylesheet" type="text/css" />
    <script src="../Admin/scripts/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="../js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>

    <script type="text/javascript">
    
      $(function () {
            $("#kw").autocomplete(
            { source: "Data/SearchSuggestion.ashx",
                select: function (event, ui) { $("#kw").val(ui.item.value); $("#form1").submit(); }
            });
        });
    </script>

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <div class="left_side">
            <div class="logo_bottom">
            </div>
        </div>
        <div class="gjss_load">
            <h4>
                找找看</h4>
            <span>当前位置：<a href="#">首页</a> &gt; <a href="#">找找看</a></span>
        </div>
        <div class="gjss">
            <div class="gjss_top">
            </div>
            <div class="gjss_c">
                <table width="804">
                    <tr>
                        <td colspan="7" align="center">
                            <label id="lbNews"  style="margin-left:260px" class="tab"><a href="SearchNews.aspx">新闻</a></label>      <label id="lbKnowledge"  style="margin-left:50px" class="tab"><a href="SearchKnowledge.aspx">工艺知识</a></label><label id="lbProduct" style="margin-left:50px" class="tab"><a href="#">商品</a></label>
                        
                            </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <div id="m" align="center">
                                <div id="fm">
                                    <form name="form1">
                                    <span class="s_ipt_wr" style="float: left">
                                        <input id="kw" class="s_ipt" name="kw" maxlength="100" value='<%=Request["kw"] %>' />
                                    </span><span class="s_btn_wr">
                                        <input id="su" class="s_btn" onmouseout="this.className='s_btn'" onmousedown="this.className='s_btn s_btn_h'"
                                            value="找找看" type="submit" /></span></form>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="center" class="style1">
                            <div style="text-align: center">
                                <ul id="hotwordsUL" class="hotWords">
                                    <asp:Repeater ID="repeaterHotWords" runat="server">
                                        <ItemTemplate>
                                            <li><a href='SearchKnowledge.aspx?kw=<%#Eval("KeyWord") %>'>
                                                <%#Eval("KeyWord") %>
                                            </a></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7" align="center">
                            <br />
                            <ul id="ulResult" class="hotWords">
                                <asp:Repeater EnableViewState="false" ID="repeaterResult" runat="server">
                                    <ItemTemplate>
                                        <li><span><%--<a  href='../CraftKnowledge/ViewCraftKnowledge.aspx?KnowledgeId=<%#Eval("Number") %>'>--%>
                                        <a  href='<%#Eval("ArticleHtmlUrl") %>'>
                                            <%#Eval("Title") %></a></span>
                                           <br />
                                           <span> <%#Eval("BodyPreview")%></span>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <br />
                            <div class="pager">
                                <%=PageHtml%>
                            </div>
                        
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
