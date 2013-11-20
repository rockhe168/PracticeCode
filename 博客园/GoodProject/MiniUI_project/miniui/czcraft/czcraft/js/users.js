// JavaScript Document
function ShowNo(){
  document.getElementById("divLogin").style.display="none";
}   

function showFloat(){
var range = getRange();
  document.getElementById("divLogin").style.display="";
}
function getRange(){
  var top = document.body.scrollTop;
  var left = document.body.scrollLeft;
  var height = document.body.clientHeight;
  var width = document.body.clientWidth;

  if (top==0 && left==0 && height==0 && width==0)  
  {
  top = document.documentElement.scrollTop;
  left = document.documentElement.scrollLeft;
  height = document.documentElement.clientHeight;
  width = document.documentElement.clientWidth;
  }
  return {top:top ,left:left ,height:height ,width:width } ;
  }  