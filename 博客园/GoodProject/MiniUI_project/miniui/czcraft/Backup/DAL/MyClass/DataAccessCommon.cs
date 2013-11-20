using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.Common;
using System.Data.SqlClient;
namespace czcraft.DAL{
/// <summary>
///公共的分页数据访问类
/// </summary>
public class DataAccessCommon
{
    DBO.DBOperator SqlHelper = DBO.DBOperator.instance();
    /// <summary>
    /// 公共的分页数据访问
    /// </summary>
    public DataAccessCommon()
    {
    }
    #region 分页获取数据
    /// <summary>
    ///分页获取数据
    /// </summary>
    /// <param name="tableName">表名</param>
    /// <param name="InnerJoin">内连接</param>
    /// <param name="strGetFields">返回的列信息</param>
    /// <param name="sortId">排序的列名</param>
    /// <param name="PageSize">每页记录数</param>
    /// <param name="PageIndex">页数</param>
    /// <param name="OrderType">排序类型排序类型, 非0 值则降序</param>
    /// <param name="strWhere">查询条件(注意: 不要加where) </param>
    public DataTable ListByPagination(string tableName, string InnerJoin, string strGetFields, string sortId, int PageSize, int PageIndex, string OrderType, string strWhere)
    {

        DataTable dt = SqlHelper.ExecuteDataTable("exec[pagination]  @tableName,@InnerJoin,@strGetFields,@sortId,@PageSize,@PageIndex,@doCount,@OrderType,@strWhere", (DbParameter)new SqlParameter("tableName", tableName), (DbParameter)new SqlParameter("@InnerJoin", InnerJoin), (DbParameter)new SqlParameter("@strGetFields", strGetFields), (DbParameter)new SqlParameter("@sortId", sortId), (DbParameter)new SqlParameter("@PageSize", PageSize), (DbParameter)new SqlParameter("@PageIndex", PageIndex), (DbParameter)new SqlParameter("@doCount", "0"), (DbParameter)new SqlParameter("@OrderType", OrderType), (DbParameter)new SqlParameter("@strWhere", strWhere));

        return dt;
    } 
    #endregion
    #region 获取表总记录个数(不用加where)
    /// <summary>
    ///获取表总记录个数(不用加where)
    ///<param name="tableName">表名</param>
    /// <param name="strWhere">查询条件(不用加where)</param>
    /// <summary>
    public int GetCountTable(string tableName, string strWhere)
    {
        if (!string.IsNullOrEmpty(strWhere))
            strWhere = " where " + strWhere;
        return SqlHelper.ExecuteSelectFirstNum("select count(1) from " + tableName + " " + strWhere);
    } 
    #endregion
    
}
}
