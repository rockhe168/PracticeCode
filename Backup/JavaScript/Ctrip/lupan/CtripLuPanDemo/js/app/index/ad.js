define(function(require,exports){
 exports.init=function(){jQuery("#load_ad a").html("加载广告成功!")};
 exports.init_calendar=function(){
     $("#starttime").regMod("calendar", "3.0", {
			options: {
				showWeek: true,
				container: cQuery.container
				// todayClass: "c_jintian",
				//  today: MF.other.addZeroDate(MF.other.today)
			},
			listeners: {
				onChange: function (input, value) {
					//can not change when user type the date
					//$("#deptime")[0].focus();
				}
			}
		}, true);
 }
})