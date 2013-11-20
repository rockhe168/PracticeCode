using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace 模板方法模式_多表查询_
{
    class CategoriesDataAccess:DataAccessObject
    {
        public override void Select()
        {
            var sql = "select CategoryName from Categories";

            var da=new SqlDataAdapter(sql,connectionString);

            dataSet=new DataSet();

            da.Fill(dataSet, "Categories");
        }

        public override void Display()
        {
            Console.WriteLine("Categories ---- ");

            DataTable dataTable = dataSet.Tables["Categories"];

            foreach (DataRow row in dataTable.Rows)
            {

                Console.WriteLine(row["CategoryName"].ToString());

            }

            Console.WriteLine();
        }
    }
}
