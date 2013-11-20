using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace DBO
{

    public class SqlDBOperator : DBOperator
    {
        private SqlConnection conn; //数据库连接 
        private SqlTransaction trans; //事务处理类 
        private bool inTransaction = false; //指示当前是否正处于事务中 
        #region Connection 数据库连接
        /// <summary>
        /// Connection 数据库连接
        /// </summary>
        public IDbConnection Connection
        {
            get { return this.conn; }
        }
        #endregion

        #region SqlDBOperator 构造函数
        /// <summary>
        /// SqlDBOperator 构造函数
        /// </summary>
        /// <param name="strConnection">数据库连接字符串</param>
        public  SqlDBOperator(string strConnection)
        {
            this.conn = new SqlConnection(strConnection);
        }
        #endregion
        #region Open 打开链接
        /// <summary>
        ///  Open 打开链接
        /// </summary>
        public override void Open()
        {
            if (conn.State==ConnectionState.Closed)
                this.conn.Open();

        }
        #endregion
        #region Close  关闭连接
        /// <summary>
        /// Close  //关闭连接
        /// </summary>
        public override void Close()
        {
            if (conn.State==ConnectionState.Open)
                this.conn.Close();
        }
        #endregion
        #region BeginTrans
        /// <summary>
        /// 开始事务
        /// </summary>
        public override void BeginTrans()
        {
            if (inTransaction) return;
            trans = conn.BeginTransaction();
            inTransaction = true;
        }
        #endregion
        #region CommitTrans
        /// <summary>
        /// 提交事务
        /// </summary>
        public override void CommitTrans()
        {
            trans.Commit();
            inTransaction = false;
        }
        #endregion
        #region RollbackTrans
        /// <summary>
        /// 事务回滚
        /// </summary>
        public override void RollbackTrans()
        {
            trans.Rollback();
            inTransaction = false;
        }
        #endregion
        #region 旧版本
        #region GetAdapter
        /// <summary>
        /// 获取一个数据适配器
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>数据适配器</returns>
        public override DbDataAdapter GetAdapter(string sql)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, this.conn);
            return da;
        }
        #endregion
        #region GetSelectFirstNum
        /// <summary>
        /// 获取第一行第一列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>第一行第一列</returns>
        public override int GetSelectFirstNum(string sql)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = sql;
            int nums = Convert.ToInt32(cmd.ExecuteScalar());
            Close();
            return nums;

        }
        #endregion
        #region GetSelectNums
        /// <summary>
        /// //获取选择的行数(注意:如果包含group by 等语句,则可能出错)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回选择行数</returns>
        public override int GetSelectNums(string sql)
        {
            sql = "select count(*) from (" + sql + ") as temp";
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = sql;
            int nums = Convert.ToInt32(cmd.ExecuteScalar());
            Close();
            return nums;
        }

        #endregion
        #region ExecuteUpdate
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>执行状态</returns>
        public override bool ExecuteUpdate(string strSql)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteNonQuery() > 0;
        }
        /// <summary>
        /// 重载ExecuteUpdate,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放
        ///参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递ExcuteUpdate(sql,str,ob);
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="objValues">传递params的值</param>
        /// <returns>返回执行状态</returns>
        public override bool ExecuteUpdate(string strSql, string[] strParams, object[] strValues)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            if ((strParams != null) && (strParams.Length != strValues.Length))
                throw new Exception("查询参数和值不对应!");
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.Text;
            if (strParams != null)
            {
                for (int i = 0; i < strParams.Length; i++)
                {
                    SqlParameter param = new SqlParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);

                }
            }
            return cmd.ExecuteNonQuery() > 0;
        }
        #endregion
        #region GetDataSet
        /// <summary>
        /// 重载GetDataSet,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参
        //数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递GetDataSet(sql,str,ob);
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="objValues">传递params的值</param>
        /// <returns>返回一个数据集</returns>
        public override DataSet GetDataSet(string strSql, string[] strParams, object[] strValues)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            if ((strParams != null) && (strParams.Length != strValues.Length))
                throw new Exception("查询参数和值不对应!");
            cmd.CommandText = strSql;
            if (strParams != null)
            {
                for (int i = 0; i < strParams.Length; i++)
                {
                    SqlParameter param = new SqlParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds;
        }
        //执行Sql语句，没有返回值 
        /// <summary>
        /// 返回dataset数据集,返回一个数据表放在内存中
        /// </summary>
        /// <param name="QueryString">查询语句sql</param>
        /// <returns>返回dataset数据集</returns>
        public override DataSet GetDataSet(string QueryString)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            cmd.CommandText = QueryString;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds;
        }
        #endregion
        #region SearchTable
        /// <summary>
        /// 查询数据,返回一个数据表
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <returns>返回执行状态</returns>
        public override bool SearchTable(string strSQL)
        {
            Open();
            SqlDataReader SqlDr = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            SqlDr = cmd.ExecuteReader();
            if (SqlDr.Read())
            {
                if (SqlDr != null)
                    SqlDr.Close();
                return true;
            }
            else
            {
                if (SqlDr != null)
                    SqlDr.Close();
                return false;
            }
        }
        /// <summary>
        /// 重载SearchTable,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存放参
        //数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchTable(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回执行状态</returns>
        public override bool SearchTable(string strSQL, string[] strParams, object[] strValues)
        {
            Open();
            SqlDataReader SqlDr = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            if ((strParams != null) && (strParams.Length != strValues.Length))
                throw new Exception("查询参数和值不对应!");
            if (strParams != null)
            {
                for (int i = 0; i < strParams.Length; i++)
                {
                    SqlParameter param = new SqlParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            SqlDr = cmd.ExecuteReader();
            if (SqlDr.Read())
            {
                if (SqlDr != null)
                    SqlDr.Close();
                return true;
            }
            else
            {
                if (SqlDr != null)
                    SqlDr.Close();
                return false;
            }
        }
        #endregion
        #region SearchValue
        /// <summary>
        /// 查询数据,返回查询结果第一行第一列
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public override string SearchValue(string strSQL)
        {
            Open();
            string Result = null;
            SqlDataReader SqlDr = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            SqlDr = cmd.ExecuteReader();
            if (SqlDr.Read())
            {
                Result = SqlDr[0].ToString();
                if (SqlDr != null)
                    SqlDr.Close();
                return Result;
            }
            else
            {
                if (SqlDr != null)
                    SqlDr.Close();
                return Result;
            }
        }
        /// <summary>
        /// 重载SearchValue,返回查询结果第一行第一列,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object
        //数组,string数组用来存放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue
        //(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public override string SearchValue(string strSQL, string[] strParams, object[] strValues)
        {
            Open();
            string Result = null;
            SqlDataReader SqlDr = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            if ((strParams != null) && (strParams.Length != strValues.Length))
                throw new Exception("查询参数和值不对应!");
            if (strParams != null)
            {
                for (int i = 0; i < strParams.Length; i++)
                {
                    SqlParameter param = new SqlParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            SqlDr = cmd.ExecuteReader();
            if (SqlDr.Read())
            {
                Result = SqlDr[0].ToString();
                if (SqlDr != null)
                    SqlDr.Close();
                return Result;
            }
            else
            {
                if (SqlDr != null)
                    SqlDr.Close();
                return Result;
            }
        }
        #endregion
        #region ExecSqlAndReturnID 执行SQL，并返回ID
        /// <summary>
        ///执行sql语句,返回ID,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存
        //放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public override int ExecSqlAndReturnID(string strSQL, string[] strParams, object[] strValues)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            if ((strParams != null) && (strParams.Length != strValues.Length))
                throw new Exception("查询参数和值不对应!");
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            if (strParams != null)
            {
                for (int i = 0; i < strParams.Length; i++)
                {
                    SqlParameter param = new SqlParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            int isUpdateOk = -1;
            isUpdateOk = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (isUpdateOk > 0)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Select @@identity as [MaxID]";
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            return 0;
        }
        #endregion
        #region GetReader
        /// <summary>
        /// //得到read流并返回
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public override DbDataReader GetReader(string sql)//得到read流并返回
        {
            Open();
            SqlCommand com = new SqlCommand(sql, this.conn);
            SqlDataReader read = com.ExecuteReader();
            return read;
        }
        #endregion

        #endregion
        #region 新版本
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>执行状态</returns>
        public override bool ExecuteNonQuery(string cmdText,
           params DbParameter[] parameters)
        {
           
                Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    if (inTransaction)
                        cmd.Transaction = trans;
                    cmd.CommandText = cmdText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery()>0;
                }

                Close();
            
        }
        /// <summary>
        /// 执行语句,获取第一行第一列的数据
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>执行结果</returns>
        public override object ExecuteScalar(string cmdText,
           params DbParameter[] parameters)
        {

            Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
            Close();
        }
        /// <summary>
        /// 查询并返回查询结果集
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>DataTable结果</returns>
        public override DataTable ExecuteDataTable(string cmdText,
            params DbParameter[] parameters)
        {
            Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            Close();
        }
        /// <summary>
        /// 查询并返回read流
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>DbDataReader流</returns>
        public override DbDataReader ExecuteDataReader(string cmdText,
          params DbParameter[] parameters)
        {
            Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <returns>强类型的设配集</returns>
        /// <summary>
        /// 获取数据库设配集
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>DbDataAdapter适配器</returns>
        public override DbDataAdapter ExecuteDataAdapter(string cmdText, params DbParameter[] parameters)
        {
            Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmdText,conn);
            return sda;
           
        }
        /// <summary>
        /// 返回查询第一行的结果(强制转化为int类型显示)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回查询结果(第一行第一列)</returns>
        public override int ExecuteSelectFirstNum(string cmdText, params DbParameter[] parameters)
        {
            Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            Close();
        
        }
        /// <summary>
        /// 执行sql语句,返回ID,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,dbparameter数组
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="parameters">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public override int ExecSqlAndReturnID(string cmdText, params DbParameter[] parameters)
        //    执行SQL，并返回ID
        {
            Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
            int isUpdateOk = -1;
            isUpdateOk = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (isUpdateOk > 0)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Select @@identity as [MaxID]";
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            return 0;
            Close();
            }
        }
        
        #endregion
    }
}
