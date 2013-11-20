<%@ Page Language="C#" MasterPageFile="~/Member.master" AutoEventWireup="true" CodeFile="Collection.aspx.cs" Inherits="Member_Collection" Title="收藏夹" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link href="../css/gr.css" rel="stylesheet" type="text/css" />
    <script src="../js/queryUrlParams.js" type="text/javascript"></script>

    <script src="../Admin/scripts/jquery-1.6.2.min.js" type="text/javascript"></script>

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script>

    <link href="../Admin/scripts/miniui/themes/default/miniui2.css" rel="stylesheet"
        type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />

    <script src="../js/AjaxJsDeal/MemberCollection.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/tabchoose.js"> </script>
    <style type="text/css">

    .Delete
    {
background:url(../images/shanchu.gif) no-repeat;
    }
    	
    	
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="zz">
        <div class="zz_tab">
            <ul class="mt" id="TabPage1">
                <li id="Tab11" class="Selected"  ><a href="#"  onmouseover="javascript:switchTab1('TabPage1','Tab11');">
                    今日收藏 </a></li>
                <li id="Tab12"><a href="#" onmouseover="javascript:switchTab1('TabPage1','Tab12');">
                    历史收藏 </a></li>
            </ul>
            <div id="cnt1">
                <div id="dTab11" class="HackBox cp_table" style="display: block">
           <div id="datagrid1" class="mini-datagrid  table" style="width: 750px; height: 400px;" allowresize="true" multiSelect="true"     
                url="Data/GetMemberInfo.ashx?method=SearchCollection" idfield="Id">
                <div property="columns" style="color: Black">
                
                    <div type="checkcolumn" width="30">
                    </div>
                    <div field="ProductId" width="60" headeralign="center" allowsort="true" renderer="onRenderProduct">
                        产品Id</div>
                    <div field="Picturepath" width="100" align="center" headeralign="center" renderer="onReaderPic">
                        图片</div>
                    <div field="Name" width="100" headeralign="center" allowsort="true" renderer="onRenderProductName">产品名称</div>
                    <div field="Material" width="120">
                        材质</div>
                    <div field="Lsprice" width="80" >
                        商品售价</div>
                        
                        <div field="AddTime" width="80" dateformat="yy/MM/dd" allowsort="true" >
                        收藏时间</div>
                       <div  renderer="RendererSupperlierName" width="80" >
                    
                        卖家</div>
                        <div field="IsBuy" field="SupperName" width="80"  renderer="onIsBuyRenderer">
                        已购买过</div>
                <div name="action" width="120" headerAlign="center" align="center" renderer="onActionRenderer" cellStyle="padding:0;">操作</div>
                </div>
            </div>
                 
                </div>
                <div id="dTab12" class="HackBox cp_table" style="display: block">
                <div id="datagrid2" class="mini-datagrid  table" style="width: 750px; height: 400px;" allowresize="true" multiSelect="true"     
                url="Data/GetMemberInfo.ashx?method=SearchCollection" idfield="Id">
                <div property="columns" style="color: Black">
                
                    <div type="checkcolumn" width="30">
                    </div>
                    <div field="ProductId" width="60" headeralign="center" allowsort="true" renderer="onRenderProduct">
                        产品Id</div>
                    <div field="Picturepath" width="100" align="center" headeralign="center" renderer="onReaderPic">
                        图片</div>
                    <div field="Name" width="100" headeralign="center" allowsort="true"  renderer="onRenderProductName">产品名称</div>
                    <div field="Material" width="120">
                        材质</div>
                    <div field="Lsprice" width="80" >
                        商品售价</div>
                        
                        <div field="AddTime" width="80" dateformat="yy/MM/dd" allowsort="true" >
                        收藏时间</div>
                       <div  renderer="RendererSupperlierName" width="80" >
                    
                        卖家</div>
                        <div field="IsBuy" field="SupperName" width="80"  renderer="onIsBuyRenderer">
                        已购买过</div>
                <div name="action" width="120" headerAlign="center" align="center" renderer="onActionRenderer" cellStyle="padding:0;">操作</div>
                </div>
            </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        mini.parse();

        var grid = mini.get("datagrid1");
       
            var grid2 = mini.get("datagrid2");
            
            $(function(){
            $("#dTab11").show();
            $("#dTab12").hide();
             grid.load({
            key: "IsToday",
            pageIndex: 0,
            pageSize: 10,
            sortField: "ProductId",
            sortOrder: "asc"
            });
              grid2.load({
            key: "IsNotToday",
            pageIndex: 0,
            pageSize: 10,
            sortField: "ProductId",
            sortOrder: "asc"
            });
            
            
            });
       
         
    </script>
</asp:Content>

