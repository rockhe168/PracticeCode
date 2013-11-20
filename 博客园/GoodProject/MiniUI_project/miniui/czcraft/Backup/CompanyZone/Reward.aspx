<%@ Page Language="C#" MasterPageFile="~/CompanyZone.master" AutoEventWireup="true" CodeFile="Reward.aspx.cs" Inherits="CompanyZone_Reward" Title="获奖信息" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  
  <link href="../Admin/css/demo.css" rel="stylesheet" type="text/css" />

    <script src="../Admin/scripts/miniui/miniui.js" type="text/javascript"></script><link href="../Admin/scripts/miniui/themes/default/miniui1.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" />
     <script src="../Admin/scripts/PluginForm.js" type="text/javascript"></script>
    <script src="../Admin/scripts/jquery.MultiFile.pack.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/CompanyReward.js" type="text/javascript"></script>
   
    <style type="text/css">
        
        .New_Button, .Edit_Button, .Delete_Button, .Update_Button, .Cancel_Button
        {
            font-size:11px;color:#1B3F91;font-family:Verdana;  
            margin-right:5px;          
        }
       
     html, body
    {
        font-size:12px;
        padding:0;
        margin:0;
       text-align:center;
        border:0;
    }    
        .style2
    {
    	width:100px;
    	 height: 25px;
    }
        	
        .style3
        {
            width: 200px;
             height: 25px;
        }
    
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="nav">
         <ul class="TabBarLevel1" id="Ul2">
            <li><a  href='<%=URLManage.GetURL("~/CompanyZone/AddProduct","")%>'>商品添加</a></li>
            <li><a href='<%=URLManage.GetURL("~/CompanyZone/ProductManage","")%>'>产品管理</a></li>
            <li><a href='<%=URLManage.GetURL("~/CompanyZone/CompanyInfo","")%>'>个人简介</a></li>
            <li  class="selected"><a style="color:#FFF"  href='<%=URLManage.GetURL("~/CompanyZone/Reward","")%>'>获奖情况</a></li>
         <li  ><a  href='<%=URLManage.GetURL("~/CompanyZone/CompanyPic","")%>'>企业美景图</a></li>
        </ul>
    </div>

  <div id="datagrid1" class="mini-datagrid" style="width:100%"
        url="Data/CompanyZoneInfo.ashx?method=SearchCompanyRewardPic"  idField="Id"
         onselectionchanged="onSelectionChanged"
    >
        <div property="columns">
            <div name="action" width="50" headerAlign="center" align="center" renderer="onActionRenderer" cellStyle="padding:0;">操作</div>
            <div field="Name" width="120" headerAlign="center" align="center" allowSort="true">证书名称</div>                         
            <div field="Picpath" width="100" align="center" headerAlign="center" renderer="onReaderPic" >图片</div>
            
        </div>
    </div>      
    <br />
    <div style="text-align:center">
     <form id="form1">
    <fieldset style="width:60%;border:solid 1px #aaa;position:relative;margin-left:180px;">
    
        <legend>荣誉证书详情</legend>
        <div id="editForm1" style="padding:10px;">
            <input class="mini-hidden" name="Id" id="Id"/>
             <table>
           <tr>
            <td class="style2">图片名称：</td>
                <td class="style3">                        
                     <input name="Name" id="Name" style="width:180px"  class="mini-textbox"/>
                </td>
                 <td   rowspan="4">图片预览：</td>
                <td  rowspan="4" colspan="2">  
                <img width="100" id="PicpathShow"   height="100px"  style="margin-left:10px"/> 
                </td>
           </tr>
          
            <tr>
               <td  class="style2"></td>
                <td  class="style3">    
                   
                 
                </td>
             
            </tr>
            <tr>
              <td class="style2"></td>
                <td  class="style3">    
                   
                </td>
             
            </tr>
               <tr>
              
              <td class="style2">修改图片:</td>
                <td class="style3">                        
                     <input class="multi" style=" width:180px" type="file" id="fileupload"  name="fileupload" maxlength="1" accept="gif|jpg|bmp|png"/  />
              
                   
     <input type="hidden" name="Picturepath"  id="Picturepath"/>
       </td>
     
              
             
            </tr>
            <tr>
              <td class="style2"></td>
                <td class="style3">                        
                   
                </td>
          
                 <td class="style2"></td>
                <td class="style3">    
                 
                  
                </td>
            </tr>
            <tr>
                <td class="style2"></td>
                <td  colspan="style3" rowspan="5"> 
                 <a class="mini-button" id="ajaxButton" iconCls="icon-folder"   onclick="onUpload">上传</a>   
                   <a class="mini-button" iconCls="icon-edit" onclick="OnUpdate">更新</a>
                      <a class="mini-button mini-button-iconRight" iconCls="icon-cancel"   href="javascript:cancelRow();">取消</a> 
                </td>
            </tr>     
            
        </table>   

           
        </div>
    </fieldset>
    </form>
    </div>
    

    <script type="text/javascript">

        mini.parse();

        var editForm = document.getElementById("editForm1");
        var form = new mini.Form("editForm1");

        var grid = mini.get("datagrid1");
        grid.sortBy("Id", "asc");
        
        ///////////////////////////////////////////////////////       
      
    </script>
</asp:Content>

