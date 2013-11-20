using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.OPOADemo.Models;
using Bee.Web;
using Bee.Data;

namespace Bee.OPOADemo.Controllers
{
    public class EmployeeController : ControllerBase<User>
    {
        protected override Bee.Data.DbSession GetDbSession(bool useTransaction)
        {
            return new DbSession("Data", useTransaction);
        }
    }
}
