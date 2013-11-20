       ////////////////////排名管理//////////////////////////
       function onActionRenderer(e) {
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;

            var s = ' <a class="Edit_Button" href="javascript:editPic()">编辑图片</a>';
            s+=' <a class="Edit_Button" href="javascript:edit()">编辑</a>';
            s+=' <a class="Edit_Button" href="javascript:view()">查看</a>';

          
            return s;
        }
        
       /////////////////////////////////////////////
        function add(e) {
            mini.openTop({
                url: mini_JSPath + "../../../CompanyZone/CompanyAddProduct.htm",
                title: "产品注册", width: 620, height: 628,
                onload: function () {
                    var iframe = this.getIFrameEl();
                    var data = { action: "new"};
                    iframe.contentWindow.SetData(data);
                },
                ondestory: function (action) {
                    grid.reload();
                }
            });
        }
        //编辑图片
        function editPic(e){
         var row = grid.getSelected();
            if (row) {
            window.location.href=ProductPicManageURL+'?ProductId='+ row.Id;
            } 
            else {
                alert("请选中一条记录");
            }
        
        }
        function edit(e) {
            var row = grid.getSelected();
            if (row) {
                mini.openTop({
                    url: mini_JSPath + "../../../CompanyZone/CompanyAddProduct.htm",
                    title: "编辑产品信息",  width: 620, height: 628,
                    onload: function () {
                        var iframe = this.getIFrameEl();
                        var data = { action: "edit", id: row.Id };
                        iframe.contentWindow.SetData(data);
                    },
                    ondestory: function (action) {                    
                        grid.reload();
                    }
                });
                
            } else {
                alert("请选中一条记录");
            }
            
        }
         function view(e) {
            var row = grid.getSelected();
            if (row) {
                mini.openTop({
                    url: mini_JSPath + "../../../CompanyZone/CompanyAddProduct.htm",
                    title: "查看产品信息", width: 620, height: 628,
                    onload: function () {
                        var iframe = this.getIFrameEl();
                        var data = { action: "view", id: row.Id };
                        iframe.contentWindow.SetData(data);
                    },
                    ondestory: function (action) {                    
                       // grid.reload();
                    }
                });
                
            } else {
                alert("请选中一条记录");
            }
            
        }
        function remove(e) {
            var rows = grid.getSelecteds();
            if (rows.length > 0) {
                if (confirm("确定删除选中产品记录？")) {
                    var ids = [];
                    for (var i = 0, l = rows.length; i < l; i++) {
                        var r = rows[i];
                        ids.push(r.Id);
                    }
                    var id = ids.join(',');
                    grid.loading("操作中，请稍后......");
                    $.ajax({
                        url: "../Admin/Product/Data/GetProductInfo.ashx?method=RemoveProduct&id=" +id,
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
        function search(e) {
         var  key= mini.get("key");
        grid.load({ key: key.value });
        }
        $("#search").bind("click",function(e)
        {
        search(e);
        });
        $("#key").bind("keydown", function (e) {
            if (e.keyCode == 13) {
                search(e);
            }
        });