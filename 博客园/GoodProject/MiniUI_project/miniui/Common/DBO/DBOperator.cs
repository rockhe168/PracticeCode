using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;

namespace Zys.DBO
{
    /// <summary>
    /// DBOperator公共连接类(提供了OLE,SQL等通用接口)
    /// </summary>
    public abstract class DBOperator
    {
        /// <summary>
        /// 得到一个数据库
        /// </summary>
        public abstract IDbConnection Connection { get; } //得到数据库连接 

        static int CurrentPosition = -1;
        /// <summary>
        /// 获得reader流,只读式查询性能比较高,记住,由于reader流的独占式连接,reader流一定要主动close,否则会出现连接未关闭
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回reader流</returns>
        public abstract DbDataReader GetReader(string sql);

        /// <summary>
        /// 获取数据库设配集
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>强类型的设配集</returns>
        public abstract DbDataAdapter GetAdapter(string sql);
        /// <summary>
        /// //获取选择的行数
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>该表总记录</returns>
        public abstract int GetSelectNums(string sql);
        /// <summary>
        /// 返回查询第一行的结果(强制转化为int类型显示)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回查询结果(第一行第一列)</returns>
        public abstract int GetSelectFirstNum(string sql);
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public abstract void Open(); //打开数据库连接 
        /// <summary>
        /// 关闭数据库连接 
        /// </summary>
        public abstract void Close(); //关闭数据库连接 
        /// <summary>
        /// 开始一个事务 
        /// </summary>
        public abstract void BeginTrans(); //开始一个事务 
        /// <summary>
        /// //提交一个事务 
        /// </summary>
        public abstract void CommitTrans(); //提交一个事务 
        /// <summary>
        ///  回滚一个事务 
        /// </summary>
        public abstract void RollbackTrans(); //回滚一个事务 
        /// <summary>
        /// 执行sql语句,如果返回true,则执行成功,否则执行失败
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <returns>返回执行状态</returns>
        public abstract bool ExecuteUpdate(string strSql);
        /// <summary>
        /// 重载ExecuteUpdate,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递ExcuteUpdate(sql,str,ob);
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="objValues">传递params的值</param>
        /// <returns>返回执行状态</returns>
        public abstract bool ExecuteUpdate(string strSql, string[] strParams, object[] objValues);
        //执行Sql语句，没有返回值 
        /// <summary>
        /// 返回dataset数据集,返回一个数据表放在内存中
        /// </summary>
        /// <param name="QueryString">查询语句sql</param>
        /// <returns>返回dataset数据集</returns>
        public abstract DataSet GetDataSet(string QueryString);//执行Sql，返回DataSet 
        /// <summary>
        /// 重载GetDataSet,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递GetDataSet(sql,str,ob);
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="objValues">传递params的值</param>
        /// <returns>返回一个数据集</returns>
        public abstract DataSet GetDataSet(string strSql, string[] strParams, object[] objValues);//执行Sql，返回DataSet 
        /// <summary>
        /// 查询数据,返回一个数据表
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <returns>返回执行状态</returns>
        public abstract bool SearchTable(string strSQL);
        /// <summary>
        /// 重载SearchTable,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchTable(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回执行状态</returns>
        public abstract bool SearchTable(string strSQL, string[] strParams, object[] strValues);
        /// <summary>
        /// 查询数据,返回查询结果第一行第一列
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public abstract string SearchValue(string strSQL);
        /// <summary>
        /// 重载SearchValue,返回查询结果第一行第一列,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public abstract string SearchValue(string strSQL, string[] strParams, object[] strValues);
        /// <summary>
        /// 执行sql语句,返回ID,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public abstract int ExecSqlAndReturnID(string strSQL, string[] strParams, object[] strValues);//    执行SQL，并返回ID
        /// <summary>
        /// 实例化数据库
        /// </summary>
        /// <returns>返回一个DBOperator类型</returns>
        public static DBOperator Instance()
        {
            return CreateNewDBOperator("");
        }
        /// <summary>
        /// 重载Instance函数,用于实例化DBO
        /// </summary>
        /// <param name="ConnStr">传递数据库连接语句</param>
        /// <returns>返回一个DBOperator</returns>
        public static DBOperator Instance(string ConnStr)
        {
            //if (ConnectionPool.Length < 1) //没有缓冲 
            //{
            return CreateNewDBOperator(ConnStr);
            //}
            //else
            //{
            //    CurrentPosition++;
            //    if (CurrentPosition == ConnectionPool.Length)
            //        CurrentPosition = 0;
            //    if (ConnectionPool[CurrentPosition] == null)
            //    {
            //        ConnectionPool[CurrentPosition] = CreateNewDBOperator(ConnStr);
            //    }
            //    return ConnectionPool[CurrentPosition];
            //}
        }

        /// <summary>
        /// 创建一个新的数据库连接类
        /// </summary>
        /// <param name="ConnStr">数据库连接语句</param>
        /// <returns>返回一个DBOperator</returns>
        private static DBOperator CreateNewDBOperator(string ConnStr)
        {

            if (DataBaseType.type != "Access") //SqlServer 
            {
                return new SqlDBOperator(DataBaseType.connectionstring);
            }
            else //other database 
            {
                //return new OleDBOperator("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" 
                //    + System.Web.HttpContext.Current.Server.MapPath(DataBaseType.connectionstring));
                if (ConnStr == "")
                {

                    return new SqlDBOperator(DataBaseType.connectionstring);
                }
                else
                {
                    return new SqlDBOperator(ConnStr);
                }

            }
        }
    }


}

