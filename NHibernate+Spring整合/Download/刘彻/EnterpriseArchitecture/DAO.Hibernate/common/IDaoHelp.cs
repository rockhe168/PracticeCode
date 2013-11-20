using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Domain.common;
using NHibernate;
using NHibernate.Criterion;

namespace DAO.Hibernate.common
{
    #region ParamInfo结构
    public struct ParamInfo
    {
        public string Name;
        public object Value;
    }
    #endregion
/**
 * 
 * @author rls
 */
    public interface IDaoHelp<T, PK> where T : class
    {
        // -------------------- 基本检索、增加、修改、删除操作 --------------------
        /// <summary>
        /// 获取Session
        /// </summary>
        /// <returns></returns>
        ISession GetSession();
        /// <summary>
        /// 关闭session
        /// </summary>
         void CloseSession();
        /// <summary>
        /// 根据主键获取实体。如果没有相应的实体，返回 null。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(PK id);
        /// <summary>
        //根据主键获取实体并加锁。如果没有相应的实体，返回 null。 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
         T GetWithLock(PK id, LockMode locked);
          /// <summary>
         /// // 根据主键获取实体。如果没有相应的实体，抛出异常。
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
         T Load(PK id);
        /// <summary>
         /// // 根据主键获取实体并加锁。如果没有相应的实体，抛出异常。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
         T LoadWithLock(PK id, LockMode locked);
        /// <summary>
         ///// 获取全部实体。 
        /// </summary>
        /// <returns></returns>
         List<T> LoadAll();
        // loadAllWithLock() ?
        /// <summary>
         /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
         void Update(T entity);
           /// <summary>
         /// 更新实体并加锁
         /// </summary>
         /// <param name="entity"></param>
          /// <param name="locked"></param>
         void UpdateWithLock(T entity, LockMode locked);
        /// <summary>
         /// // 存储实体到数据库
        /// </summary>
        /// <param name="entity"></param>
         void Save(T entity);

        /// <summary>
        /// 实现实体列表的保存
        /// </summary>
        /// <param name="entities"></param>
         void SaveAll(List<T> entities);
        // saveWithLock()
        /// <summary>
         /// // 增加或更新实体
        /// </summary>
        /// <param name="entity"></param>
         void SaveOrUpdate(T entity);
         /// <summary>
        /// // 增加或更新集合中的全部实体
        /// </summary>
        /// <param name="entities"></param>
         void SaveOrUpdateAll(Collection<T> entities);
        /// <summary>
         /// // 删除指定的实体
        /// </summary>
        /// <param name="entity"></param>
         void Delete(T entity);

        /// <summary>
        /// 根据hql语句删除 返回状态值 1成功 0是失败
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        int Delete(string queryString);

        /// <summary>
        /// 带参数的删除语句，可实现批量删除
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="values"></param>
        /// <param name="types"></param>
        void Delete(string queryString, object[] values, NHibernate.Type.IType[] types);
        /// <summary>
         /// // 加锁并删除指定的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="locked"></param>
        void DeleteWithLock(T entity, LockMode locked);
         /// <summary>
        /// // 根据主键删除指定实体
         /// </summary>
         /// <param name="id"></param>
         void DeleteByKey(PK id);
         /// <summary>
         /// // 根据主键加锁并删除指定的实体
         /// </summary>
         /// <param name="id"></param>
         /// <param name="locked"></param>
         void DeleteByKeyWithLock(PK id, LockMode locked);
         /// <summary>
         /// // 删除集合中的全部实体
         /// </summary>
         /// <param name="entities"></param>
         void DeleteAll(Collection<T> entities);
        /// <summary>
        /// 执行hql命令
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        int UpdateHQL(string hql);
         
        // -------------------- HSQL ----------------------------------------
        /// <summary>
        /// 返回总记录数
        /// </summary>
        /// <param name="countHql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        int CountHql(string countHql,object[] values);

        /// <summary>
        /// 使用hql获取分页,实体列表
        /// </summary>
        /// <param name="hql"></param>
        /// <param name="values"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<T> FindListByHql(string hql, object[] values, int pageIndex, int pageSize);

        /// <summary>
        /// 分页排序方法。
        /// </summary>
        /// <param name="entity">实体名称</param>
        /// <param name="pageIndex">请求页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="direction">排序方向</param>
        /// <param name="search">查找字段</param>
        /// <param name="recordCount">记录数</param>
        /// <returns></returns>
        List<T> GetPagedList(T entity, int pageIndex, int pageSize, string orderBy, string direction,
                                    string search, out int recordCount);

        /// <summary>
        /// 分页排序方法。
        /// </summary>
        /// <param name="pageIndex">请求页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="direction">排序方向</param>
        /// <param name="recordCount">记录数</param>
        /// <returns></returns>
        List<T> GetPagedList(int pageIndex, int pageSize, List<CanYouWhere> where, string orderBy, bool isAsc,
                                    out int recordCount);
        /// <summary>
        /// 使用hql获取分页,实体列表
        /// </summary>
        /// <param name="hql"></param>
        /// <param name="paramNames"></param>
        /// <param name="values"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<T> FindListByHql(string hql,string[] paramNames, object[] values, int pageIndex, int pageSize);
        /// <summary>
        /// 使用hql获取分页,数组列表
        /// </summary>
        /// <param name="hql"></param>
        /// <param name="values"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<object[]> FindObjsByHql(string hql, object[] values, int pageIndex, int pageSize);

        /// <summary>
        /// 使用hql获取分页,数组列表
        /// </summary>
        /// <param name="hql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        List<object[]> FindObjsByHql(string hql, object[] values);

        /// <summary>
        /// 使用hql获取分页,数组列表
        /// </summary>
        /// <param name="hql"></param>
        /// <param name="paramNames"></param>
        /// <param name="values"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<object[]> FindObjsByHql(string hql, string[] paramNames, object[] values, int pageIndex, int pageSize);

        // 使用HSQL语句检索数据
         List<T> Find(String queryString);

        // 使用带参数的HSQL语句检索数据
         List<T> Find(String queryString, Object[] values);

        // 使用带命名的参数的HSQL语句检索数据
         List<T> FindByNamedParam(String queryString, String[] paramNames,
                                     Object[] values);

        // 使用命名的HSQL语句检索数据
         List<T> FindByNamedQuery(String queryName);

        // 使用带参数的命名HSQL语句检索数据
         List<T> FindByNamedQuery(String queryName, Object[] values);

        // 使用带命名参数的命名HSQL语句检索数据
         List<T> FindByNamedQueryAndNamedParam(String queryName,
                                                  String[] paramNames, Object[] values);

        // -------------------------------- Criteria ------------------------------
         /// <summary>
         /// // 创建与会话无关的检索标准对象
         /// </summary>
         /// <returns></returns>
        
         DetachedCriteria CreateDetachedCriteria();
         /// <summary>
         ///  // 创建与会话绑定的检索标准对象
         /// </summary>
         /// <returns></returns>
        NHibernate.ICriteria CreateCriteria();
        /// <summary>
        /// // 使用指定的检索标准检索数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        IList<T> FindByCriteria(DetachedCriteria criteria);
        /// <summary>
        /// // 使用指定的检索标准检索数据，返回部分记录
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="firstResult"></param>
        /// <param name="maxResults"></param>
        /// <returns></returns>
        IList<T> FindByCriteria(DetachedCriteria criteria, int firstResult,
                               int maxResults);
        /// <summary>
        /// “复杂条件”实体对象列表
        /// 注意：没有关闭Session!
        /// (criteria是criterion的复数) 标准
        /// </summary>
        IList<T> GetEntities(NHibernate.Criterion.ICriterion iCriterion);
        //**********************************linq查询方式***********************
        IQueryable<T> FindByLinq();

        //-----------------------------------存储过程------------------------------------
        /// <summary>
        /// 执行存储过程(返回ILIST)
        /// </summary>
        /// <param name="spName">名称</param>
        /// <param name="paramInfos">参数表</param>
        IList ExecuteStoredProc(string spName, ICollection<ParamInfo> paramInfos);

        /// <summary>
        /// 执行存储过程(返回ILIST)
        /// </summary>
        /// <param name="spName">名称</param>
        /// <param name="paramInfos">参数表</param>
        IDataReader GetDataReaderStoredProc(string spName, ICollection<ParamInfo> paramInfos);

         /// <summary>
        /// // 强制初始化指定的实体
         /// </summary>
         /// <param name="proxy"></param>
         void Initialize(Object proxy);
         /// <summary>
         /// // 强制立即更新缓冲数据到数据库（否则仅在事务提交时才更新）
         /// </summary>
         void Flush();
         /// <summary>
         /// // 强制立即缓冲数据
         /// </summary>
         void Clear();
    }

}