using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;
namespace czcraft.DAL
{
   public partial class VCartProductInfoDAL
    {
        #region 列出tableName所有的实体信息
        /// <summary>
        /// 列出tableName所有的实体信息
        /// </summary>
        /// <param name="strWhere">查询条件,不用加where</param>
        /// <returns></returns>
        public IEnumerable<VCartProductInfo> ListAll(string strWhere)
        {
            if (strWhere != "")
                strWhere = " where " + strWhere;
            List<VCartProductInfo> list = new List<VCartProductInfo>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from VCartProductInfo  " + strWhere);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
    }
}
