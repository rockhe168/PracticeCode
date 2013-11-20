﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.Model;
using czcraft.DAL;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace czcraft.DAL
{
   public partial class master_typeDAL
    {
        #region 获取大师类别信息,通过大师id
        /// <summary>
        /// 获取大师类别信息,通过大师id
        /// </summary>
        /// <param name="MasterId">大师id</param>
        /// <param name="TypeName">大师类别名称(数组)</param>
        /// <returns></returns>
        public string GetByMasterId(int MasterId, out string TypeName)
        {
            string sql = "select * from VMasterType where Masterid=@MasterId";
            DataTable dt = SqlHelper.ExecuteDataTable(sql, (DbParameter)new SqlParameter("MasterId", MasterId));
            string Types = "";
            TypeName = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Types += dt.Rows[i]["Typeid"].ToString();
                TypeName += dt.Rows[i]["TypeName"].ToString();
                //如果不是最后一个
                if (i < dt.Rows.Count - 1)
                {
                    Types += ",";
                    TypeName += ",";
                }


            }

            return Types;
        } 
        #endregion


    }
}
