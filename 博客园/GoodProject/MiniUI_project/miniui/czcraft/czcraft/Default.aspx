<%@ Page Language="C#" MasterPageFile="~/Left_Top_Dwon.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="主页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="js/pic_turn.js"></script>

    <script src="js/AjaxJsDeal/Default.js" type="text/javascript"></script>

    <script type="text/javascript">
    //ajax中用到的超链接
var MasterInfoURL='<%=URLManage.GetURL("~/Master/MasterInfo","")%>';
var CompanyInfoURL='<%=URLManage.GetURL("~/Company/CompanyInfo","")%>';
var ProductURL='<%=URLManage.GetURL("~/Product/Product","")%>';
$(function(){
//加载中间内容信息
GetTopNews();
GetCraftKnowledge();
GetTopMasterInfo();
GetTopCompanyInfo();
GetTopProduct();
});

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="show_pic">
        <object id="FlashID" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="760"
            height="302">
            <param name="movie" value="fl/banner.swf" />
            <param name="quality" value="high" />
            <param name="wmode" value="opaque" />
            <param name="swfversion" value="9.0.45.0" />
            <param name="expressinstall" value="js/expressInstall.swf" />
            <embed src="fl/banner.swf" quality="high" width="760" height="302" type="application/x-shockwave-flash"
                wmode="transparent" pluginspage="http://www.macromedia.com/go/getflashplayer"></embed>
            <div>
                <h4>
                    此页面上的内容需要较新版本的 Adobe Flash Player。</h4>
                <p>
                    <a href="http://www.adobe.com/go/getflashplayer">
                        <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                            alt="获取 Adobe Flash Player" width="112" height="33" /></a></p>
            </div>
        </object>
    </div>
    <div class="rs_nr">
        <div class="news">
            <div class="r_s_title1">
                <p class="hide">
                    工艺新闻</p>
                <a href='<%=URLManage.GetURL("~/News/NewsList","")%>'>
                    <img src="images/more.png" /></a></div>
            <div class="r_s_p">
                <div class="gk_pic">
                    <img src="images/gynews.png" alt="工艺新闻" /></div>
                <p>
                    潮州工艺品历史悠久，人文积淀深厚,闻名全国的就有大吴泥塑、潮州刺绣、潮州陶瓷和金漆木雕</p>
            </div>
            <div class="r_s_list">
                <ul id="ulNews">
                </ul>
            </div>
        </div>
        <div class="knowleage">
            <div class="r_s_title2">
                <p class="hide">
                    工艺知识</p>
                <a href='<%=URLManage.GetURL("~/CraftKnowledge/CraftKnowledgeList","")%>'>
                    <img src="images/more.png" /></a></div>
            <div class="r_s_p">
                <div class="gk_pic">
                    <img src="images/gyknowleage.png" alt="工艺知识" /></div>
                <p>
                    潮州工艺品历史悠久，人文积淀深厚,闻名全国的就有大吴泥塑、潮州刺绣、潮州陶瓷和金漆木雕</p>
            </div>
            <div class="r_s_list">
                <ul id="ulCraftKnowledge">
                </ul>
            </div>
        </div>
        <div class="company">
            <div class="r_s_title3">
                <p class="hide">
                    企业展示</p>
                <a href='<%=URLManage.GetURL("~/Company/CompanyList","")%>'>
                    <img src="images/more.png" /></a></div>
            <div class="r_s_p">
                <div class="gk_pic">
                    <img src="images/gycompany.png" alt="企业展示" /></div>
                <p>
                    潮州工艺品历史悠久，人文积淀深厚,闻名全国的就有大吴泥塑、潮州刺绣、潮州陶瓷和金漆木雕</p>
            </div>
            <div class="r_s_list">
                <ul id="ulCompany">
                </ul>
            </div>
        </div>
        <div class="master" id="divMaster">
            <div class="r_s_title4">
                <p class="hide">
                    大师展示</p>
                <a href='<%=URLManage.GetURL("~/Master/MasterList","")%>'>
                    <img src="images/more.png" /></a></div>
        </div>
    </div>
    <div class="pro_show">
        <h3 class="hide">
            工艺品展示</h3>
        <div class="rollbox">
            <div class="rollbox_left" onmousedown="ISL_GoDown()" onmouseup="ISL_StopDown()" onmouseout="ISL_StopDown()">
            </div>
            <div class="cont" id="ISL_Cont">
                <div class="scrcont">
               <%-- <%ShowProduct(20); %>--%>
                    <div id="List1">
                        <div class="pic">
                            <a href="#" target="_blank" class="pic_a">
                                <img src="images/loading.gif" alt="pic1" /></a>
                        </div>
                        <div class="pic">
                            <a href="#" target="_blank" class="pic_a">
                                <img src="images/loading.gif" alt="pic1" /></a>
                        </div>
                        <div class="pic">
                            <a href="#" target="_blank" class="pic_a">
                                <img src="images/loading.gif" alt="pic1" /></a>
                        </div>
                        <div class="pic">
                            <a href="#" target="_blank" class="pic_a">
                                <img src="images/loading.gif" alt="pic1" /></a>
                        </div>
                        <div class="pic">
                            <a href="#" target="_blank" class="pic_a">
                                <img src="images/loading.gif" alt="pic1" /></a>
                        </div>
                        <div class="pic">
                            <a href="#" target="_blank" class="pic_a">
                                <img src="images/loading.gif" alt="pic1" /></a>
                        </div>
                    </div>
                    <div id="List2">
                    </div>
                </div>
            </div>
            <div class="rollbox_right" onmousedown="ISL_GoUp()" onmouseup="ISL_StopUp()" onmouseout="ISL_StopUp()">
            </div>
        </div>
    </div>
</asp:Content>
