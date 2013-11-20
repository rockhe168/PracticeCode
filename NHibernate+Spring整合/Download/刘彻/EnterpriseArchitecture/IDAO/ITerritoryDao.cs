using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Entity;
using Domain.common;
 

namespace IDAO
{
    /// <summary>
    /// 数据访问(数据仓储)对象接口  
    /// DAO为系统的数据访问层。专管数据存取，其代码特征是一般不会含有条件判断语句。
    /// 系统使用NHibernate充当ORM工具，故所有和Hibernate有关的特性(API)都集中到这层，
    /// 不允许Service层依赖Hibernate代码以及包含HQL语句。
    /// </summary>
    public partial interface ITerritoryDao
    {
        /// <summary>
        /// 保存实体信息
        /// </summary>
        /// <param name="pEntity">实体对象</param>
        /// <returns>是否成功</returns>
        void Save(Territory pEntity);
        /// <summary>
        /// 删除实体信息
        /// </summary>
        /// <param name="pId">主键</param>
        /// <returns>是否成功</returns>
        void Delete(int pId);
        /// <summary>
        /// 获取实体信息
        /// </summary>
        /// <param name="pId">主键</param>
        /// <returns></returns>
        Territory Get(int pId);
        /// <summary>
        /// 获取实体代理，对象拉关系使用
        /// </summary>
        /// <param name="pId">主键</param>
        /// <returns></returns>
        Territory Load(int pId);
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <returns></returns>
        List< Territory> GetList();
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="pWhere">查询条件集合</param>
        /// <returns></returns>
        List< Territory> GetList(List<CanYouWhere> pWhere);
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="pOrderby">排序字段</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        List< Territory> GetList(string pOrderby, bool isAsc);
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="pPageIndex">所要获取的页数</param>
        /// <param name="pPageSize">每页记录数</param>
        /// <param name="pOrderby">排序字段</param>
        /// <param name="isAsc">排序</param>
        /// <param name="pRecordCount">总记录数</param>
        /// <returns></returns>
        List< Territory> GetList(int pPageIndex, int pPageSize, string pOrderby, bool isAsc, out int pRecordCount);
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
        List< Territory> GetList(int pPageIndex, int pPageSize, List<CanYouWhere> pWhere, string pOrderby, bool isAsc, out int pRecordCount);
    }
}
