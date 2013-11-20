<%@ Page Language="C#" AutoEventWireup="false" Inherits="Bee.Web.BeePageView" %>

<%@ Import Namespace="Bee.Web" %>
<%@ Import Namespace="Bee" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%=HtmlHelper.ForHidden("id") %>
<div class="pageContent">
    <div class="pageFormContent">
        <ul>
            <li>
                <label style="text-align: right">
                    模板标题：</label>
                <%=HtmlHelper.ForTextBox("title", "style=width:400px;") %>
            </li>
            <li>
                <label style="text-align: right">
                    是否默认：</label>
                <%=HtmlHelper.ForSelect("type", "是否10") %>
            </li>
        </ul>
    </div>
    <p style="text-align: left; font-weight: bold;">
        模板内容：
    </p>
    <p>
        <textarea name="content" style="width: 98%" rows="25" class="editor" upimgurl="/xheditor/server/upload.aspx?immediate=1"
            upimgext="jpg,jpeg,gif,png"><%=ViewData["content"] %></textarea>
    </p>
    <div class="panel collapse close" style="width: 98%; margin: 10px;">
        <h1>
            报表字段说明</h1>
        <div>
            <div style="width: 98%">
                <p align="center">
                    公司基本信息</p>
                <div align="center">
                    <table border="1" cellspacing="0" cellpadding="0" width="760px">
                        <tbody>
                            <tr>
                                <td>
                                    <p align="right">
                                        <strong><span style="color: #454545;">说明</span></strong></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <strong><span style="color: #454545;">使用字段</span></strong></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <strong><span style="color: #454545;">说明</span></strong></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <strong><span style="color: #454545;">使用字段</span></strong></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【公司名称】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@sys.company.name</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【公司地址】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@sys.company.address</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【电话】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@sys.company.tel</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【传真】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@sys.company.fax</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【电子邮箱】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@sys.company.email</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【网址】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@sys.company.website</span></p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <p>
                </p>
                <p>
                </p>
                <p align="center">
                    提单信息</p>
                <div align="center">
                    <table border="1" cellspacing="0" cellpadding="0" width="760px">
                        <tbody>
                            <tr>
                                <td>
                                    <p align="right">
                                        <strong><span style="color: #454545;">说明</span></strong></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <strong><span style="color: #454545;">使用字段</span></strong></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <strong><span style="color: #454545;">说明</span></strong></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <strong><span style="color: #454545;">使用字段</span></strong></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出入库主题】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@title</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出入库单号】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@billid</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【仓库】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@warehouse</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出入库日期】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@audittime</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出入库单类型】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@billtype</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出</span><span style="color: #454545;">\</span><span
                                            style="color: #454545;">入库状态】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@status</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【申请时间】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@createtime</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【申请人】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@createuser</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【审核时间】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@audittime</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【审核人】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@audituser</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【公司】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@company</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【相关单据号】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@ddid</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【备注】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@remark</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【金额】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@amount</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出入库明细】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@billdetail</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【出入库商品总数量】</span>
                                    </p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@SumNum</span>
                                    </p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <p align="center">
                    提单关联公司信息</p>
                <div align="center">
                    <table border="1" cellspacing="0" cellpadding="0" width="760px">
                        <tbody>
                            <tr>
                                <td>
                                    <p align="right">
                                        <strong><span style="color: #454545;">说明</span></strong></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <strong><span style="color: #454545;">使用字段</span></strong></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <strong><span style="color: #454545;">说明</span></strong></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <strong><span style="color: #454545;">使用字段</span></strong></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【联系人】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@contact</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【办公电话】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@tel</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【手机】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@phone</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【传真】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@fax</span></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【QQ】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@qq</span></p>
                                </td>
                                <td>
                                    <p align="right">
                                        <span style="color: #454545;">【地址】</span></p>
                                </td>
                                <td>
                                    <p align="left">
                                        <span style="color: #454545;">@address</span></p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
