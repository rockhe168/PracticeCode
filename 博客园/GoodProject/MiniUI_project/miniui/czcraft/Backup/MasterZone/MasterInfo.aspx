<%@ Page Language="C#" MasterPageFile="~/Zone.master" AutoEventWireup="true" CodeFile="MasterInfo.aspx.cs" Inherits="MasterZone_MasterInfo" Title="���˼��" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
 <link href="../Admin/Scripts/miniui/themes/default/miniui.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/Scripts/miniui/themes/icons.css" rel="stylesheet" type="text/css" /> 

     <script src="../Admin/Scripts/PluginForm.js" type="text/javascript"></script>
    <script src="../Admin/Scripts/jquery.MultiFile.pack.js" type="text/javascript"></script>
    <script src="../Admin/Scripts/miniui/miniui.js" type="text/javascript"></script>
     <script src="../Admin/Scripts/isValid.js" type="text/javascript"></script>

    <script src="../js/AjaxJsDeal/MasterZoneInfo.js" type="text/javascript"></script>
   
    <style type="text/css">
        html, body
        {
            font-size: 12px;
            padding: 0;
            margin: 0;
            border: 0;
        }
        .style2
        {
            width: 70px;
        }
        .style1
        {
            width: 353px;
        }
        .style3
        {
            width: 150px;
        }
        .style4
        {
            width: 70px;
            height: 26px;
        }
        .style5
        {
            width: 150px;
            height: 26px;
        }
        .style6
        {
            width: 70px;
            height: 23px;
        }
        .style7
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1"  action="Data/MasterZoneInfo.ashx?method=SaveMaster"  enctype="multipart/form-data">
      <div class="nav">
      
        <ul class="TabBarLevel1" id="Ul1">
		   <li><a  href='<%=URLManage.GetURL("~/MasterZone/AddProduct","")%>' >��Ʒ���</a></li>
		   <li><a  href='<%=URLManage.GetURL("~/MasterZone/ProductManage","")%>' >��Ʒ����</a></li>
           <li  class="selected"><a  style="color:#FFF" href='<%=URLManage.GetURL("~/MasterZone/MasterInfo","")%>'>���˼��</a></li>
		 	  <li><a  href='<%=URLManage.GetURL("~/MasterZone/Reward","")%>'>�����</a></li>
         
	    </ul>
    </div>
      <div style="width:960px;margin:30px 0;" >
         <fieldset style="border:solid 1px #aaa;padding:5px; width:500px; margin-left:180px;">
            <legend >������Ϣ</legend>
            <input type="hidden" id="id" name="id" />
            <div style="padding:5px;">
            <table>
                <tr>
                    <td class="style2">�û�����</td>
                    <td class="style3">    
                        <input name="Username" id="Username" class="mini-textbox"   requiredErrorText="�û�������Ϊ��" readonly="readonly" required="true" onvalidation="isRegisterUserNameValidation" /> 
                    </td>
                    <td class="style2">���룺</td>
                    <td class="style3">    
                        <input name="Password" id="Password" readonly="readonly"  class="mini-password"  />
                    </td>
                </tr>
                <tr>
                  <td class="style2">�Ա�</td>
                <td>    
                  <div name="Sex" class="mini-combobox"  id="Sex" textField="text" valueField="id" value="1" url="../Admin/CommonLibs/genders.txt" />
                </td>
                <td class="style2">����</td>
                <td class="style3">
                 
                   <div name="Nation" class="mini-combobox" id="nation"  textField="text" valueField="id" value="1" url="../Admin/CommonLibs/national.txt" />
              
                </td>
                </tr>
                               <tr>
                  <td class="style2">��ʵ������</td>
                <td  class="style3">    
                  <input name="Name" class="mini-textbox"  onvalidation="IsChinese"  id="Name" />
                </td>
                  <td class="style2">��ʦ���</td>
                <td  class="style3">    
                   <input class="mini-treeselect" url="Data/MasterZoneInfo.ashx?method=GetMultiProductType" multiSelect="true" 
        textField="text" valueField="id"  id="ProductType"
    />
                </td>
                
             
                </tr>
               
                   
            </table>
       </div>
       </fieldset>
      
        <fieldset style="border:solid 1px #aaa;padding:5px;width:500px; margin-left:180px;">
            <legend >��ϸ��Ϣ</legend>
            <div style="padding:5px;">
        <table>
           <tr>
            <td class="style2">�������ڣ�</td>
                <td class="style3">                        
                     <input name="BirthDay" id="BirthDay" class="mini-datepicker" format="yyyy-MM-dd" />
                </td>
                 <td   rowspan="4">�ҵ�ͷ��</td>
                <td  rowspan="4" colspan="2">  
                <img width="100" id="pic"  name="pic" height="100px"  style="margin-left:10px"/> 
                </td>
           </tr>
          
            <tr>
               <td  class="style4">�������룺</td>
                <td  class="style5">    
                    <input name="Zipcode" id="Zipcode" class="mini-textbox"   onvalidation="isPostalCodeValidation"/>
                 
                </td>
             
            </tr>
            <tr>
              <td class="style2">qq�ţ�</td>
                <td  class="style3">    
                    <input name="qq" id="qq" class="mini-textbox"  onvalidation="IsQQValidation" />
                </td>
             
            </tr>
               <tr>
              <td class="style2">�绰�ţ�</td>
                <td class="style3">                        
                     <input name="Telephone" id="Telephone" class="mini-textbox" onvalidation="isTelValidation"  />
                </td>
             
            </tr>
            <tr>
              <td class="style2">�ֻ��ţ�</td>
                <td class="style3">                        
                     <input name="mobilephone" id="mobilephone" class="mini-textbox" onvalidation="isMobileValidation" />
                </td>
          
                 <td class="style2">ͼƬ�ϴ���</td>
                <td class="style3">    
                  <input class="multi" style=" width:180px" type="file" id="fileupload"  name="fileupload" maxlength="1" accept="gif|jpg|bmp|png"/  />
              
                   
     <input type="hidden" name="Picturepath"  id="Picturepath"/>
                  
                </td>
            </tr>
            <tr>
                <td class="style2">Email��ַ:</td>
                <td colspan="3">    
                    <input name="Email" id="Email" class="mini-textbox style1" onvalidation="isEmailValidation"  /> 
                </td>
            </tr>     
            <tr>
                <td class="style2">��ַ��</td>
                <td colspan="3">    
                    <input name="Address" id="Address" class="mini-textbox style1"/>
                </td>
            </tr>   
              <tr>
                <td class="style6">�ռ���ַ��</td>
                <td colspan="3" class="style7">    
                    <input name="website" id="website" onvalidation="IsURLValidation" class="mini-textbox style1" readonly="readonly"/>
                </td>
            </tr>  
                <tr>
                <td class="style2">��ʦ������</td>
                <td colspan="3">    
                    <input name="appreciation" id="appreciation" class="mini-textbox style1"/>
                </td>
            </tr>    
              <tr>
                <td class="style2">����Ϣ��</td>
                <td colspan="3">    
                    <input name="Reward" id="Reward" class=" mini-textarea" style="width:350px"/>
                </td>
            </tr> 
              <tr>
                <td class="style2">��ʦ��飺</td>
                <td colspan="3">    
                    <input name="Introduction" id="Introduction" class=" mini-textarea" style="width:350px"/>
                </td>
            </tr> 
        </table>            
            </div>
        </fieldset>
        <div style="padding:3px; width:600px; margin-left:150px;">   
           
              <a class="mini-button" id="ajaxButton"  style="width:60px; margin-left:150px; margin-right:10px" onclick="onUpload">
              �ϴ�</a>
        <a class="mini-button" id="ok" onclick="onOk" style="width:60px;margin-right:10px">ȷ��</a>       
        <a class="mini-button" id="cancel" onclick="onCancel" style="width:60px;">ȡ��</a>       
    </div>
    </div>
    </form>
    
    
    <script type="text/javascript">

        var form = new mini.Form("form1");

        var formData = {};
        $(function(){
        GetMasterInfo();
        });
     


    </script>
</asp:Content>

