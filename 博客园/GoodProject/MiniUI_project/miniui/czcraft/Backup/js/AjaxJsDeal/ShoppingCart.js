   //购物车汇总信息
            function GetCartInfo(){
             $.ajax({
           url:"/Member/Data/GetMemberInfo.ashx?method=GetCartInfo",
           type:"post",
           success:function(text){
           var DataJson=$.parseJSON(text);
            if(DataJson.Status)//执行成功!
            {
                //显示当前购物车总数量和总价 
                $("#lbCountNum").text(DataJson.Data[0].CartSum); 
                 $("#lbCountNum1").text(DataJson.Data[0].CartSum); 
                 //$("#CartMsg").html('目前购物车中已有'+DataJson.Data[0].CartCount+'件宝贝，合计：<span>'+DataJson.Data[0].CartSum+'</span>元');         
            }
            else
            alert("加载购物车汇总信息出错!");
           }
           });
            }
             //操作重绘
             function onActionRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;

            var s = ''
                    + ' <a class="Edit_Button" href="javascript:editRow(\'' + uid + '\')">编辑</a>'
                    + ' <a class="Delete_Button" href="javascript:delRow(\'' + uid + '\')">删除</a>';

            if (grid.isEditingRow(record)) {
                s = '<a class="Update_Button" href="javascript:updateRow(\'' + uid + '\')">更新</a>'
                    + '<a class="Cancel_Button" href="javascript:cancelRow(\'' + uid + '\')">取消</a>'
            }
            return s;
        }
          
            
            //产品名称超链接重绘
            function onRenderProductName(e){
               var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
             var href='<a href='+ProductURL+'"?ProductId='+row.ProductId+'" >'+ row.ProductName+'</a>';
      return href;
            }
            //产品超链接重绘
            function onRenderProduct(e){
               var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
             var href='<a href="'+ProductURL+'?ProductId='+row.ProductId+'" >'+ row.ProductId+'</a>';
      return href;
            
            }
       //图片重绘
        function onReaderPic(e){
          var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
              var src= '<img src="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=small&fileName='+e.value+'" style="width:60px;height:40px;"/>';
             var href='<a href="'+ProductURL+'?ProductId='+row.ProductId+'" >'+ src+'</a>';
      return href;
        
        }
        //卖家网址重绘
          function RendererSupperlierName(e) {
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
            var SupperlierName=row.SupperlierName;
            var SupperlierId=row.SupperlierId;
            var BelongType=row.BelongType;
            var BelongWebSize;
            if(BelongType==0)
            {
            BelongWebSize=MasterInfoURL+"?MasterId="+SupperlierId;
            }
            else
             BelongWebSize=CompanyInfoURL+"?CompanyId="+SupperlierId;
            var s = '<a href="'+BelongWebSize+'" >'+SupperlierName+'</a>';
           
            return s;
        }
           function editRow(row_uid) {
            var row = grid.getRowByUID(row_uid);
            if (row) {
                grid.cancelEdit();
                grid.beginEditRow(row);
            }
        }
        function cancelRow(row_uid) {            
            grid.reload();
        }
        function delRow(row_uid) {
            var row = grid.getRowByUID(row_uid);
            if (row) {
                if (confirm("确定删除此记录？")) {
                    grid.loading("删除中，请稍后......");
                    $.ajax({
                        url: "Data/GetMemberInfo.ashx?method=RemoveShoppingCart&Id=" + row.Id,
                        success: function (text) {
                            grid.reload();
                            GetCartInfo();
                        },
                        error: function () {
                        }
                    });
                }
            }
        }

        function updateRow(row_uid) {
            var row = grid.getRowByUID(row_uid);

            var rowData = grid.getEditRowData(row);
         if(parseInt(row.Num-row.Soldnum)<parseInt(rowData.Quantity))
            {
            alert("当前库存不足!");
            rowData.Quantity=parseInt(row.Num-row.Soldnum);
            return;
            }
            grid.loading("保存中，请稍后......");
            var json = mini.encode([{Id: row.Id,Quantity:rowData.Quantity,ProductId:row.ProductId}]);
            $.ajax({
                url: "Data/GetMemberInfo.ashx?method=SaveShoppingCart",
                data: {ShoppingCart:json},
                success: function (text) {
                    grid.reload();
                     GetCartInfo();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });

        }
        //批量删除
         function remove(e) {
            var rows = grid.getSelecteds();
            if (rows.length > 0) {
                if (confirm("确定删除选中商品？")) {
                    var ids = [];
                    for (var i = 0, l = rows.length; i < l; i++) {
                        var r = rows[i];
                        ids.push(r.Id);
                    }
                    var id = ids.join(',');
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                         url: "Data/GetMemberInfo.ashx?method=RemoveShoppingCart&Id=" + id,
                        success: function (text) {
                            grid.reload();
                             GetCartInfo();
                        },
                        error: function () {
                        }
                    });
                }
            } else {
                alert("请选中一条记录");
            }
        }
   //操作重绘
             function onSumRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
            return row.Price*row.Quantity;
        }
        
        //提交信息(购物车订单页面)
      function Comit(){
      $("#btnCommit").click(function(){
          //省市县资料获取
        var province= $("#selProvince").find('option:selected').text();
        var City= $("#selCity").find('option:selected').text();
        var Country= $("#Country").find('option:selected').text();
               //提交表单数据
            var OrderData={"Name":$("#Name").val(),"Email":$("#txtEmail").val(),"Province":province,"City":City,"Country":Country,"Address":
$("#txtHomeBase").val(),"ZipCode":$("#txtZipCode").val(),"MobilePhone":
 $("#txtMobilePhone").val(),"TelPhone":$("#txtTelPhone").val()};
          
           
            $.ajax({
                url: "/Member/Data/GetMemberInfo.ashx?method=SubmitOrderData",
                type: "post",
                data: OrderData,
                success: function (text) {
                 var DataJson=$.parseJSON(text);
                  if(DataJson.Status!='False'){
                  alert("尊敬的用户:"+DataJson.Data);
                  window.location.href=OrderManageURL;//'/Member/OrderManage.aspx';
                }
                else
                 alert(DataJson.Data);
                }
            });

      
      });
      }