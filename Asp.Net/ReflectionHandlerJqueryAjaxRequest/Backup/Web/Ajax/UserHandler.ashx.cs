using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Ajax
{
    /// <summary>
    /// Summary description for UserHandler
    /// </summary>
    public class UserHandler : BaseHandler
    {
        public void AddUser()
        {
            this.Context.Response.Write("add User");
        }
    }
}