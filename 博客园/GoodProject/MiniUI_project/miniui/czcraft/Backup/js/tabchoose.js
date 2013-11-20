// JavaScript Document
function switchTab1(tabpage,tabid){ 
         var oItem = document.getElementById(tabpage);    
 	for(var i=0;i <oItem.childNodes.length;i++){ 
 		var x = oItem.childNodes[i]; 
 		if(x.tagName == "LI"){ 
 			x.className = " "; 
 			var y = x.getElementsByTagName("A");  
 		} 
 	} 
 		document.getElementById(tabid).className = "Selected"; 
 	var dvs=document.getElementById("cnt1").childNodes; 
 	for (var i=0;i <dvs.length;i++){
		if(dvs[i].nodeType==1){
 	        if (dvs[i].id==('d'+tabid)) 
 	            dvs[i].style.display='block'; 
 	        else 
   	            dvs[i].style.display='none'; 
		}
	}
 } 