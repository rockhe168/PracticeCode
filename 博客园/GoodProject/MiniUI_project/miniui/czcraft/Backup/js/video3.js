var xmlDoc;
function show3(tag, furl) {
    $("#flashPlayerCon3").html("");
    var light = document.getElementById(tag);
    var fade = document.getElementById('fade3');
    var h = document.documentElement.scrollHeight;
    var mt = document.documentElement.scrollTop;
    
    
    //var index = furl.toString().lastIndexOf("/", furl.toString().length);
    //var fxmlUrl = furl.toString().substr(0, index).concat("/Config.xml");

    //var sss = $.ajax({ url: fxmlUrl, type: "GET", dataType: "xml", error: function(er) { alert(er+"23"); }, success: function(data) {
       // alert(data);
    //}
    //});
    fade.style.height = h + "px";
    //light.style.width = "100%";
    //light.style.height = "100%";
    fade.style.width = document.documentElement.clientWidth + "px";
    setTimeout(function() { light.style.left =(((document.body.offsetWidth/2.5)/1.9))+"px"; light.style.top = (document.documentElement.clientHeight - light.clientHeight) / 2 + document.documentElement.scrollTop + "px"; }, 200);
    light.style.display = 'block';
    fade.style.display = 'block';
    var swf = '<embed src="' + furl + '" align="middle" style="width:800px; height:600px;" allowFullScreen="true"  quality="high" allowscriptaccess="always" type="application/x-shockwave-flash" ></embed>';
    $("#flashPlayerCon3").html($("#flashPlayerCon3").html() + swf);
}


function handler() {
    var sssssss = xmlDoc.responseXML;
}

function hide3(tag) {
    var light = document.getElementById(tag);
    var fade = document.getElementById('fade3');
    light.style.display = 'none';
    fade.style.display = 'none';
    //$("#light3").html() = '<a class="close link1" href="javascript:void(0)" onclick=' + "hide3('light3')" + '>¹Ø±Õ</a><div class="con" id="flashPlayerCon3"></div>';
    //light.innerHTML = '<a class="close link1" href="javascript:void(0)" onclick=' + "hide('light')" + '>¹Ø±Õ</a><div class="con" id="flashPlayerCon"></div>';
}
