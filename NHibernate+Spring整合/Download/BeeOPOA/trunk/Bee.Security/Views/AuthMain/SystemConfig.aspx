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
                    <li><a href="javascript:;"><span>ϵͳ����</span></a></li>
                    <li><a href="javascript:;"><span>��Ʒ��������</span></a></li>
                    <li><a href="javascript:;"><span>��˾����</span></a></li>
                </ul>
            </div>
        </div>
        <div class="tabsContent" >
            <div>
                <p>
                    <label>
                        ϵͳ����</label><input type="text" name="SiteName" value="<%=SystemConfigManager.Instance.GetConfigValue("SiteName") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('SiteName');">����</a>
                </p>
                <p>
                    <label>
                        �汾��</label><input type="text" name="Version" value="<%=SystemConfigManager.Instance.GetConfigValue("Version") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Version');">����</a>
                    <a href="/uplog.html" target=_blank>���¼�¼</a>
                </p>
                <p>
                    <label>
                        �Ƿ��������</label><select class='combox' name="md5encryp" svalue="<%=SystemConfigManager.Instance.GetConfigValue("md5encryp") %>"><option
                            value="true">��</option>
                            <option value="false">��</option>
                        </select>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('md5encryp');">����</a>
                </p>
            </div>
            <div>
                <p style="width: 800px; text-align: center; color: Blue">
                    �������� </p>
                <p>
                    <label>
                        ����1</label><input type="text" name="HSLPrice1" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice1") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice1');">����</a>
                </p>
                <p>
                    <label>
                        ����2</label><input type="text" name="HSLPrice2" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice2") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice2');">����</a>
                </p>
                <p>
                    <label>
                        ����3</label><input type="text" name="HSLPrice3" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice3") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice3');">����</a>
                </p>
                <p>
                    <label>
                        ����4</label><input type="text" name="HSLPrice4" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice4") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice4');">����</a>
                </p>
                <p>
                    <label>
                        ����5</label><input type="text" name="HSLPrice5" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice5") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice5');">����</a>
                </p>
                 <p>
                    <label>
                        ����6</label><input type="text" name="HSLPrice6" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice6") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice6');">����</a>
                </p>
                <p>
                    <label>
                        ����7</label><input type="text" name="HSLPrice7" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice7") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice7');">����</a>
                </p>
                <p>
                    <label>
                        ����8</label><input type="text" name="HSLPrice8" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice8") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice8');">����</a>
                </p>
                <p>
                    <label>
                        ����9</label><input type="text" name="HSLPrice9" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice9") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice9');">����</a>
                </p>
                <p>
                    <label>
                        ����10</label><input type="text" name="HSLPrice10" value="<%=SystemConfigManager.Instance.GetConfigValue("HSLPrice10") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('HSLPrice10');">����</a>
                </p>
                <p style="width: 800px; text-align: center; color: Blue">
                    �Զ����ֶ�����</p>
                <p>
                    <label>
                        �Զ����ֶ�1</label><input type="text" name="Product.Field1" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field1") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field1');">����</a>
                </p>
                <p>
                    <label>
                        �Զ����ֶ�2</label><input type="text" name="Product.Field2" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field2") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field2');">����</a>
                </p>
                <p>
                    <label>
                        �Զ����ֶ�3</label><input type="text" name="Product.Field3" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field3") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field3');">����</a>
                </p>
                <p>
                    <label>
                        �Զ����ֶ�4</label><input type="text" name="Product.Field4" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field4") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field4');">����</a>
                </p>
                <p>
                    <label>
                        �Զ����ֶ�5</label><input type="text" name="Product.Field5" value="<%=SystemConfigManager.Instance.GetConfigValue("Product.Field5") %>" />
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('Product.Field5');">����</a>
                </p>
            </div>
            <div>
                <p>
                    <label>
                        ��˾����</label><%=HtmlHelper.ForTextBox("sys.company.name")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.name');">����</a>
                </p>
                <p>
                    <label>
                        ��˾��ַ</label><%=HtmlHelper.ForTextBox("sys.company.address")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.address');">
                        ����</a>
                </p>
                <p>
                    <label>
                        ��˾�绰</label><%=HtmlHelper.ForTextBox("sys.company.tel")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.tel');">����</a>
                </p>
                <p>
                    <label>
                        ��˾����</label><%=HtmlHelper.ForTextBox("sys.company.fax")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.fax');">����</a>
                </p>
                <p>
                    <label>
                        ��˾Email</label><%=HtmlHelper.ForTextBox("sys.company.email")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.email');">
                        ����</a>
                </p>
                <p>
                    <label>
                        ��˾��ַ</label><%=HtmlHelper.ForTextBox("sys.company.website")%>
                    <a class="btnSelect" href="javascript:;" onclick="SaveConfig('sys.company.website');">
                        ����</a>
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
        function(msg) { alertMsg.correct("�����ɹ���"); });
    }
    
</script>

