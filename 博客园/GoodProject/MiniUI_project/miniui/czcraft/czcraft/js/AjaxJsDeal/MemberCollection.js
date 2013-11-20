       //操作重绘
             function onActionRenderer(e) {
            var CurrentGrid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
        var row = CurrentGrid.getRowByUID(uid);
            var s = ''
                    + ' <a class="button" href="javascript:AddCart(\''+row.ProductId+'\',\''+row.SupperName+'\')"></a>'+ ' <a class="del" href="javascript:delRow(' + row.ProductId + ')"></a>';
            return s;
        }
          
            
            //产品名称超链接重绘
            function onRenderProductName(e){
             var CurrentGrid = e.sender;
               var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = CurrentGrid.getRowByUID(uid);
             var href='<a href="/Product/Product.aspx?ProductId='+row.ProductId+'" >'+ row.Name+'</a>';
      return href;
            }
            //产品超链接重绘
            function onRenderProduct(e){
             var CurrentGrid = e.sender;
               var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = CurrentGrid.getRowByUID(uid);
             var href='<a href="/Product/Product.aspx?ProductId='+row.ProductId+'" >'+ row.ProductId+'</a>';
      return href;
            
            }
       //图片重绘
        function onReaderPic(e){
         var CurrentGrid = e.sender;
          var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = CurrentGrid.getRowByUID(uid);
              var src= '<img src="/Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=small&fileName='+e.value+'" style="width:60px;height:40px;"/>';
             var href='<a href="/Product/Product.aspx?ProductId='+row.ProductId+'" >'+ src+'</a>';
      return href;
        
        }
        //卖家网址重绘
          function RendererSupperlierName(e) {
           var CurrentGrid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = CurrentGrid.getRowByUID(uid);
            var Belongstype=row.Belongstype;
            var BelongWebSize;
            if(Belongstype==0)
            {
            BelongWebSize="/Master/MasterInfo.aspx?MasterId="+row.Masterid;
            }
            else
             BelongWebSize="/Company/CompanyInfo.aspx?CompanyId="+row.Companyid;
            var s = '<a href="'+BelongWebSize+'" >'+row.SupperName+'</a>';
           
            return s;
        }
          var IsBuyStatus = [{ id: "1", text: '曾经购买' }, { id: "0", text: '未买过'}];
        //是否购买过
        function onIsBuyRenderer(e){
           for (var i = 0, l = IsBuyStatus.length; i < l; i++) {
                var g = IsBuyStatus[i];
                var temp;
                if(e.value == g.id){
                 temp='<font style="color:red" >'+g.text+'</font>';
                 return temp;
                }
                 
               
          }
        }
          function delRow(id) {
          
            if (id) {
                if (confirm("确定删除此记录？")) {
                    grid.loading("删除中，请稍后......");
                    $.ajax({
                        url: "Data/GetMemberInfo.ashx?method=RemoveCollection&Id=" + id,
                        success: function (text) {
                            grid.reload();
                           
                        },
                        error: function () {
                        }
                    });
                }
            }
        }
        //加入购物车
        function AddCart(id,SupperName) {
            $.ajax({
                url: "/Product/Data/GetProductInfo.ashx?method=AddShoppingCart",
                data: {Id:id,SupperlierName:SupperName},
                success: function (text) {
                 var DataJson=$.parseJSON(text);
                 if(DataJson.Status=='True'){
                    alert('加入购物车成功!');
                    grid.reload();
                    grid2.reload();
                    }
                    else
                     alert(DataJson.Data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(jqXHR.responseText);
                }
            });

        }