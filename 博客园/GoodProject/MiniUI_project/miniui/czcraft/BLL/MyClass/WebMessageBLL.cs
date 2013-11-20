using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using Common;
namespace czcraft.BLL
{
    public partial  class WebMessageBLL
    {
          /// <summary>
       /// 总站回复内容
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        public bool UpdateComment(WebMessage model)
        {
            bool Status = new WebMessageDAL().UpdateComment(model);
            if (Status)
            {
                SMTP smtp = new SMTP(model.Email);
                smtp.sendemail("潮州工艺品平台","尊敬的"+model.liuyanName+"用户:您好!您给我们网站提的建议我们给您如下回复:<br/>"+model.huifuContent);//发送激活邮件
            }
            return Status;
        }
    }
}
