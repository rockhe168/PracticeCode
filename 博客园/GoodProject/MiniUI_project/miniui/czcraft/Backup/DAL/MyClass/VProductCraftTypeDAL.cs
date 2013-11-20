using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using czcraft.DAL;
using czcraft.Model;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
namespace czcraft.DAL
{
   public partial class VProductCraftTypeDAL
    {
        #region 通过大师id查找大师的产品(每种分别显示前8个)
        /// <summary>
        /// 通过大师id查找大师的产品(每种分别显示前8个)
        /// </summary>
        /// <param name="MasterId">大师id</param>
        /// <returns></returns>
        public IEnumerable<VProductCraftType> ListAllByMasterId(string MasterId)
        {
            List<VProductCraftType> list = new List<VProductCraftType>();
            DataTable dt = SqlHelper.ExecuteDataTable("select * from(select *,row_number() over (partition by TypeId order by TypeId) total from VProductCraftType where Masterid=@Masterid and Belongstype='0') rn where rn.total<=8", (DbParameter)new SqlParameter("Masterid", MasterId));
            foreach (DataRow row in dt.Rows)
            {
                list.Add(ToModel(row));
            }
            return list;
        } 
        #endregion
        #region 查询出展示或者佳作的前8位作品(联合查询)
        /// <summary>
        /// 查询出展示或者佳作的前8位作品(联合查询)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VProductCraftType> ListTopProductIsRecommentAndIsexcellent()
        {
            string sql = "select top(8) * from VProductCraftType   where Isrecomment='1'" + " union all " +
              "select top(8) * from VProductCraftType where Isexcellent='1'";
            List<VProductCraftType> list = new List<VProductCraftType>();
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToModel(dr));
            }
            return list;

        } 
        #endregion
        #region 通过大师id查找大师的产品(每种分别显示前8个)
        /// <summary>
        /// 通过大师id查找大师的产品(每种分别显示前8个)
        /// </summary>
        /// <param name="MasterId">大师id</param>
        /// <returns></returns>
        public DataTable ListAllByMasterIdToDatable(string MasterId)
        {
            return SqlHelper.ExecuteDataTable("select * from(select *,row_number() over (partition by TypeId order by TypeId) total from VProductCraftType where Masterid=@Masterid and Belongstype='0') rn where rn.total<=8", (DbParameter)new SqlParameter("Masterid", MasterId));
        } 
        #endregion
        #region  通过企业id查找企业的产品(每种分别显示前8个)
        /// <summary>
        /// 通过企业id查找企业的产品(每种分别显示前8个)
        /// </summary>
        /// <param name="MasterId">企业id</param>
        /// <returns></returns>
        public DataTable ListAllByCompanyIdToDatable(string CompanyId)
        {
            return SqlHelper.ExecuteDataTable("select * from(select *,row_number() over (partition by TypeId order by TypeId) total from VProductCraftType where Companyid=@Companyid and Belongstype='1') rn where rn.total<=8", (DbParameter)new SqlParameter("Companyid", CompanyId));
        } 
        #endregion
        #region  查找非遗作品(每种分别显示前8个)
        /// <summary>
        /// 查找非遗作品(每种分别显示前8个)
        /// </summary>
        /// <returns></returns>
        public DataTable ListAllByNongeneticToDatable()
        {
            return SqlHelper.ExecuteDataTable("select * from(select *,row_number() over (partition by TypeId order by TypeId) total from VProductCraftType where Nongenetic='1') rn where rn.total<=8");

        } 
        #endregion

    }
}
