//验证是否都是汉字
function IsChinese(str){
 var patrn = /^[\u4E00-\u9FA5]+$/;
 var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
function IsChineseValidation(e){
 // var reg = /^[\u4E00-\u9FA5]+$/;
 // var ss=new RegExp(reg);
         if (e.isValid){
          if(e.value==""){ //空值判断
          return;
          }
          if(IsChinese(e.value)==false){ 
           e.errorText = "请输入汉字";
           e.isValid = false;
           } 
          }
          
 

}
//检验国内的邮政编码
function isPostalCode(str){
var patrn =/^[0-9]{6}$/;
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
function isPostalCodeValidation(e){
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          
          if(isPostalCode(e.value)==false){ 
           e.errorText = "请输入正确邮政编码";
           e.isValid = false;
          } 
     }
}

//校验登录名：只能输入5-20个以字母开头、可带数字、“_”、“.”的字串
function isRegisterUserName(str){
var patrn=/^[a-zA-Z]{1}([a-zA-Z0-9._]){4,19}$/;
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
function isRegisterUserNameValidation(e)
{
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          if(isRegisterUserName(e.value)==false){ 
           e.errorText = "请输入正确的格式,只能输入5-20个以字母开头、可带数字、“_”、“.”的字串";
           e.isValid = false;
          } 
     }
}
function isPasswd(str){
var patrn=/^[a-zA-Z0-9]{6,15}$/;
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
//校验密码：只能输入6-15个字母、数字
function isPasswdValidation(e){
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          if(isPasswd(e.value)==false){ 
           e.errorText = "请输入正确的密码,只能输入6-15个字母、数字";
           e.isValid = false;
          } 
     }
}
function isTel(str){
var patrn=/^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
//校验普通电话、传真号码：可以“+”开头，除数字外，可含有“-”
function isTelValidation(e){
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          if(isTel(e.value)==false){ 
           e.errorText = "请输入正确的电话号,例如:0475-8226891";
           e.isValid = false;
          } 
     }
}
function isMobile(str){
var patrn=/^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
//校验手机号码：必须以数字开头，除数字外，可含有“-”
function isMobileValidation(e){
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          if(isMobile(e.value)==false){ 
           e.errorText = "请输入正确的手机号,例如:15919592516";
           e.isValid = false;
          } 
     }
}
function IsQQ(str){
var patrn="^[1-9]+[0-9]*$";
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
//检验qq
function IsQQValidation(e){
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          if(IsQQ(e.value)==false){ 
           e.errorText = "请输入正确的qq号,例如:409180953";
           e.isValid = false;
          } 
        }
}
//验证长度
function onLengthValidation(e) {
            if (e.isValid) {
                if (e.value.length >30) {
                    e.errorText = "请输入少于30个字";
                    e.isValid = false;
                }
            }            
        }
function IsURL(str){
  var patrn = "^((https|http|ftp|rtsp|mms)?://)"  
         + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@  
         + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184  
         + "|" // 允许IP和DOMAIN（域名） 
         + "([0-9a-z_!~*'()-]+\.)*" // 域名- www.  
         + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名  
        + "[a-z]{2,6})" // first level domain- .com or .museum  
        + "(:[0-9]{1,4})?" // 端口- :80  
        + "((/?)|" // a slash isn't required if there is no file name  
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";  
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}       
//验证URL网址
  function IsURLValidation(e){ 
      
       if (e.isValid) {
        if(e.value=="") //空值判断
          return;
          if(IsURL(e.value)==false){ 
           e.errorText = "请输入正确的网址";
           e.isValid = false;
          } 
        }
        
    } 
function isEmail(str){  
var patrn=/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/; 
var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}    
//验证Email
function isEmailValidation(e) {

 if (e.isValid) {
  if(e.value=="") //空值判断
          return;
          if(isEmail(e.value)==false){ 
           e.errorText = "请输入正确的Email";
           e.isValid = false;
          } 
        }
}
//验证传真
function IsFac(str){
var patrn=/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;

var ss =new RegExp(patrn); 
if(ss.test(str))
return true;
else return false;
}
function isFacValidation(e){
if (e.isValid) {
 if(e.value=="") //空值判断
          return;
          if(IsFac(e.value)==false){ 
           e.errorText = "请输入正确的传真";
           e.isValid = false;
          } 
        }
}
