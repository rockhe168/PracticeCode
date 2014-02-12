define(function(require,exports){
 require("./jquery.lazyload");
 var $=jQuery;
 var Gallery={
		template:{//模板
		  group_pics_data:
		   '{{#group}}\
		      <ul id="col_{{col_num}}" class="colum" style="width: 238px; top: {{top}};">\
		        {{#list}}\
				<li class="imgobj_wrapper  w230 imgset0">\
				<div class="inner_wrapper">\
				<a target="_blank" href="" class="detail_link imgobj"><img data-original="{{obj_url}}" class="lazy" src="img/grey.gif" width="{{thumbnail_width}}" height="{{thumbnail_height}}" class="img_loaded" id="img_{{id}}"></a>\
				<div class="imgobj_info_container">\
				<div class="padding_wrapper">\
				<a target="_blank" class="abs" href="http://www.juemei.cc/html/list/heaefa_abeag-7.html?p=7">{{tags}}</a>\
				<a target="_blank" class="from_site" href="{{from_url}}">来自<span class="site_name"></span>&nbsp;<span class="site_url">{{site_url}}</span></a>\
				<span class="size_info">{{image_width}}x{{image_height}}</span>\
				</div>\
				</div>\
				<div class="imgset_num"><span class="num">{{album_obj_num}}</span>张</div>\
				</div>\
				<div class="left_bg"></div>\
				<div class="right_bg"></div>\
				<div class="personal_container">\
				<a class="btn download" title="下载原图到电脑" href="javascript:void(0);"><span>3</span></a>\
				<a class="btn addfav" title="收藏到我的相册" id="addfav_0" href="javascript:void(0);"></a>\
				</div>\
				</li>\
				{{/list}}\
			  </ul>\
			{{/group}}',
			item_pics_data:
			   '{{#list}}\
				<li class="imgobj_wrapper  w230 imgset0">\
				<div class="inner_wrapper">\
				<a target="_blank" href="" class="detail_link imgobj"><img data-original="{{obj_url}}" class="lazy_{{batch_no}}" src="img/grey.gif" width="{{thumbnail_width}}" height="{{thumbnail_height}}" class="img_loaded" id="img_{{id}}"></a>\
				<div class="imgobj_info_container">\
				<div class="padding_wrapper">\
				<a target="_blank" class="abs" href="http://www.juemei.cc/html/list/heaefa_abeag-7.html?p=7">{{tags}}</a>\
				<a target="_blank" class="from_site" href="{{from_url}}">来自<span class="site_name"></span>&nbsp;<span class="site_url">{{site_url}}</span></a>\
				<span class="size_info">{{image_width}}x{{image_height}}</span>\
				</div>\
				</div>\
				<div class="imgset_num"><span class="num">{{album_obj_num}}</span>张</div>\
				</div>\
				<div class="left_bg"></div>\
				<div class="right_bg"></div>\
				<div class="personal_container">\
				<a class="btn download" title="下载原图到电脑" href="javascript:void(0);"><span>3</span></a>\
				<a class="btn addfav" title="收藏到我的相册" id="addfav_0" href="javascript:void(0);"></a>\
				</div>\
				</li>\
				{{/list}}'
		},
		getPics:function(){//初始化
			   $.ajax({
			   type: "GET",
			   url: "./js/app/index/json/data.js",
			   dataType:"json",
			   success: function(msg){
				  if(msg.errNo==0){
				    var group=[];
				    var cols=parseInt($("body").width()/238);
					for(var i=0;i<cols;i++){
					  if(i==0){var top="122px"}else{var top="40px"}
					  var tempobj={"col_num":i,"top":top,"list":msg.data.slice(i*3,(i+1)*3)};
					  group.push(tempobj);
					}
				    var template = Handlebars.compile(Gallery.template.group_pics_data);
                    var html=template({"group":group});
					$("#imgs_container").html(html);
					$("img.lazy").lazyload({ effect :"fadeIn",failurelimit : 100,threshold : 200 });
					$(document).trigger("scroll");
				  }
			    }
			   });
	     },
		 getPicsMore:function(){ //加载更多
			   $.ajax({
			   type: "GET",
			   url: "./js/app/index/json/data.js",
			   dataType:"json",
			   success: function(msg){
				  if(msg.errNo==0){
				    var group=[];
				    var cols=parseInt($("body").width()/238);
					var batch_no=parseInt(Math.random()*67);
					$.each(msg.data,function(){
					   this.batch_no=batch_no;
					})
					for(var i=0;i<cols;i++){
					  var template = Handlebars.compile(Gallery.template.item_pics_data);
                      var html=template({"list":msg.data.slice(i*2,(i+1)*2)});
					  $("#col_"+i).append(html);
					}
					$("img.lazy_"+batch_no).lazyload({ effect :"fadeIn",failurelimit : 100,threshold : 200 });
				  }
			    }
			   });
	     },
		 seachPics:function(){ //搜索
			   $.ajax({
			   type: "GET",
			   url: "./js/app/index/json/data_search.js",
			   dataType:"json",
			   success: function(msg){
				  if(msg.errNo==0){
				    $(document).off("scroll");
				    var group=[];
				    var cols=parseInt($("body").width()/238);
					for(var i=0;i<cols;i++){
					  if(i==0){var top="122px",list=[]}else{var top="40px",list=msg.data.slice(i*1,(i+1)*1)}
					  var tempobj={"col_num":i,"top":top,"list":list};
					  group.push(tempobj);
					}
				    var template = Handlebars.compile(Gallery.template.group_pics_data);
                    var html=template({"group":group});
					$("#imgs_container").html(html);
					$("img.lazy").lazyload({ effect :"fadeIn",failurelimit : 100,threshold : 200 });
					$(document).trigger("scroll");
				  }
			    }
			   });
	     }
 };

 
 exports.init=function(){
 
     Gallery.getPics();
	 //搜索
	 $("#search_input").on("keyup",function(){
	  if($("#search_input").val()==""){
	  }else{
		Gallery.seachPics();}
	 })
	 //滚动
	 $(document).scroll(function(){
          var nDivHight = $("body").height();
          var nScrollHight = document.documentElement.scrollHeight || document.body.scrollHeight;
          var nScrollTop = document.documentElement.scrollTop || document.body.scrollTop;
          if(nScrollTop + nDivHight >= nScrollHight){
		     //滚动条到底部了;
			 Gallery.getPicsMore();
		  }
      })
 };

})