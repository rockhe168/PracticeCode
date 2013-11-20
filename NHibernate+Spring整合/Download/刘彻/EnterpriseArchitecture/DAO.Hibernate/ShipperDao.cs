using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using IDAO;
using Domain.Entity;
using Domain.common;
using DAO.Hibernate.common;

 

namespace DAO.Hibernate
{
    /// <summary>
    /// 数据访问(数据仓储)对象  
    /// DAO为系统的数据访问层。专管数据存取，其代码特征是一般不会含有条件判断语句。
    /// 系统使用NHibernate充当ORM工具，故所有和Hibernate有关的特性(API)都集中到这层，
    /// 不允许Service层依赖Hibernate代码以及包含HQL语句。
    /// </summary>
    public partial class ShipperDao :IShipperDao
    {
        private IDaoHelp< Shipper, int> HibernateDaoHelp { get; set; }
        /// <summary>
        /// 保存实体信息
        /// </summary>
        /// <param name="pEntity">实体对象</param>
        /// <returns>是否成功</returns>
        public void Save(Shipper pEntity)
        {
            HibernateDaoHelp.SaveOrUpdate(pEntity);
        }
        /// <summary>
        /// 删除实体信息
        /// </summary>
        /// <param name="pId">主键</param>
        /// <returns>是否成功</returns>
        public void Delete(int pId)
        {
            HibernateDaoHelp.DeleteByKey(pId);
        }
        /// <summary>
        /// 获取实体信息
        /// </summary>
        /// <param name="pId">主键</param>
        /// <returns></returns>
        public Shipper Get(int pId)
        {
            return HibernateDaoHelp.Get(pId);
        }

        /// <summary>
        /// 获取实体代理，对象拉关系使用
        /// </summary>
        /// <param name="pId">主键</param>
        /// <returns></returns>
        public Shipper Load(int pId)
        {
            return HibernateDaoHelp.Load(pId);
        }
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <returns></returns>
        public List< Shipper> GetList()
        {
            int recordCount = 0;
            List<CanYouWhere> wheres = new List<CanYouWhere>();
            return this.GetList(1, 999999, wheres, null, true, out recordCount);
        }
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="pWhere">查询条件集合</param>
        /// <returns></returns>
        public List< Shipper> GetList(List<CanYouWhere> pWhere)
        {
            int recordCount = 0;
            return this.GetList(1, 99999, pWhere, null, true, out recordCount);
        }
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="pOrderby">排序字段</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        public List< Shipper> GetList(string pOrderby, bool isAsc)
        {
            int recordCount = 0;
            List<CanYouWhere> wheres = new List<CanYouWhere>();
            return this.GetList(1, 99999, wheres, pOrderby, isAsc, out recordCount);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pPageIndex">所要获取的页数</param>
        /// <param name="pPageSize">每页记录数</param>
        /// <param name="pOrderby">排序字段</param>
        /// <param name="isAsc">排序</param>
        /// <param name="pRecordCount">总记录数</param>
        /// <returns></returns>
        public List< Shipper> GetList(int pPageIndex, int pPageSize, string pOrderby, bool isAsc, out int pRecordCount)
        {
            List<CanYouWhere> wheres = new List<CanYouWhere>();
            return this.GetList(pPageIndex, pPageSize, wheres, pOrderby, isAsc, out pRecordCount);
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="pPageIndex">所要获取的页数</param>
        /// <param name="pPageSize">每页记录数</param>
        /// <param name="pWhere">查询条件集合</param>
        /// <param name="pOrderby">排序字段</param>
        /// <param name="isAsc">排序</param>
        /// <param name="pRecordCount">列表行数</param>
        /// <returns>集合列表</returns>
        public List< Shipper> GetList(int pPageIndex, int pPageSize, List<CanYouWhere> pWhere, string pOrderby, bool isAsc, out int pRecordCount)
        {
            return HibernateDaoHelp.GetPagedList(pPageIndex, pPageSize, pWhere, pOrderby, isAsc, out pRecordCount);
        }
    }
}
