using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class DataAdapterDemo
    {
        static void Main1(string[] args)
        {
            try
            {
                string connString = "Server=SAI-DELL-PC\\SQLEXPRESS;Database=StudentDB;User Id=sa;Password=password123;Encrypt=False;";

                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM student", connection);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    // 1. Open the connection
                    // 2. Execute the command
                    // 3. Retrieve the results
                    // 4. Fill/Store the result into the DT
                    // 5 Close the connection

                    Console.WriteLine("Using Data Table");

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["Name"] + " " + row["Email"]);
                    }

                    DataSet ds = new DataSet();
                    da.Fill(ds, "student");

                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Using Data Set");

                    foreach (DataRow row in ds.Tables["student"].Rows)
                    {
                        Console.WriteLine(row["Name"] + " " + row["Email"]);
                    }

                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Using Stored Procedure");

                    da = new SqlDataAdapter("spGetStudents", connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["Name"] + " " + row["Email"]);
                    }

                }

                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
