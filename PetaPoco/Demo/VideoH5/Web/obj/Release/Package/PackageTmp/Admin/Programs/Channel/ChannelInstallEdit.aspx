<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelInstallEdit.aspx.cs" Inherits="Web.Admin.Programs.Channel.ChannelInstallEdit" %>

<div class="pageContent">
    <form method="post" action="Ajax/ChannelInstallHandler.ashx?action=SaveInputMoney" class="pageForm"
    onsubmit="return validateCallback(this, dialogAjaxDone)">
    <input type="hidden" name="id" value="<%=this.DefaultObject.id %>" />
    <div class="pageFormContent" layouth="58">
        
         <div class="unit">
            <label>
                录入单价：</label>
            <input type="text" name="unitprice" size="30" value='<%=this.DefaultObject.unitprice %>' class="required number" />(元)
        </div>

        <div class="unit">
            <label>
                录入安装量：</label>
            <input type="text" name="inputinstallcount" size="30" value='<%=this.DefaultObject.inputinstallcount %>'class="required digits" />
        </div>
        <div class="unit">
            <label>
                录入佣金：</label>
            <input type="text" name="inputmoney" size="30" value='<%=this.DefaultObject.inputmoney %>' class="required number" />(元)
        </div>
        <div class="unit">
            <label>结算状态：</label>
            <input type="radio" name="paymentstate" value='true' <%=OutPutCheckBoxChecked(this.DefaultObject.paymentstate)%>>已结算 <input type="radio" name="paymentstate" value='false' <%=OutPutCheckBoxChecked(this.DefaultObject.paymentstate==false)%>>未结算
        </div>
    </div>
    <div class="formBar">
        <ul>
            <li>
                <div class="buttonActive">
                    <div class="buttonContent">
                        <button type="submit">
                            提交</button></div>
                </div>
            </li>
            <li>
                <div class="button">
                    <div class="buttonContent">
                        <button type="button" class="close">
                            取消</button></div>
                </div>
            </li>
        </ul>
    </div>
    </form>
</div>
