using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data;


namespace DBO
{
    public class OleDBOperator : DBOperator
    {
        /// <summary>
        /// 数据连接
        /// </summary>
        private OleDbConnection conn;
        /// <summary>
        /// 事务
        /// </summary>
        private OleDbTransaction trans;
        /// <summary>
        /// 事务是否完成
        /// </summary>
        private bool inTransaction = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strConnection">数据库连接字符串</param>
        public  OleDBOperator(string strConnection)
        {
            this.conn = new OleDbConnection(strConnection);
        }
        /// <summary>
        /// 获取 IDbConnection
        /// </summary>
        public  IDbConnection Connection
        {
            get { return this.conn; }

        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public override void Open()
        {
            if (conn.State.ToString().ToUpper() != "OPEN")
                this.conn.Open();
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public override void Close()
        {
            if (conn.State.ToString().ToUpper() == "OPEN")
                this.conn.Close();
        }
        /// <summary>
        /// 开始事务
        /// </summary>
        public override void BeginTrans()
        {
            trans = conn.BeginTransaction();
            inTransaction = true;
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public override void CommitTrans()
        {
            trans.Commit();
            inTransaction = false;
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public override void RollbackTrans()
        {
            trans.Rollback();
            inTransaction = false;
        }
        #region 旧版本
        /// <summary>
        /// 返回查询第一行的结果(强制转化为int类型显示)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回查询结果(第一行第一列)</returns>
        public override int GetSelectFirstNum(string sql)
        {
            Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this.conn;
            cmd.CommandText = sql;
            int nums = Convert.ToInt32(cmd.ExecuteScalar());
            Close();
            return nums;
        }

        /// <summary>
        /// 获取数据适配器
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>DbDataAdapter适配器</returns>
        public override DbDataAdapter GetAdapter(string sql)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(sql, this.conn);
            return da;

        }
        /// <summary>
        /// //获取选择的行数(注意:如果包含group by 等语句,则可能出错)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>该表总记录</returns>
        public override int GetSelectNums(string sql)//获取选择的行数
        {
            sql = "select count(*) from (" + sql + ") as temp";
            Open();
            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = this.conn;
            cmd.CommandText = sql;
            int nums = Convert.ToInt32(cmd.ExecuteScalar());
            Close();
            return nums;
        }
        #region ExecuteUpdate
        /// <summary>
        /// 执行sql语句,如果返回true,则执行成功,否则执行失败
        /// </summary>
        /// <param name="strSql">查询语句sql</param>
        /// <returns>返回执行状态</returns>
        public override bool ExecuteUpdate(string strSql)
        {
            Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.Text;
            bool ret = cmd.ExecuteNonQuery() > 0;
            Close();
            return ret;
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
            OleDbCommand cmd = new OleDbCommand();
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
                    OleDbParameter param = new OleDbParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            bool ret = cmd.ExecuteNonQuery() > 0;
            Close();
            return ret;
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
            OleDbCommand cmd = new OleDbCommand();
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
                    OleDbParameter param = new OleDbParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            Close();
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
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            DataSet ds = new DataSet();
            OleDbDataAdapter ad = new OleDbDataAdapter();
            cmd.CommandText = QueryString;
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            Close();
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
            OleDbDataReader OleDr = null;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            OleDr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (OleDr.Read())
            {
                if (OleDr != null)
                    OleDr.Close();
                Close();
                return true;
            }
            else
            {
                if (OleDr != null)
                    OleDr.Close();
                Close();
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
            OleDbDataReader OleDr = null;
            OleDbCommand cmd = new OleDbCommand();
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
                    OleDbParameter param = new OleDbParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            OleDr = cmd.ExecuteReader();
            if (OleDr.Read())
            {
                if (OleDr != null)
                    OleDr.Close();
                Close();
                return true;
            }
            else
            {
                if (OleDr != null)
                    OleDr.Close();
                Close();
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
            OleDbDataReader OleDbDr = null;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            OleDbDr = cmd.ExecuteReader();
            if (OleDbDr.Read())
            {
                Result = OleDbDr[0].ToString();
                if (OleDbDr != null)
                    OleDbDr.Close();
                Close();
                return Result;
            }
            else
            {
                if (OleDbDr != null)
                    OleDbDr.Close();
                Close();
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
            OleDbDataReader OleDbDr = null;
            OleDbCommand cmd = new OleDbCommand();
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
                    OleDbParameter param = new OleDbParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);
                }
            }
            OleDbDr = cmd.ExecuteReader();
            if (OleDbDr.Read())
            {
                Result = OleDbDr[0].ToString();
                if (OleDbDr != null)
                    OleDbDr.Close();
                Close();
                return Result;
            }
            else
            {
                if (OleDbDr != null)
                    OleDbDr.Close();
                Close();
                return Result;
            }
        }
        #endregion
        #region ExecSqlAndReturnID  执行sql语句,返回ID
        /// <summary>
        /// 执行sql语句,返回ID,一种安全的执行方式,推荐使用,传递参数为查询语句strSql,string数组,和Object数组,string数组用来存
        //放参数,object用来保存值,例如string[] str={"@name","@id"},object[] ob={"tianzh",3}传递SearchValue(sql,str,ob);
        /// </summary>
        /// <param name="strSQL">查询语句sql</param>
        /// <param name="strParams">传递params参数</param>
        /// <param name="strValues">传递params的值</param>
        /// <returns>返回查询结果,如果多条数据,则是第一行第一列</returns>
        public override int ExecSqlAndReturnID(string strSQL, string[] strParams, object[] strValues)
        {
            Open();
            OleDbCommand cmd = new OleDbCommand();
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
                    OleDbParameter param = new OleDbParameter(strParams[i], strValues[i]);
                    cmd.Parameters.Add(param);

                }
            }
            int isUpdateOk = -1;
            isUpdateOk = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (isUpdateOk > 0)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Select @@identity as [MaxID]";
                int ret = int.Parse(cmd.ExecuteScalar().ToString());
                Close();
                return ret;
            }
            Close();
            return 0;
        }
        #endregion
        #region GetReader
        /// <summary>
        /// //得到read流并返回
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public override DbDataReader GetReader(string sql)
        {
            Open();
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader read = com.ExecuteReader();
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

            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery() > 0;
            }

            conn.Close();

        }
        /// <summary>
        /// 执行语句,获取第一行第一列的数据
        /// <param name="cmdText">sql语句</param>
        /// <param name="parameters">可变参数</param>
        /// <returns>执行结果</returns>
        public override object ExecuteScalar(string cmdText,
           params DbParameter[] parameters)
        {

            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
            conn.Close();
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
            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            conn.Close();
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
            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
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
            conn.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter(cmdText, conn);
            return sda;

        }
        /// <summary>
        /// 返回查询第一行的结果(强制转化为int类型显示)
        /// </summary>
        /// <param name="sql">查询语句sql</param>
        /// <returns>返回查询结果(第一行第一列)</returns>
        public override int ExecuteSelectFirstNum(string cmdText, params DbParameter[] parameters)
        {
            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                if (inTransaction)
                    cmd.Transaction = trans;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(parameters);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            conn.Close();

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
            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
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
                conn.Close();
            }
        }

        #endregion
    }
}
