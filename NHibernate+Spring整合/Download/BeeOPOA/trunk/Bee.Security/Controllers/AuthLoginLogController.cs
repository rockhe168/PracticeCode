using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bee.Models;
using Bee.Web;

namespace Bee.Controllers
{
    public class AuthLoginLogController : ControllerBase<LoginLog>
    {
        public override PageResult List(BeeDataAdapter dataAdapter)
        {
            return View("List", base.List(dataAdapter).Model);
        }
    }
}
