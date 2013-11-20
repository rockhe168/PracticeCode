<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="MyCollection.aspx.cs"
    Inherits="Member_MyCollection" Title="我的收藏夹" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/gr.css" rel="stylesheet" type="text/css" />
    <link href="../css/Pager.css" rel="stylesheet" type="text/css" />

    <script src="../js/jquery.mypagination.js" type="text/javascript"></script>

    <script src="../js/queryUrlParams.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/tabchoose.js"> </script>
  <script type="text/javascript">
  $(function(){
  //Tab11
  //如果是今日收藏
  var type=$.query.get("Type");
   if(type=='False')
   {
    switchTab1('TabPage1','Tab11');
   $("#Tab11").removeclass("Selected");
    $("#Tab12").removeclass("Selected");
     $("#Tab11").addclass("Selected");
    
   }
   else{
     switchTab1('TabPage1','Tab12');
   $("#Tab11").removeclass("Selected");
    $("#Tab12").removeclass("Selected");
     $("#Tab12").addclass("Selected");
   } 
  });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
    <div class="zz">
        <div class="zz_tab">
            <ul class="mt" id="TabPage1">
                <li id="Tab11" class="Selected"><a href="#"  onmouseover="javascript:switchTab1('TabPage1','Tab11');">
                    今日收藏 </a></li>
                <li id="Tab12" ><a href="#" onmouseover="javascript:switchTab1('TabPage1','Tab12');">
                    历史收藏 </a></li>
            </ul>
            <div id="cnt1">
                <div id="dTab11" class="HackBox cp_table" style="display: block">
                    <table id="tbToday" width="750" class="table">
                        <tr>
                            <th width="49">
                                <input type="checkbox" class="checkbox" />全选
                            </th>
                            <th width="258">
                                作品名称
                            </th>
                            <th width="77">
                                单价
                            </th>
                            <th width="98">
                                收藏时间
                            </th>
                            <th width="109">
                                卖家
                            </th>
                            <th width="131">
                                操作
                            </th>
                        </tr>
                        <asp:Repeater ID="rpTodayData" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td align="center">
                                        <input type="checkbox" id="cbPId" value='<%#Eval("ProductId") %>' />
                                    </td>
                                    <td class="sc_img">
                                        <span>
                                            <img src='../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName=<%#Eval("PicturePath") %>' alt="dd"  style="width:60px; height:60px"/></span> <span class="sc_img_p">
                                                <p class="blue">
                                                   <%#Eval("Name")%> </p>
                                                <p class="gray">
                                                    <%#Eval("Material")%></p>
                                            </span>
                                    </td>
                                    <td align="center">
                                        ￥<%#Eval("LsPrice")%>
                                    </td>
                                    <td align="center">
                                        <%#Eval("AddTime")%>
                                    </td>
                                    <td align="center">
                                         <%#Eval("BelongSell")%>
                                    </td>
                                    <td align="center">
                                        <input type="button" value='' alt="加入购物车" runat="server" class="button"  id="btnAdd"/><br />
                                           <a href="#" class="del" id="btnDel" runat="server" >
                                    <p class="hide">
                                        删除</p>
                                </a>
                                      
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="6" class="sc_pl_td">
                                <ul class="sc_pl_ul">
                                    <li>
                                        <input type="checkbox" class="checkbox" />全选</li>
                                    <li><div class="pager"><a>加入购物车</a></div></li>
                                    <li><div class="pager"><a>批量删除</a></div></li>
                                    <li ><div class="pager"><%=PagerHtml%></div></li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="dTab12" class="HackBox cp_table" style="display: none">
                    <table width="750" class="table">
                        <tr>
                            <th width="48">
                                <input type="checkbox" class="checkbox" />全选
                            </th>
                            <th width="254">
                                作品名称
                            </th>
                            <th width="85">
                                单价
                            </th>
                            <th width="98">
                                收藏时间
                            </th>
                            <th width="113">
                                卖家
                            </th>
                            <th width="124">
                                操作
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <input type="checkbox" />
                            </td>
                            <td class="sc_img">
                                <span>
                                    <img src="images/120.jpg" alt="dd" /></span> <span class="sc_img_p">
                                        <p class="blue">
                                            纯手工精雕细琢绝版收藏</p>
                                        <p class="gray">
                                            材质：原木</p>
                                    </span>
                            </td>
                            <td align="center">
                                ￥200.00
                            </td>
                            <td align="center">
                                2011-11-11
                            </td>
                            <td align="center">
                                周少君大师
                            </td>
                            <td align="center">
                                <input type="button" value=" " alt="加入购物车" class="button" /><br />
                                <a href="#" class="del">
                                    <p class="hide">
                                        删除</p>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" class="sc_pl_td">
                                <ul class="sc_pl_ul">
                                    <li>
                                        <input type="checkbox" class="checkbox" />全选</li>
                                    <li><a href="#">加入购物车</a></li>
                                    <li><a href="#">批量删除</a></li>
                                    <li>把你要添加的分页导航弄到这里面来 </li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
