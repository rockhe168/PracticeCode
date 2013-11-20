 //加入收藏
   function AddCollection(id){
   $("#btnAddCollection").click(function(){
      $.ajax({
           url:"/Product/Data/GetProductInfo.ashx?method=AddCollection",
           data:{Id:id,SupperlierName:$("#SupperlierName").val()},
           type:"post",
           success:function(text){
           var DataJson=$.parseJSON(text);
            if(DataJson.Status&&DataJson.Status=='True')//执行成功!
            {
            alert("加入收藏成功!");
            }
            else
            alert(DataJson.Data);
           }
           });
   });
   }
  //加入购物车
  function AddCart(id){
   
    //加入购物车
    $("#btnAddCart").click(function(){    
           $.ajax({
           url:"/Product/Data/GetProductInfo.ashx?method=AddShoppingCart",
           data:{Id:id,SupperlierName:$("#SupperlierName").val()},
           type:"post",
           success:function(text){
           var DataJson=$.parseJSON(text);
            if(DataJson.Status!='False')//执行成功!
            {
                //显示当前购物车总数量和总价  
                 $("#CartMsg").html('目前购物车中已有'+DataJson.Data[0].CartCount+'件宝贝，合计：<span>'+DataJson.Data[0].CartSum+'</span>元');         
             //弹出层
            showFloat();
            }
            else
            alert(DataJson.Data);
           }
           });
   });
   }

   
   //获取产品所有附属图片信息
   function GetProductPic(id){
    $.ajax({
    url:"Data/GetProductInfo.ashx?method=GetProductAllPic&ProductId="+id,
    type:"post",
    success:function(text){
     var jsonData=$.parseJSON(text);
        if(jsonData.Status){    
            var item='';
              var src='../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName='+jsonData.Data[0].MainPic;
            item+='<li><img src="'+src+'" /></li>';
            $.each(jsonData.Data[0].OtherPic,function(key,value){
            var otherSrc='../Admin/FileManage/GetImg.ashx?method=GetOtherProductPic&type=medium&fileName='+value.PicturePath;
            item+='<li><img src="'+otherSrc+'" /></li>';
       
            });
                
                      
                    
             $("#ulOtherPic").empty();

             $("#ulOtherPic").append(item);
              
                }
            }
     });
   }   
   //获取产品基本信息
    function GetProductInfo(id){
    $.ajax({
    url:"Data/GetProductInfo.ashx?method=GetProduct&ProductId="+id,
    type:"post",
    success:function(text){
     var jsonData=$.parseJSON(text);
     if(jsonData.Status){             
     //设置标题
      $("#pTitle").text(jsonData.Data[0].ProductName);
      //加载商品数据信息
      $("#tbProductInfo").empty();
     var item='';
     item+='<tr><td width="87">【类型】：</td>';
     item+='<td width="142">'+jsonData.Data[0].TypeName+'</td></tr>';
     var href='';
      if(jsonData.Data[0].BelongType=='0')
        href=MasterInfoURL+'?MasterId='+jsonData.Data[0].BelongId;
        else// if(jsonData.Data[0].BelongType=='1')
         href=CompanyInfoURL+'?CompanyId='+jsonData.Data[0].BelongId;
        
     item+='<tr><td>【所属】：</td><td><a href='+href+'>'+jsonData.Data[0].BelongName+'</a></td></tr>';
     item+='<tr><td>【价格】：</td><td>￥'+jsonData.Data[0].LsPrice+'元 </td></tr>';
     item+=' <tr><td>【数量】：</td><td>'+(jsonData.Data[0].Num-jsonData.Data[0].SoldNum)+'/'+jsonData.Data[0].Num+'</td></tr>';
      $("#tbProductInfo").append(item);
      var item2='<h4>作品简介</h4>'+jsonData.Data[0].Explain;
      $("#ProductIntro").append(item2);
        //为商品追加图片
        var src="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName="+jsonData.Data[0].PicturePath;
      $("#CurrentPic").attr("src",src);
       $("#CurrentPic").attr("jqimg",src);
      //在隐藏字段中保存供应商名称
      $("#SupperlierName").val(jsonData.Data[0].BelongName);
      
     }
    }
    });
    
    }
       function changeImg(){
      $("#imgCode").attr("src","../Admin/FileManage/VerifyChars.ashx?date="+new Date());
      
      }
 //获取用户信息
      function GetUserInfo(){
        $.ajax({
            url:"../Member/Data/GetMemberInfo.ashx?method=GetUserInfo",
            type:"post",
            success:function(text){
                var DataJson=$.parseJSON(text);
                if(DataJson.Status){
                  $("#txtUserName").val(DataJson.Data[0].UserName);
                  $("#txtQQ").val(DataJson.Data[0].QQ);
                  $("#txtMobilePhone").val(DataJson.Data[0].MobilePhone);
                   
                  }
                 
                
                }
            });
      
      }
      function ComitInfo(){
      $("#btnComit").click(function(){
      var Data={"UserName":$("#txtUserName").val(),"QQ":$("#txtQQ").val(),"MobilePhone": $("#txtMobilePhone").val(),"CheckCode":$("#txtCheckCode").val(),"Content":$("#txtContent").val()};
       $.ajax({
            url:"Data/GetProductInfo.ashx?method=SaveComment",
            type:"post",
            success:function(text){
                var DataJson=$.parseJSON(text);
                if(DataJson.Status){
                }
                 
                
                }
            });
      
      });
      
      }