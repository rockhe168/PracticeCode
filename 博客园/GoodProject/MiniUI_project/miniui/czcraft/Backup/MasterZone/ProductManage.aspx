<%@ Page Language="C#" MasterPageFile="~/Zone.master" AutoEventWireup="true" CodeFile="ProductManage.aspx.cs"
    Inherits="MasterZone_ProductManage" Title="产品管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
     <link href="../Admin/css/demo.css" rel="stylesheet" type="text/css" />

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script><link href="../Admin/scripts/miniui/themes/default/miniui1.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />

    <script src="../js/AjaxJsDeal/MasterProductMange.js" type="text/javascript"></script>
<script type="text/javascript">
 var ProductPicManageURL='<%=URLManage.GetURL("~/Master/ProductPicManage","")%>';

</script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="nav">
         <ul class="TabBarLevel1" id="Ul1">
		   <li><a  href='<%=URLManage.GetURL("~/MasterZone/AddProduct","")%>' >商品添加</a></li>
		   <li  class="selected"><a  style="color:#FFF" href='<%=URLManage.GetURL("~/MasterZone/ProductManage","")%>' >产品管理</a></li>
           <li ><a   href='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>'>个人简介</a></li>
		 	  <li><a  href='<%=URLManage.GetURL("~/MasterZone/Reward","")%>'>获奖情况</a></li>
         
	    </ul>
    </div>
      
        <div style="width:960px;margin:30px 0;">
              <div id="datagrid1" class="mini-datagrid table2" style="width:100%;height:500px;" allowResize="true"
        url="Data/MasterZoneInfo.ashx?method=SearchProduct"  idField="Id" multiSelect="false"    
        
    >
        <div property="columns">
         
           
          
            <div type="checkcolumn" ></div>  
              <div id="deal" name="action" width="100" headerAlign="center"   align="center" renderer="onActionRenderer" cellStyle="padding:0;">操作
            
            </div>      
            <div field="Name" width="60" headerAlign="center" allowSort="true">产品名称</div>    
            <div field="Simplename" width="40" headerAlign="center">简称</div>    
            <div field="TypeName" width="60" headerAlign="center" >产品类别</div>   
     
                    <div field="Num" width="40">总数量</div>
                    <div field="Soldnum" width="40">销售量</div>
                    <div field="MasterName" width="100">所属大师</div>
                    <div field="CompanyName" width="100">所属企业</div>
                    

                </div>
            </div>       
        </div>
      
     

    
    <script type="text/javascript">
        mini.parse();

        var grid = mini.get("datagrid1");
      //  grid.load();
        grid.sortBy("Name", "desc");

        /////////////////////////////////////////////////
        grid.set({ footerStyle: "padding-right:10px;" });



    </script>

</asp:Content>
