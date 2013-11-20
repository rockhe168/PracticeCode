using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqAddDeleteUpdate
{
    public partial class Admin : System.Web.UI.Page
    {
        GuestBookDataContext ctx = DataContextFactory.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGuestBook();
            }
        }


        //绑定数据
        private void BindGuestBook()
        {
            this.rpt_Message.DataSource = from gb in ctx.tbGuestBook
                                          orderby gb.PostTime
                                          select gb;
            this.rpt_Message.DataBind();
        }

        //Repeat事件
        protected void rpt_Message_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string actionName = e.CommandName;
            tbGuestBook model = ctx.tbGuestBook.Single(p => p.Id == new Guid(e.CommandArgument.ToString()));
            //回复留言，修改
            if (actionName.Equals("SendReply"))
            {

                model.IsReplied = true;
                model.Reply = (e.Item.FindControl("tb_Reply") as TextBox).Text;

            }
            else if (actionName.Equals("DeleteMessage"))//删除
            {
                ctx.tbGuestBook.DeleteOnSubmit(model);
            }
            ctx.SubmitChanges();
            BindGuestBook();
        }
    }
}