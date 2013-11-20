using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace Zys.DBO
{
    public class OleDBOperator : DBOperator
    {
        private OleDbConnection conn;
        private OleDbTransaction trans;
        private bool inTransaction = false;
        public OleDBOperator(string strConnection)
        {
            this.conn = new OleDbConnection(strConnection);
        }
        public override IDbConnection Connection
        {
            get { return this.conn; }

        }
        public override void Open()
        {
            if (conn.State.ToString().ToUpper() != "OPEN")
                this.conn.Open();
        }
        public override void Close()
        {
            if (conn.State.ToString().ToUpper() == "OPEN")
                this.conn.Close();
        }
        public override void BeginTrans()
        {
            trans = conn.BeginTransaction();
            inTransaction = true;
        }
        public override void CommitTrans()
        {
            trans.Commit();
            inTransaction = false;
        }
        public override void RollbackTrans()
        {
            trans.Rollback();
            inTransaction = false;
        }

        public override int GetSelectFirstNum(string sql)
        {
            throw new NotImplementedException();
        }


        public override DbDataAdapter GetAdapter(string sql)
        {

            OleDbDataAdapter da = new OleDbDataAdapter(sql,this.conn);
            return da;

        }

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
        public override bool ExecuteUpdate(string strSql)
        {
            Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = this.conn;
            if (inTransaction)
                cmd.Transaction = trans;
            cmd.CommandText = strSql;
            cmd.CommandType = CommandType.Text;
            bool ret =  cmd.ExecuteNonQuery() > 0;
            Close();
            return ret;
        }
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
        #region ExecSqlAndReturnID
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
                int ret =  int.Parse(cmd.ExecuteScalar().ToString());
                Close();
                return ret;
            }
            Close();
            return 0;
        }
        #endregion
        #region GetReader
        public override DbDataReader GetReader(string sql)
        {
            throw new NotImplementedException();
        }
        #endregion
    } 
}
