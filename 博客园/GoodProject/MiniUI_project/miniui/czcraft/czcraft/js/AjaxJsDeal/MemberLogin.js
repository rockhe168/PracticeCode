﻿  //检测登录状态
         function CheckLogin()
         {
            $.ajax({
            url:'<%=ResolveUrl("Data/GetMemberInfo.ashx?method=CheckLoginStatus")%>',
            type:"post",
            success:function(data){
              var jsonInfo= $.parseJSON(data);
              if(jsonInfo.Status&&jsonInfo.UserName!="")
              window.location.href="MemberInfo.aspx";
            }
         });
         }  
     //登录 
        function Login(){ 
         
         $("#aLogin").click(function(){ 
         var Name=$("#txtUserName").val(); 
         var pwd=$("#txtPwd").val(); 
         var cbName=$("#cbUserName").attr("checked"); 
         var cbPwd=$("#cbPwd").attr("checked"); 
         if(Name==""||pwd=="") 
         { 
         alert("用户名或密码不能为空!"); 
         return; 
         } 
         if(cbName=="checked") 
         cbName="1"; 
         else 
         cbName="0"; 
         if(cbPwd=="checked") 
         cbPwd="1"; 
         else  
         cbPwd="0"; 
        var Data={"Name":Name,"Pwd":pwd,"cbName":cbName,"cbPwd":cbPwd } 
         $.ajax({ 
            url:"Data/GetMemberInfo.ashx?method=MemberLogin", 
            type:"post", 
            data:Data, 
            success:function(ReturnData,status){ 
           var jsonInfo= $.parseJSON(ReturnData); 
              if(jsonInfo.Status) 
              { 
                $("#liLogin").hide(); 
                $("#liLogout").show(); 
                $("#lbUserNameInfo").text(jsonInfo.UserName+"的");
                window.location.href='MemberInfo.aspx';
              } 
              else{ 
              alert("您输入的帐号或密码错误!也有可能您的帐号未邮箱激活!"); 
              } 
             
            } 
             
         }); 
          
         }); 
        
        }