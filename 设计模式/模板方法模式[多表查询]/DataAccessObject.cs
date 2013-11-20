using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace 模板方法模式_多表查询_
{
    /// <summary>
    /// 数据抽象超类，定义相关流程
    /// </summary>
    public abstract class DataAccessObject
    {

        protected string connectionString;

        protected DataSet dataSet;

        /// <summary>
        /// 定义链接
        /// </summary>
        public virtual void Connect()
        {
            connectionString = "server=.;database=northwind;integrated security=sspi;";
        }

        public abstract void Select();

        public abstract void Display();

        public virtual void Disconnect()
        {
            connectionString = "";
        }

        public void Run()
        {
            Connect();
            Select();
            Display();
            Disconnect();
        }

    }
}
