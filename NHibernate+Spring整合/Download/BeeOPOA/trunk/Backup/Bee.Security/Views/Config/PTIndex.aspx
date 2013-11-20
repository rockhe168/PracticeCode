<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='pageForm<%=PageId %>' action="<%=HtmlHelper.ForActionLink("PTSave") %>"
method="post" class="required-validate alertMsg noRefresh ">
<div class="formBar">
    <ul style="float: left; margin-right: 250px;">
        <li><span style="padding-top: 5px; float: left;">选择模板类型：</span></li>
        <li>
            <select class="combox" id="PTType" name="PTType" ref="PTName" refurl="/Config/PTList.bee?pttype={value}"
                svalue="">
                <option value="">请选择</option>
                <%=DataMapping.Instance.MappingAll("模板类型", "<option value=@id>@name</option>") %>
            </select>
        </li>
        <li style="margin-left: 20px;"><span style="padding-top: 5px; float: left;">选择模板：</span></li>
        <li>
            <select class="combox" id="PTName" name="PTName">
                <option>请选择</option>
            </select>
        </li>
    </ul>
    <ul style="float: right; margin-right: 250px;">
        <li><a class="button" href="javascript:" onclick="javascript:refreshPT(1);"><span>新建</span>
        </a></li>
        <li><a class="button" href="javascript:" onclick="javascript:autoSave('pageForm<%=PageId %>');">
            <span>保存</span> </a></li>
        <li><a class="button close" href="javascript:"><span>取消</span> </a></li>
    </ul>
</div>
<div region="center" id="divFileBody" layouth="56">
</div>
</form>

<script type="text/javascript">

    $(document).ready(function() {
        var $form = $("#pageForm<%=PageId %>");
        $("[name=PTName]", $form).change(function() {
            refreshPT(0);
        });
    });

    var refreshPT = function(value) {
        var $form = $("#pageForm<%=PageId %>");
        var pttype = $("select[name=PTType]", $form).val();
        if (pttype == "") { alertMsg.warn("请先选择模板类型"); return; }
        var ptid = 0;
        if (value == 0) {
            ptid = $("select[name=PTName]", $form).val();
            if (ptid == null) {
                return;
            }
        }
        $("#divFileBody").loadUrl("/Config/PTEdit.bee", { id: ptid, pttype: pttype });
    }

</script>

