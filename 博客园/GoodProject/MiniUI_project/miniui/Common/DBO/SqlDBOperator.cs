/******************************************************************************
 *  作者：       tianzh
 *  创建时间：   2012/4/2 9:49:11
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
////51-A-s-p-x.com
namespace Zys.DBO
{
    public class SqlDBOperator : DBOperator
    {
        private SqlConnection conn; //数据库连接 
        private SqlTransaction trans; //事务处理类 
        private bool inTransaction = false; //指示当前是否正处于事务中 
        #region Connection
        public override IDbConnection Connection
        {
            get { return this.conn; }
        }
          #endregion
        #region SqlDBOperator
        public SqlDBOperator(string strConnection)
        {
            this.conn = new SqlConnection(strConnection);
        }
          #endregion
        #region Open
        public override void Open()
        {
            if (conn.State.ToString().ToUpper() != "OPEN")
                this.conn.Open();

        }
          #endregion
        #region Close
        public override void Close()
        {
            if (conn.State.ToString().ToUpper() == "OPEN")
                this.conn.Close();
        }
          #endregion
        #region BeginTrans
        public override void BeginTrans()
        {
            if (inTransaction) return ;
            trans = conn.BeginTransaction();
            inTransaction = true;
        }
          #endregion
        #region CommitTrans
        public override void CommitTrans()
        {
            trans.Commit();
            inTransaction = false;
        }
         #endregion
        #region RollbackTrans
        public override void RollbackTrans()
        {
            trans.Rollback();
            inTransaction = false;
        }
        #endregion
        #region GetAdapter
        public override DbDataAdapter GetAdapter(string sql)
        {

            SqlDataAdapter da = new SqlDataAdapter(sql, this.conn);
             return da;
        }
        #endregion
        #region GetSelectFirstNum
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
        public override int GetSelectNums(string sql)//获取选择的行数
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
        #region ExecSqlAndReturnID
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
        public override DbDataReader GetReader(string sql)//得到read流并返回
        {
            Open();
            SqlCommand com = new SqlCommand(sql, this.conn);

            SqlDataReader read = com.ExecuteReader();

            return read;

        }
        #endregion


    } 
}
