<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<form id='content<%=PageId %>' action="<%=HtmlHelper.ForActionLink("save") %>" method="post"
class="required-validate alertMsg">
<div class="pageFormContent" layouth="56">
    <div class="tabs" currentindex="0" eventtype="hover">
        <div class="tabsHeader">
            <div class="tabsHeaderContent">
                <ul>
                    <li><a href="javascript:;"><span>系统配置</span></a></li>
                    <li><a href="javascript:;"><span>产品属性配置</span></a></li>
                    <li><a href="javascript:;"><span>公司配置</span></a></li>
                </ul>
            </div>
        </div>
        <div class="tabsContent" >
            <div>
                <p>
                    <label>
                        系统名称</label><input type="text" name="SiteName" value="<%=SystemConfigManager.Instance.GetConfigValue("SiteName") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('SiteName');">保存</a>
                </p>
                <p>
                    <label>
                        版本号</label><input type="text" name="Version" value="<%=SystemConfigManager.Instance.GetConfigValue("Version") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Version');">保存</a>
                    <a href="/uplog.html" target=_blank>更新记录</a>
                </p>
                <p>
                    <label>
                        是否加密密码</label><select class='combox' name="md5encryp" svalue="<%=SystemConfigManager.Instance.GetConfigValue("md5encryp") %>"><option
                            value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('md5encryp');">保存</a>
                </p>
            </div>
            <div>
                <p style="width: 800px; text-align: center; color: Blue">
                    单价设置 </p>
                <p>
                    <label>
                        单价1</label><input type="text" name="HSLPrice1" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice1") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice1');">保存</a>
                </p>
                <p>
                    <label>
                        单价2</label><input type="text" name="HSLPrice2" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice2") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice2');">保存</a>
                </p>
                <p>
                    <label>
                        单价3</label><input type="text" name="HSLPrice3" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice3") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice3');">保存</a>
                </p>
                <p>
                    <label>
                        单价4</label><input type="text" name="HSLPrice4" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice4") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice4');">保存</a>
                </p>
                <p>
                    <label>
                        单价5</label><input type="text" name="HSLPrice5" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice5") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice5');">保存</a>
                </p>
                 <p>
                    <label>
                        单价6</label><input type="text" name="HSLPrice6" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice6") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice6');">保存</a>
                </p>
                <p>
                    <label>
                        单价7</label><input type="text" name="HSLPrice7" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice7") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice7');">保存</a>
                </p>
                <p>
                    <label>
                        单价8</label><input type="text" name="HSLPrice8" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice8") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice8');">保存</a>
                </p>
                <p>
                    <label>
                        单价9</label><input type="text" name="HSLPrice9" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice9") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice9');">保存</a>
                </p>
                <p>
                    <label>
                        单价10</label><input type="text" name="HSLPrice10" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice10") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice10');">保存</a>
                </p>
                <p style="width: 800px; text-align: center; color: Blue">
                    自定义字段名称</p>
                <p>
                    <label>
                        自定义字段1</label><input type="text" name="Product.Field1" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field1") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field1');">保存</a>
                </p>
                <p>
                    <label>
                        自定义字段2</label><input type="text" name="Product.Field2" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field2") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field2');">保存</a>
                </p>
                <p>
                    <label>
                        自定义字段3</label><input type="text" name="Product.Field3" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field3") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field3');">保存</a>
                </p>
                <p>
                    <label>
                        自定义字段4</label><input type="text" name="Product.Field4" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field4") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field4');">保存</a>
                </p>
                <p>
                    <label>
                        自定义字段5</label><input type="text" name="Product.Field5" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field5") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field5');">保存</a>
                </p>
            </div>
            <div>
                <p>
                    <label>
                        公司名称</label><%=HtmlHelper.ForTextBox("sys.company.name")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.name');">保存</a>
                </p>
                <p>
                    <label>
                        公司地址</label><%=HtmlHelper.ForTextBox("sys.company.address")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.address');">
                        保存</a>
                </p>
                <p>
                    <label>
                        公司电话</label><%=HtmlHelper.ForTextBox("sys.company.tel")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.tel');">保存</a>
                </p>
                <p>
                    <label>
                        公司传真</label><%=HtmlHelper.ForTextBox("sys.company.fax")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.fax');">保存</a>
                </p>
                <p>
                    <label>
                        公司Email</label><%=HtmlHelper.ForTextBox("sys.company.email")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.email');">
                        保存</a>
                </p>
                <p>
                    <label>
                        公司网址</label><%=HtmlHelper.ForTextBox("sys.company.website")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.website');">
                        保存</a>
                </p>
            </div>
        </div>
    </div>
</div>
</form>

<script type="text/javascript">
    var SaveConfig = function(name) {
        var $form = $("#content<%=PageId %>");
        var value = $("[name=" + name.replaceForId() + "]", $form).val();
        bee.PostData("/AuthMain/SaveConfig.bee", { name: name, value: value },
        function(msg) { alertMsg.correct("操作成功！"); });
    }
    
</script>

