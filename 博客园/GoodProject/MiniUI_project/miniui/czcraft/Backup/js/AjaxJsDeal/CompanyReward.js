   //图片重绘
        function onReaderPic(e){
          return '<img src="../Admin/FileManage/GetImg.ashx?method=GetCompanyCert&type=small&fileName='+e.value+'" style="width:60px;height:40px;"/>';
        
        }
     
        function onActionRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;

            var s ='<a class="Delete_Button"  href="javascript:newRow()">增加</a>';
          s+= '<a class="Delete_Button"  href="javascript:delRow(\'' + uid + '\')">删除</a>';
                       
            return s;
        }

        function onSelectionChanged(e) {
            var grid = e.sender;
            var record = grid.getSelected();
            
            if (record) {
                editRow(record._uid);
            } else {                
                form.reset();
            }
        }

        function newRow() {            
            var row = {};
            grid.addRow(row, 0);

            editRow(row._uid);
        }
        function editRow(row_uid) {
            var row = grid.getRowByUID(row_uid);
            if (row) {
            

                //表单加载员工信息
                var form1 = new mini.Form("editForm1");
                if (grid.isNewRow(row)) {
                    
                    form1.reset();
                        //重置
                    $("#Picturepath").val("");//隐藏域设置图片的文件信息 
 
                    $('#PicpathShow').attr("src","");//回调显示图片
                    $('input:file').MultiFile('reset');//一定要重置
                } 
                else {
                    form1.loading();
                    $.ajax({
                        url: "Data/CompanyZoneInfo.ashx?method=GetCompanyReward&id=" + row.Id,
                        success: function (text) {
                            var o = mini.decode(text);
                            form1.setData(o);
                            //注意:图片处理
                            var src="../Admin/FileManage/GetImg.ashx?method=GetCompanyCert&type=small&fileName="+o.Picpath;
                            $("#PicpathShow").attr("src",src);
                            $("#Picturepath").val(o.Picpath);
                           
                            form1.unmask();
                        }
                    });
                }

                grid.doLayout();
            }
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
                        url: "Data/CompanyZoneInfo.ashx?method=RemoveCompanyReward&id=" + row.Id,
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
        
            var form = new mini.Form("editForm1");

            var o = form.getData();
        
         
            grid.loading("保存中，请稍后......");
           // var json = mini.encode([o]);
            $.ajax({
                url: "Data/CompanyZoneInfo.ashx?method=SaveCompanyReward&ImgPath="+$("#Picturepath").val(),
                data:{"Name":o.Name,"Id":$("#Id").val()},
                //data: { Reward: json },
                success: function (text) {
                    grid.reload();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });

        }
        function onUpload(e){
               
              $(form1).ajaxSubmit({
              url:'../Admin/FileManage/FileUpload.ashx?method=UploadCompanyCert',
               success: function(r){
                  var Json= eval("("+r+")");//(转义)解析json格式
                    if(Json.status=="success"){
                     var src="../Admin/FileManage/GetImg.ashx?method=GetCompanyCert&type=small&fileName="+Json.website;
                    $("#Picturepath").val(Json.website);//隐藏域设置图片的文件信息 
 
                    $('#PicpathShow').attr("src",src);//回调显示图片
                    $('input:file').MultiFile('reset');//一定要重置
                    
                     }
                     else{
                     alert("图片上传失败!");
                     }
                   }
         });
        }