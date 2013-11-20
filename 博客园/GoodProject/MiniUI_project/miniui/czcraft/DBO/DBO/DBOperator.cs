using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace DBO
{
  
    /// <summary>
    /// 定义一个数据库连接接口,定义数据库连接的操作
    /// </summary>
  abstract public class DBOperator
    {

        protected IDbConnection Connection { get; set; }//得到数据库连接
        /// <summary>
        /// 创建一个新的数据库连接类
        /// </summary>
        /// <param name="ConnStr">数据库连接语句</param>
        /// <returns>返回一个DBOperator</returns>
        public static DBOperator instance(string ConnStr, DataAccess.DataType type)
        {
            if (type == DataAccess.DataType.Sql) //SqlServer
                return new SqlDBOperator(ConnStr);
            else 
                return new OleDBOperator(ConnStr);


        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
      abstract  public void Open(); //打开数据库连接 
        /// <summary>
        /// 关闭数据库连接 
        /// </summary>
      abstract public void Close(); //关闭数据库连接 
        /// <summary>
        /// 开始一个事务 
        /// </summary>
      abstract public void BeginTrans(); //开始一个事务 
        /// <summary>
        /// //提交一个事务 
        /// </summary>
      abstract public void CommitTrans(); //提交一个事务 
        /// <summary>
        ///  回滚一个事务 
        /// </summary>
      abstract public void RollbackTrans(); //回滚一个事务 
        /// <summary>
        /// 默认实例化的是sql
        /// </summary>
        /// <returns></returns>
       public static DBOperator instance()
        {

            return new SqlDBOperator(DataAccess.connstr);
        }

        #region 旧版本dbo

        /// <summary>
        /// 获得reader流,只读式查询性能比较高,记住,由于reader流的独占式连接,reader流一定要主动close,否则会出现连接未关闭
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回reader流</returns>
      abstract public DbDataReader GetReader(string sql);
        /// <summary>
        /// 获取数据库设配集
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>强类型的设配集</returns>
      abstract public DbDataAdapter GetAdapter(string sql);
        /// <summary>
        /// //获取选择的行数(注意:如果包含group by 等语句,则可能出错)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>该表总记录</returns>
      abstract public int GetSelectNums(string sql);
        /// <summary>
        /// 返回查询第一行的结果(强制转化为int类型显示)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回查询结果(第一行第一列)</returns>
      abstract public int GetSelectFirstNum(string sql);
        /// <summary>
        /// 执行sql语句,如果返回true,则执行成功,否则执行失败
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <returns>返回执行状态</returns>
      abstract public bool ExecuteUpdate(string strSql);
        /// <summary>
        /// 重载ExecuteUpdate,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放
        ///参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递ExcuteUpdate(sql,str,ob);
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="objValues">传递params的值</param>
        /// <returns>返回执行状态</returns>
      abstract public bool ExecuteUpdate(string strSql, string[] strParams, object[] objValues);
        //执行Sql语句，没有返回值 
        /// <summary>
        /// 返回dataset数据集,返回一个数据表放在内存中
        /// </summary>
        /// <param name="QueryString">查询语句sql</param>
        /// <returns>返回dataset数据集</returns>
      abstract public DataSet GetDataSet(string QueryString);//执行Sql，返回DataSet 
        /// <summary>
        /// 重载GetDataSet,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参
        //数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递GetDataSet(sql,str,ob);
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="objValues">传递params的值</param>
        /// <returns>返回一个数据集</returns>
      abstract public DataSet GetDataSet(string strSql, string[] strParams, object[] objValues);//执行Sql，返回DataSet 
        /// <summary>
        /// 查询数据,返回一个数据表
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <returns>返回执行状态</returns>
        abstract public bool SearchTable(string strSQL);
        /// <summary>
        /// 重载SearchTable,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参
        //数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchTable(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回执行状态</returns>
        abstract public bool SearchTable(string strSQL, string[] strParams, object[] strValues);
        /// <summary>
        /// 查询数据,返回查询结果第一行第一列
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        abstract public string SearchValue(string strSQL);
        /// <summary>
        /// 重载SearchValue,返回查询结果第一行第一列,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object
        //数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue
        //(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        abstract public string SearchValue(string strSQL, string[] strParams, object[] strValues);
        /// <summary>
        /// 执行sql语句,返回ID,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存
        //放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        abstract public int ExecSqlAndReturnID(string strSQL, string[] strParams, object[] strValues);//    执行SQL，并返回ID
        #endregion



        #region 新版本语句
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>执行状态</returns>
        abstract public  bool ExecuteNonQuery(string cmdText,
           params DbParameter[] parameters);
        /// <summary>
        /// 执行语句,获取第一行第一列的数据
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>执行结果</returns>
        abstract public  object ExecuteScalar(string cmdText,
           params DbParameter[] parameters);
        /// <summary>
        /// 查询并返回查询结果集
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>DataTable结果</returns>
       abstract public  DataTable ExecuteDataTable(string cmdText,
           params DbParameter[] parameters);
        /// <summary>
        /// 查询并返回read流
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>DbDataReader流</returns>
        abstract public  DbDataReader ExecuteDataReader(string cmdText,
          params DbParameter[] parameters);
    
        /// <returns>强类型的设配集</returns>
        /// <summary>
        /// 获取数据库设配集
         /// </summary>
         /// <param name="sql">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>DbDataAdapter适配器</returns>
        abstract public DbDataAdapter ExecuteDataAdapter(string cmdText, params DbParameter[] parameters);
             /// <summary>
            /// 返回查询第一行的结果(强制转化为int类型显示)
            /// </summary>
            /// <param name="sql">查询语句sql</param>
            /// <returns>返回查询结果(第一行第一列)</returns>
        abstract public int ExecuteSelectFirstNum(string cmdText, params DbParameter[] parameters);
        /// <summary>
        /// 执行sql语句,返回ID,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,dbparameter数组
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="parameters">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        abstract public int ExecSqlAndReturnID(string cmdText, params DbParameter[] parameters);//    执行SQL，并返回ID
        
        #endregion
    }   
   
}
