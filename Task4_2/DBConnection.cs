using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace Task4_2
{
    class DBConnection
    {
        ConnectionStringSettings cnStr = ConfigurationManager.ConnectionStrings["cnStr"];
        SqlConnection cn = new SqlConnection();
        public void GetConnection()
        {
            try
            {
                cn.ConnectionString = cnStr.ConnectionString;
                cn.Open();
                Console.WriteLine("Connection established -->{0}", cn.GetType().Name);
            }
            catch (SystemException e)
            {
                Console.WriteLine("Connection error :{0}", e.Message);
            }
        }

        public void SelectQuery(string query)
        {
            DbCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = query;

            var categories = new DataTable();
            using (var dr = cmd.ExecuteReader())
                try
                {
                    {
                        categories.Load(dr);
                    }
                }
                catch(SqlException e)
                {
                    Console.WriteLine("Select error: {0}", e);
                }

            Console.WriteLine("\nData according to the sql-query:{0}:", query);
            foreach (DataRow row in categories.Rows)
            {
                Console.WriteLine("CategoryId: {0}, CategoryName: {1}, Description: {2} ", row["CategoryID"], row["CategoryName"], row["Description"]);
            }
        }

        public void GetDeleteUpdateQuery(string query)
        {
            int numberOfRecords = 0;
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    numberOfRecords = cmd.ExecuteNonQuery();
                }
                catch(SqlException e)
                {
                    Console.WriteLine("Delete/Update error: {0}",e);
                }
            }
            Console.WriteLine("\nThe {0} row(s) has been updated/deleted according to query: {1}", numberOfRecords,query);
        }

        public void CallProcedure(string procName)
        {
            using (SqlCommand cmd = new SqlCommand(procName, cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nResult of working of {0} function/procedure:",procName);
                        while (dr.Read())
                        {
                            Console.WriteLine("Product: {0}, Price: {1}",dr["TenMostExpensiveProducts"],dr["UnitPrice"]);
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Call procedure error: {0}", e);
                }
                }
            }

        public void CloseConnection()
        {
            cn.Close();
            Console.WriteLine("\nConnection Closed!");
        }
    }
   }
    

