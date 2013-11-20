 
        function onButtonEdit(e) {
            var btnEdit = this;

            
            mini.openTop({
                url: mini_JSPath + "../../Product/SelectCraftType.htm",                
                title: "类别选择面板",
                width: 400, 
                height: 400,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    iframe.contentWindow.SetData(null);
                },
                ondestory: function (action) {
                    if (action == "ok") {
                        var iframe = this.getIFrameEl();

                        var data = iframe.contentWindow.GetData();
                        
                        data = mini.clone(data);
                        mini.get("btnEdit1").setValue(data.id);
                        mini.get("btnEdit1").setText(data.text);
                       
                    }
                }
            });            
             
        }        
        function SaveData() {
            var o =form.getData();
              o.id = formData.id;
            o.Explain=editor1.html();
            var TypeID=mini.get("btnEdit1").value;
              o.Typeid= TypeID;
              
               var Lsprice=mini.get("Lsprice").value;
              o.Lsprice= Lsprice.toString(); //注意要转化为string给后台处理
             
               var Pfprice=mini.get("Pfprice").value;
              o.Pfprice= Pfprice.toString(); //注意要转化为string给后台处理
             
               var Vipprice=mini.get("Vipprice").value;
              o.Vipprice= Vipprice.toString(); //注意要转化为string给后台处理
             
               var MarketPrice=mini.get("MarketPrice").value;
              o.MarketPrice= MarketPrice.toString(); //注意要转化为string给后台处理
             
               var Price1=mini.get("Price1").value;
              o.Price1= Price1.toString(); //注意要转化为string给后台处理
             
               var Price2=mini.get("Price2").value;
              o.Price2= Price2.toString(); //注意要转化为string给后台处理
              
              var Price3=mini.get("Price3").value;
              o.Price3= Price3.toString(); //注意要转化为string给后台处理
              
              var Price4=mini.get("Price4").value;
              o.Price4= Price4.toString(); //注意要转化为string给后台处理
            
            
               
               form.validate();
            if (form.isValid() == false) return;
            var json =mini.encode(o);
          
            $.ajax({
                url: "Data/MasterZoneInfo.ashx?method=SaveProduct&id="+$("#Id").val()+"&pic="+$("#Picturepath").val(),
                
                data: { Product: json },
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
        function SetData(data) {
        
            if (data.action == "edit") {
                //跨页面传递的数据对象，克隆后才可以安全使用
                data = mini.clone(data);
                $.ajax({
                    url: "Data/MasterZoneInfo.ashx?method=GetProduct&id=" + data.id,  
                    cache: false,
                    success: function (text) {
                        var o = mini.decode(text);
                        form.setData(o); 
                      
             var src="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName="+o.Picturepath;
                    $("#Picturepath").val(o.Picturepath);//隐藏域设置图片的文件信息  
                    $("#fileupload").val(o.Picturepath);
                     $("#Id").val(data.id);
                     $('#pic').attr("src",src);//回调显示图片
                     editor1.html(o.Explain);
                      mini.get("btnEdit1").setValue(o.Typeid);////需要从后台读取
                      mini.get("btnEdit1").setText(o.Typename);
                       
                    }
                });
            }
            else if(data.action == "view"){  //查看会员信息 
             data = mini.clone(data);
                $.ajax({
                    url: "Data/MasterZoneInfo.ashx?method=GetProduct&id=" + data.id,
                    cache: false,
                    success: function (text) {
                        var o = mini.decode(text);
                        form.setData(o);
                    var src="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName="+o.Picturepath;
                    $("#Picturepath").val(o.Picturepath);//隐藏域设置图片的文件信息  
                    $("#fileupload").val(o.Picturepath);
                     $("#Id").val(data.id);
                     $('#pic').attr("src",src);//回调显示图片
                     editor1.html(o.Explain);
                      mini.get("btnEdit1").setValue(o.Typeid);////需要从后台读取
                      mini.get("btnEdit1").setText(o.Typename);
                
                        //禁用所有信息
                        $("#Name").attr("disabled","disabled");
                        $("#Simplename").attr("disabled","disabled");
                        $("#Explain").attr("disabled","disabled");
                        $("#Picturepath").attr("disabled","disabled");
                        $("#Material").attr("disabled","disabled");
                        $("#Isrecommend").attr("disabled","disabled");
                        $("#Isshow").attr("disabled","disabled");
                        $("#Weight").attr("disabled","disabled");
                        $("#Volume").attr("disabled","disabled");
                        $("#Specification").attr("disabled","disabled");
                        $("#Model").attr("disabled","disabled");
                        $("#Issell").attr("disabled","disabled");
                        $("#Isexcellent").attr("disabled","disabled");
                        $("#fileupload").attr("disabled","disabled");
                        $("#Nongenetic").attr("disabled","disabled");
                        $("#Isrecomment").attr("disabled","disabled");
                        $("#Isshow").attr("disabled","disabled");
                        $("#Num").attr("disabled","disabled");
                        $("#Soldnum").attr("disabled","disabled");
                        $("#Lsprice").attr("disabled","disabled");
                        $("#Pfprice").attr("disabled","disabled"); 
                        $("#MarketPrice").attr("disabled","disabled"); 
                        $("#Price1").attr("disabled","disabled"); 
                        $("#Price2").attr("disabled","disabled");
                        $("#Price3").attr("disabled","disabled");
                        $("#Price4").attr("disabled","disabled"); 
                        $("#Vipprice").attr("disabled","disabled"); 
                        
                        $("#ok").attr("disabled","disabled");
                        $("#ajaxButton").attr("disabled","disabled");
                         mini.get("btnEdit1").disable();
                        
                       
                    }
                });
            }
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
              url:'../Admin/FileManage/FileUpload.ashx?method=UpLoadProductPic',
               success: function(r){
                  var Json= eval("("+r+")");//(转义)解析json格式
                    if(Json.status=="success"){
                     var src="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName="+Json.website;
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