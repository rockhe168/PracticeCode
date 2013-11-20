using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.Web;
using Bee.Data;
using System.Data;

namespace Bee.OPOADemo.Controllers
{
    public class MVCTestController : ControllerBase
    {
        public int Add(int i, int j)
        {
            return i + j;
        }

        public int Add(int i)
        {
            return i;
        }

        public ActionResult Add(int i, BeeDataAdapter dataAdapter)
        {
            return new ContentResult(100);
        }

    }

    
}
