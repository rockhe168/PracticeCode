
    //获取企业图片信息
    function GetCompanyInfo(){
    $.ajax({
    url:"Data/CompanyInfo.ashx?method=GetCompanyPic&CompanyId="+id,
    type:"post",
    success:function(text){
     var jsonData=$.parseJSON(text);
     if(jsonData.Status){    
      // <li><a href="c_pic.html"><img src="images/slide_1.jpg" alt="company1"/></a></li>         PicName PicPath CompanyId PicId
      var item="";
      $.each(jsonData.Data,function(key, value){
       var src="../Admin/FileManage/GetImg.ashx?method=GetLogoCompanyPic&type=medium&fileName="+value.PicPath;
      item+='<li><a href="#"><img src="'+src+'" alt="'+value.PicName+'"/></a></li>';
      });
      
      $("#ulCompanyPic").empty();
      $("#ulCompanyPic").append(item);
       
     
     }
    }
    });
    
    }
    //获取企业简介信息
     function GetCompanyIntro(){
      $.ajax({
    url:"Data/CompanyInfo.ashx?method=GetCompanyIntro&CompanyId="+id,
    type:"post",
    success:function(text){
      var jsonData=$.parseJSON(text);
     if(jsonData.Status){     
       var item='<h4>企业简介</h4>';
       item+='<p>'+jsonData.Data[0].Introduction+'</p>';
      $("#CompanyContent").empty();
      $("#CompanyContent").append(item);
       }
      }
      });
     }
     //获取企业荣誉信息
     function GetCompanyReward(){
  $.ajax({
    url:"Data/CompanyInfo.ashx?method=GetCompanyReward&CompanyId="+id,
    type:"post",
    success:function(text){
      var jsonData=$.parseJSON(text);
      var item='<h4>企业荣誉</h4>';
     if(jsonData.Status){     
       item+='<ul class="gs_reward">';
       item+=' <li>'+jsonData.Data[0].Reward+'</li></ul>';
       item+=' <h4>获奖情况</h4><ul class="gs_cup">';
      $.each(jsonData.Data[0].CertPicList,function(key,value){
        var img="../Admin/FileManage/GetImg.ashx?method=GetCompanyCert&type=medium&fileName="+value.CertPic;
      item+='<li><span class="c_pic_a">';
     item+='<img src='+img+' alt='+value.CertName+' title='+value.CertName+'/></span><span class="a_title">'+value.CertName+'</span>';
      item+='</li>';
      });
      item+='</ul>';
     
       }
       else{
        item+=' <h4>获奖情况</h4>';
       }
        $("#CompanyContent").empty();
      $("#CompanyContent").append(item);
      }
      });
     }
     //获取企业产品信息
  function GetCompanyWork(ProductURL,Company_MoreProductURL){
  $.ajax({
    url:"Data/CompanyInfo.ashx?method=GetCompanyWork&CompanyId="+id,
    type:"post",
    success:function(text){
      var jsonData=$.parseJSON(text);
     var item='';
     if(jsonData.Status){ 
     $.each(jsonData.Data,function(key,value){    
       item+='<h4>'+value.TypeName+'</h4>';
       item+='<ul class="gs_pic">';
         $.each(value.Product,function(PKey,PValue){
               var img="../Admin/FileManage/GetImg.ashx?method=GetMainProductPic&type=medium&fileName="+PValue.Picturepath;
               item+='<li>';
                  item+='<a href="'+ProductURL+'?ProductId='+PValue.ProductId+'" class="c_pic_a"><img src="'+img+'" alt="'+PValue.Name+'" title="'+PValue.SimpleName+'"/></a>';
                  item+='<a href="'+ProductURL+'?ProductId='+PValue.ProductId+'" class="a_title">'+PValue.SimpleName+'<br/><span class="rad2">￥'+PValue.Lsprice+'</span></a> ';
               item+='</li>';
                             })
       item+='</ul>';
       item+='<div style="text-align:right"><a href="'+Company_MoreProductURL+'?CompanyId=' + id + '&&TypeId=' + value.TypeId + '">more>></a></div>';
      
       })
    
      }
      else{
      item+='没有数据!';
      }
        $("#CompanyContent").empty();
      $("#CompanyContent").append(item);
      }
      });
     }
     