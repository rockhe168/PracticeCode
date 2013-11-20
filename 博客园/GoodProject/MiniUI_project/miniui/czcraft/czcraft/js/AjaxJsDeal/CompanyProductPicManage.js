   //图片重绘
        function onReaderPic(e){
          return '<img src="../Admin/FileManage/GetImg.ashx?method=GetOtherProductPic&type=small&fileName='+e.value+'" style="width:60px;height:40px;"/>';
        
        }
     
        function onActionRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;

            var s ='';
          s+= '<a class="Delete_Button"  href="javascript:delRow(\'' + uid + '\')">删除</a>';
                       
            return s;
        }

    
        function cancelRow() {
            grid.reload();
        }
        function delRow(row_uid) {
            var row = grid.getRowByUID(row_uid);
            if (row) {
                if (confirm("确定删除此记录？")) {
                    grid.loading("删除中，请稍后......");
                    $.ajax({
                        url: "Data/CompanyZoneInfo.ashx?method=RemoveOtherProductPic&id=" + row.Id,
                        success: function (text) {
                            grid.reload();
                        },
                        error: function () {
                        }
                    });
                }
            }
        }
        function OnUpdate(e){
         if($("#Picturepath").val()=="")
           {
           alert("请先上传图片");
           return;
           }
           else{
                updateRow();  
            }
        
        }
        
        function updateRow() {
            grid.loading("保存中，请稍后......");
            $.ajax({
                url: "Data/CompanyZoneInfo.ashx?method=SaveProductPic",
                data:{"Id":$("#Id").val(),"PicList":$("#Picturepath").val()},
                success: function (text) {
                    grid.reload();
                      $('input:file').MultiFile('reset');//一定要重置
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });

        }
        function onUpload(e){
               
              $(form1).ajaxSubmit({
              url:'../Admin/FileManage/FileUpload.ashx?method=UpLoadOtherProductPic',
               success: function(r){
                  var Json= eval("("+r+")");//(转义)解析json格式
                    if(Json.status=="success"){
//                    alert(Json.website);
                    $("#Picturepath").val(Json.website);//隐藏域设置图片的文件信息 
                    //更新图片信息
                    updateRow();
                    
                     }
                     else{
                     alert("图片上传失败!");
                     }
                   }
         });
        }