        //获取新闻类别
        function GetNewsType(){
          $.ajax({
         url:'/News/Data/GetNewsInfo.ashx?method=GetNewsTypeForCombox', 
          type:"get",
         success:function(text){
         
         var JsonData=$.parseJSON(text);
        // alert(text);
           $("#m2").empty();//先清空m2子元素的内容
           $.each(JsonData,function(key,value){   //注意这里
               //这里链接还需要添加具体页面 
             $("#m2").append('<a href=\"'+NewsListURL+'?TypeId='+value.TypeId+'\">'+value.TypeName+'</a>');     
           });
         }
         });
        }
          //获取工艺知识类别
        function GetProductType(){
         
        $.ajax({
         url:'/Product/Data/GetProductInfo.ashx?method=GetTopCraftTypeInfo',
         type:"get",
         success:function(text){
        
         var JsonData=$.parseJSON(text);
           $("#m1").empty();//先清空m1子元素的内容
           $("#CraftType").empty();//清空左侧类别信息
            $("#m3").empty();
           $("#m4").empty();
           $.each(JsonData,function(key,value){   //注意这里
               //这里链接还需要添加具体页面 
               //工艺类别加载
             $("#m1").append('<a href="'+CraftKnowledgeListURL+'?FId='+value.FId+'">'+value.TypeName+'</a>'); 
                 //非遗作品加载
               $("#m3").append('<a href="'+SearchProductURL+'?FId='+value.FId+'&Condition=Nongenetic">'+value.TypeName+'</a>'); 
               //作品展览加载   
                   $("#m4").append('<a href=\"'+SearchProductURL+'?FId='+value.FId+'">'+value.TypeName+'</a>');    
             //左侧类别加载
               $("#CraftType").append('<li><a href=\"'+CraftKnowledgeListURL+'?FId='+value.FId+'">'+value.TypeName+'</a></li>'); 
                   
           });
         }
         });
        
        }