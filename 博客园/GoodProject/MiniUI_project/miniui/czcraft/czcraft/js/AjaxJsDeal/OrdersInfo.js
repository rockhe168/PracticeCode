        //获取用户信息
      function GetOrdersUserInfo(){
        $.ajax({
            url:"Data/GetMemberInfo.ashx?method=GetMemberMoreInfo&id="+OrderId,
            type:"post",
            success:function(text){
                var DataJson=$.parseJSON(text);
                if(DataJson.Status){
                  $("#ConsigneeRealName").val(DataJson.Data[0].ConsigneeRealName);
                  $("#ConsigneeAddress").val(DataJson.Data[0].ConsigneeAddress);
                  $("#ConsigneeTel").val(DataJson.Data[0].ConsigneeTel);
                  $("#ConsigneeEmail").val(DataJson.Data[0].ConsigneeEmail);
                  $("#ConsigneePhone").val(DataJson.Data[0].ConsigneePhone);
                  $("#ConsigneeZip").val(DataJson.Data[0].ConsigneeZip);
                      
                   }
                }
            });
      }
              //获取状态
              function GetStatus(id){
                for (var i = 0, l = PayStatus.length; i < l; i++) {
                var g = PayStatus[i];
                if (id == g.id) return g.text;
            }
            return "";
              }
    //订单详情重绘
             function onRenderOrders(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
             //获取订单状态
             var PayStatus=GetStatus(row.PaymentStatus);
             
             var s='<p style="color:red;" >'+PayStatus+'</p>';
             s+= '<p><a style="color:blue;" href="'+OrderDetailURL+'?OrderId=' + row.OrderId + '">订单详情</a></p>'
            return s;
        }
        //确认收货
        function onRenderCofirmGetGoods(e){
          var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
              var s='';
             //获取订单状态
             if(row.PaymentStatus==2){
             s+='<a href="http://www.alipay.com"><img src="/images/confirm.gif" /></a>';
            // s+=' <a class="Edit_Button" style="color:blue;" href="javascript:DelOrder(\'' + uid + '\')">取消订单</a>';
            s+=' <a class="Edit_Button" style="color:blue;" href="http://www.alipay.com">取消订单</a>';
             
             }
            return s;
        }
        //订单状态
        function onRenderComfirm(e){
         var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
             //获取订单状态
             var OrderStatus=GetOrdersStatus(row.OrderStatus);
             
             var s='<p style="color:red;" >'+OrderStatus+'</p>';
             s+= '<p><a style="color:blue;" href="'+OrderDetailURL+'?OrderId=' + row.OrderId + '">订单详情</a></p>';
            return s;
        }
          //操作重绘
            function onRenderDeal(e){
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
              var s='';
             //获取订单状态
             if(row.PaymentStatus==0){
             s+='<a href="javascript:Pay(\''+uid+'\')"><img src="/images/fukuan.jpg" /></a>';
            // s+=' <a class="Edit_Button" style="color:blue;" href="javascript:DelOrder(\'' + uid + '\')">取消订单</a>';
             s+=' <a class="Edit_Button" style="color:blue;" href="http://www.alipay.com">取消订单</a>';
             }
            return s;
            }
            //产品名称超链接重绘
            function onRenderProductName(e){
               var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
             var href='<a href="'+ProductURL+'?ProductId='+row.ProId+'" >'+ row.ProName+'</a>';
      return href;
            }
            //产品超链接重绘
            function onRenderProduct(e){
               var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
             var href='<a href="'+ProductURL+'?ProductId='+row.ProId+'" >'+ row.ProId+'</a>';
      return href;
            
            }
       //图片重绘
        function onReaderPic(e){
          var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
              var src= '<img src="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=small&fileName='+e.value+'" style="width:60px;height:40px;"/>';
             var href='<a href="'+ProductURL+'?ProductId='+row.ProId+'" >'+ src+'</a>';
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
         //付款
        function Pay(row_uid){
         var rows = grid.getSelecteds();
            if (rows.length > 0) {
                if (confirm("确定付款么？")) {
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                         url: "Data/GetMemberInfo.ashx?method=PayOrders&OrderId=" + rows[0].OrderId,
                        success: function (text) {
                        var DataJson=$.parseJSON(text);
                        if(DataJson.Status!='False'){
                        window.location.href=DataJson.URL;
                        }
                         //    grid.reload();
                        },
                        error: function () {
                        }
                    });
                }
            } else {
                alert("请选中一条记录");
            }
        }
        //取消订单
        function DelOrder(row_uid){
          var rows = grid.getSelecteds();
            if (rows.length > 0) {
                if (confirm("确定取消订单？")) {
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                         url: "Data/GetMemberInfo.ashx?method=CancelOrders&OrderId=" + rows[0].OrderId,
                        success: function (text) {
                            grid.reload();
                        },
                        error: function () {
                        }
                    });
                }
            } else {
                alert("请选中一条记录");
            }
        
        }
        function updateRow(row_uid) {
            var row = grid.getRowByUID(row_uid);

            var rowData = grid.getEditRowData(row);
            
            grid.loading("保存中，请稍后......");
            var json = mini.encode([{Id: row.Id,Quantity:rowData.ProNum,ProductId:row.ProId}]);
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
            return row.ProPrice*row.ProNum;
        }
        