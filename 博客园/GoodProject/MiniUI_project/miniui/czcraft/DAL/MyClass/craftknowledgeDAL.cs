using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using czcraft.Model;

namespace czcraft.DAL
{
    public partial class craftknowledgeDAL
    {
        #region 根据时间获取上一条记录和下一条记录
        /// <summary>
        /// 根据时间获取上一条记录和下一条记录
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns>DataSet值</returns>
        public DataSet GetPreAndNextItem(DateTime dt)
        {
            string sql = string.Format("select top 1 * from craftknowledge where [Time] >= '{0}' order by Time desc; select top 1 * from craftknowledge where [Time] < '{0}' order by Time desc", dt);

            return SqlHelper.GetDataSet(sql);
        } 
        #endregion
        #region 获取前n条工艺知识
        /// <summary>
        /// 获取前n条工艺知识
        /// </summary>
        /// <param name="TopNum">前n</param>
        /// <returns></returns>
        public IEnumerable<craftknowledge> GetTopCraftKnowledge(int TopNum)
        {
            string sql = "select top (" + TopNum + ") * from craftknowledge order by Time desc";
            List<craftknowledge> list = new List<craftknowledge>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;
        } 
        #endregion
        #region 获取最大记录号
        /// <summary>
        /// 获取最大记录号
        /// </summary>
        /// <returns></returns>

        public int GetMaxId()
        {
            string sql = "select Max(Id) as MaxId from craftknowledge";
            return (int)SqlHelper.ExecuteScalar(sql);
        } 
        #endregion
    }
}
