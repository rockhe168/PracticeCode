        function showWindow() {
        var win = mini.get("comment");
            win.show();
         }
         //产品评论
         function onRenderComment(e){
            var grid = e.sender;
            var record = e.record;
            var uid = record._uid;
            var rowIndex = e.rowIndex;
             var row = grid.getRowByUID(uid);
            
             if(row.PaymentStatus==2&&row.OrderState!=3){
             //保存orderproduct中id的值,用于评论
             $("#OrderProId").val(row.Id);
             var s='';
             s+= '<p><a style="color:blue;" href="javascript:showWindow()">评论</a></p>';
             }
            return s;
         }
           function changeImg(){
      $("#img").attr("src","../Admin/FileManage/VerifyChars.ashx?date="+new Date());
      }
      //提交评论
      function CommitComment(){
      $("#btnSubmit").click(function(){
       
        var Data={"Content":$("#txtContent").val(),"hidStar":$("#hidStar").val(),"CheckCode":$("#txtCheckCode").val(),"OrderProId":$("#OrderProId").val()};
         $.ajax({
            url:"Data/GetMemberInfo.ashx?method=SaveComment",
            data:Data,
            type:"post",
            success:function(text){
                var DataJson=$.parseJSON(text);
                if(DataJson.Status){
                   alert("评论成功!");
                   window.location.href=MemberInfoURL;
                   }
                }
            });
      });
      }
$(function() {
    //初始化星级事件
    CommentStar("#comment #stars", "#comment #stars a", "#hidStar");
      var OrderId=$.query.get("OrderId"); 
      if(OrderId){
        grid.load({
            key: OrderId,
            pageIndex: 0,
            pageSize: 10,
            sortField: "ShopDate",
            sortOrder: "desc"
            });
            CommitComment();
      }
});