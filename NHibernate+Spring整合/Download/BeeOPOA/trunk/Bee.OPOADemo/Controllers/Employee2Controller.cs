using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bee.OPOADemo.Models;
using Bee.Web;
using Bee.Data;
using System.Data;

namespace Bee.OPOADemo.Controllers
{
    public class Employee2Controller : ControllerBase<User>
    {
        public override PageResult List(BeeDataAdapter dataAdapter)
        {
            return base.List(dataAdapter);
        }

        public PageResult List2(BeeDataAdapter dataAdapter)
        {
            PageResult result =  base.List(dataAdapter);

            return View("TestViewList", result.Model);
        }

        public PageResult List3(BeeDataAdapter dataAdapter)
        {
            InitPagePara(dataAdapter);
            SqlCriteria sqlCriteria = GetQueryCondition(typeof(User), dataAdapter);
            

            DataTable dataTable = null;
            int recordCount = 0;
            using (DbSession dbSession = GetDbSession())
            {
                string selectClause = GetQuerySelectClause(typeof(User));

                dataTable = base.InnerQuery("Employee", selectClause, dataAdapter, sqlCriteria, ref recordCount);

                ViewData["recordcount"] = recordCount;
            }

            return View("TestViewList", dataTable);
        }

        public PageResult List4(BeeDataAdapter dataAdapter)
        {
            InitPagePara(dataAdapter);
            SqlCriteria sqlCriteria = GetQueryCondition(typeof(User), dataAdapter);

            DataTable dataTable = null;
            int recordCount = 0;
            using (DbSession dbSession = GetDbSession())
            {
                string selectClause = GetQuerySelectClause(typeof(User));

                dataTable = base.InnerQuery("Employee", selectClause, dataAdapter, sqlCriteria, ref recordCount);

                ViewData["recordcount"] = recordCount;
            }

            
            return View(dataTable);
        }

        public override PageResult Show(int id)
        {
            PageResult result = base.Show(id);

            return View(result.Model);
        }


        public override void Delete(int id)
        {
            base.Delete(id);
        }


        protected override Bee.Data.DbSession GetDbSession(bool useTransaction)
        {
            return new DbSession("Data", useTransaction);
        }
    }
}
