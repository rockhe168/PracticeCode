using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqAddDeleteUpdate
{
    public partial class Default : System.Web.UI.Page
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

        //新增
        protected void btn_SendMessage_Click(object sender, EventArgs e)
        {
            tbGuestBook model = new tbGuestBook();
            model.Id = Guid.NewGuid();
            model.UserName = this.tb_UserName.Text;
            model.PostTime = DateTime.Now;
            model.Message = this.tb_Message.Text;
            model.IsReplied = false;

            ctx.tbGuestBook.InsertOnSubmit(model);

            ctx.SubmitChanges();

            BindGuestBook();

            this.tb_UserName.Text = string.Empty;
            this.tb_Message.Text = string.Empty;
        }
    }
}