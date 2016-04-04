using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using videoContext;

namespace Web.Admin.Ajax
{
    /// <summary>
    /// ChannelInstallHandler 的摘要说明
    /// </summary>
    public class ChannelInstallHandler :  BaseHandler
    {

        public void SaveInputMoney()
        {
            try
            {
                int id = Convert.ToInt32(Context.Request["id"]);

                decimal unitprice = Convert.ToDecimal(Context.Request["unitprice"]);
                long inputcount = Convert.ToInt32(Context.Request["inputinstallcount"]);
                decimal inputmoney = Convert.ToDecimal(Context.Request["inputmoney"]);
                bool paymentstate = Convert.ToBoolean(Context.Request["paymentstate"]);

                channelinstallinfo currentModel = channelinstallinfo.SingleOrDefault("where id=@0", id);

                if (currentModel != null)
                {
                    currentModel.unitprice = unitprice;
                    currentModel.inputinstallcount = inputcount;
                    currentModel.inputmoney = inputmoney;
                    currentModel.paymentstate = paymentstate;
                    currentModel.Update();
                }
                else
                {
                    this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInstallList", string.Empty, CallbackType.closeCurrent, string.Empty);
                }


                this.OutPutDialogString(ResponseStatus.Success, "保存成功", "ChannelInstallList", string.Empty, CallbackType.closeCurrent, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInstallList", string.Empty, CallbackType.closeCurrent, string.Empty);
            }
        }

        public void UpdateBalance()
        {
            try
            {
                string ids = Context.Request["id"];


                string[] idStringList = ids.Split(',');

                List<int> idList = new List<int>();

                foreach (var s in idStringList)
                {
                    idList.Add(Convert.ToInt32(s));
                }


                var currentList = channelinstallinfo.Fetch("where id in (@0)", idList);

                foreach (var currentModel in currentList)
                {
                    currentModel.paymentstate = true;
                    currentModel.Update();
                }

                this.OutPutDialogString(ResponseStatus.Success, "保存成功", "ChannelInstallList", string.Empty, CallbackType.forward, string.Empty);
            }
            catch (Exception ex)
            {
                this.OutPutDialogString(ResponseStatus.Fail, "保存失败", "ChannelInstallList", string.Empty, CallbackType.forward, string.Empty);
            }
        }
    }
}