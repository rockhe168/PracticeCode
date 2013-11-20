   function SaveData() {
            var o =form.getData();
            form.validate();
            
            if (form.isValid() == false) return;
            var json =mini.encode(o);
            $.ajax({
                url: "Data/MasterZoneInfo.ashx?method=SaveMaster&id="+$("#id").val()+"&pic="+$("#Picturepath").val()+"&ProductType="+mini.get("ProductType").getValue(),
                
                data: { Master: json },
                cache: false,
                success: function (text) {

                    CloseWindow("save");
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                    CloseWindow();
                }
            });
        }
           ////////////////////
      
        function GetData() {
            var o = form.getData();
            return o;
        }
         ////////////////////
        //标准方法接口定义
        function GetMasterInfo() {
                $.ajax({
                    url: "Data/MasterZoneInfo.ashx?method=GetMaster",  
                    cache: false,
                    success: function (text) {
                        var o = mini.decode(text);
                        form.setData(o); 
                        $("#id").val(o.Id);
               var src="../Admin/FileManage/GetImg.ashx?method=GetMasterPic&type=medium&fileName="+o.Picturepath;
                    $("#Picturepath").val(o.Picturepath);//隐藏域设置图片的文件信息  
                    $("#fileupload").val(o.Picturepath);
                     $('#pic').attr("src",src);//回调显示图片
                     mini.get("ProductType").setValue(o.CraftTypes);
                      mini.get("ProductType").setText(o.CraftTypesName);
                    }
                });
               
            }

        function CloseWindow(action) {
            if (window.CloseOwnerWindow) window.CloseOwnerWindow(action);
            else window.close();
        
        }
        function onOk(e) {
           if($("#Picturepath").val()=="")
           {
           alert("请先上传图片");
           return;
           }
           else{
                SaveData();  
            }
        }
        function onCancel(e) {
            CloseWindow( "cancel");
        }
        function onUpload(e){
               
              $(form1).ajaxSubmit({
              url:'../Admin/FileManage/FileUpload.ashx?method=UpLoadMasterPic',
               success: function(r){
                  var Json= eval("("+r+")");//(转义)解析json格式
                    if(Json.status=="success"){
                     var src="../Admin/FileManage/GetImg.ashx?method=GetMasterPic&type=medium&fileName="+Json.website;
                    $("#Picturepath").val(Json.website);//隐藏域设置图片的文件信息 
 
                    $('#pic').attr("src",src);//回调显示图片
                    $('input:file').MultiFile('reset');//一定要重置
                    
                     }
                     else{
                     alert("图片上传失败!");
                     }
                   }
         });
        }
       