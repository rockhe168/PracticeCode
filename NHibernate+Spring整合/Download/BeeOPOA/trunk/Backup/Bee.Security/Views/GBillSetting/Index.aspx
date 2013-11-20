<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="<%=HtmlHelper.ForActionLink() %>" method="post">
<%=HtmlHelper.ForHidden("setting") %>
<div class="formBar">
    <ul style="float: left; margin-right: 350px;">
        <li><span style="padding-top: 5px; float: left;">提单类型：</span></li>
        <li>
            <select class="combox" id="billid" name="billid" ref="settingName" refurl="/GBillSetting/SettingList.bee?billid={value}"
                svalue="">
                <option value="">请选择</option>
                <%=DataMapping.Instance.MappingAll("billmapping", "<option value=@id>@name</option>")%>
            </select>
        </li>
        <li style="margin-left: 20px;"><span style="padding-top: 5px; float: left;">选择方案：</span></li>
        <li>
            <select class="combox" id="settingName" name="settingName">
                <option>请选择</option>
            </select>
        </li>
    </ul>
    <ul style="float: left;">
        <li><a class="button" href="javascript:" onclick="javascript:Save<%=PageId %>();"><span>
            保存</span> </a></li>
        <li><a class="button" href="javascript:" onclick="javascript:Edit<%=PageId %>('0');">
            <span>新建</span> </a></li>
        <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
    </ul>
</div>
<div class="pageFormContent" layouth="56">
    <div id="billMapping" class="pageContent" layouth="42">
    </div>
</div>
</form>

<script type="text/javascript">

    $(document).ready(function() {
        var $form = $("#pageForm<%=PageId %>");
        $(":input[name=settingName]", $form).change(function() {
            var settingId = $(this).val();
            Edit<%=PageId %>(settingId);
        });
    });
    
    var Edit<%=PageId %> = function(settingId){
        var $form = $("#pageForm<%=PageId %>");

        var billId = $("#billid", $form).val();
        if(settingId=='')return;
        $("#billMapping", $form).loadUrl("/GBillSetting/detail.bee", { billId: billId, settingId:settingId }, null);
    }
    
    var Save<%=PageId %> = function(){
        var $form = $("#pageForm<%=PageId %>");
        var billSetting = [];
        $("#dest>div", $form).each(function(){
            billSetting.push($(this).attr("tvalue"));
        });
        var billId = $(":input[name=billid]", $form).val();
        if(billSetting.length && billId != '') {
            $("input[name=setting]", $form).val(billSetting.join(","));
        }
        else {
            alertMsg.warn("没有需要保存的内容");
        }
        
        bee.PostData("/GBillSetting/Save.bee", $form.serializeArray(), function(msg){
                alertMsg.correct("操作成功");
            });
        navTab.reloadCurrent();
        
    }
   
</script>

