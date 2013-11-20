//放大镜的参数修改
$(function(){			
	                      $(".jqzoom").jqueryzoom({
			                  xzoom:330,
			                  yzoom:330,
			                  offset:10,
			                  position:"right",
			                  preload:1,
			                  lens:1
		                  });
		                  $("#spec-list").jdMarquee({
		                  	deriction:"right",
			                  width:730,
			                  height:100,
			                  step:2,
			                  speed:4,
			                  delay:10,
			                  control:true,
			                  _front:"#spec-right",
			                  _back:"#spec-left"
		                  });
		                  $("#spec-list img").bind("mouseover",function(){
			                  var src=$(this).attr("src");
			                  $("#spec-n1 img").eq(0).attr({
			                  	src:src.replace("\/n5\/","\/n1\/"),
			                  	jqimg:src.replace("\/n5\/","\/n0\/")
			                  });
			                  $(this).css({
			                  	"border":"1px solid #ff6600",
			                  	"padding":"1px"
			                  });
		                  }).bind("mouseout",function(){
			                  $(this).css({
				                  "border":"1px solid #ccc",
				                  "padding":"2px"
			                  });
		                  });				
	                  })