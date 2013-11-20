
 

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
        href='../Master/MasterInfo.aspx?MasterId='+jsonData.Data[0].BelongId;
        else// if(jsonData.Data[0].BelongType=='1')
         href='../Company/CompanyInfo.aspx?CompanyId='+jsonData.Data[0].BelongId;
        
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
      
     }
    }
    });
    
    }