using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccess.SouthwindTableAdapters.ProductsTableAdapter tableAdapterTest = new
            DataAccess.SouthwindTableAdapters.ProductsTableAdapter();
            Data.Southwind.ProductsDataTable pdt = tableAdapterTest.GetData(true);
            SqlConnection conn = new SqlConnection("Data Source=WIN-RIA4MG1SAT3;Initial Catalog=Southwind;Integrated Security=SSPI");
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectDiscontinuedItems";
            cmd.Connection = conn;

            SqlParameter param = new SqlParameter("@old", SqlDbType.Bit);
            param.Value = false;
            cmd.Parameters.Add(param);

            SqlDataReader sqlRdr = cmd.ExecuteReader();

            /*while (sqlRdr.Read()) 
            {
                Console.WriteLine("{0} {0}", sqlRdr.GetSqlChars(0), sqlRdr.GetSqlMoney(1));
            }*/

            foreach(DataRow row in pdt.Rows)
            {
                
                Console.WriteLine("{0}, {1}", row[1], row[2]);
            }
            Console.ReadLine();
            sqlRdr.Close();
            conn.Close();
        }
    }
}
