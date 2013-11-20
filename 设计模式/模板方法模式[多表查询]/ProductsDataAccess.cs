using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace 模板方法模式_多表查询_
{
    class ProductsDataAccess:DataAccessObject
    {
        public override void Select()
        {
            var sql = "select ProductName from Products";

            var da = new SqlDataAdapter(sql, connectionString);

            dataSet=new DataSet();

            da.Fill(dataSet, "Products");
        }

        public override void Display()
        {
            Console.WriteLine("Products ---- ");

            DataTable dataTable = dataSet.Tables["Products"];

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["ProductName"].ToString());

            }

            Console.WriteLine();
        }
    }
}
