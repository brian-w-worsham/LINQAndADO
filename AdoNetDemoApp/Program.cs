using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemoApp
{
    class Program
    {
        static void Main1(string[] args)
        {
            // CreateTable();

            // InsertRecord();

            // DisplayData();

            DeleteRecord();

            DisplayData();
            Console.ReadKey();
        }

        public static void CreateTable()
        {
            SqlConnection con = null;

            try
            {
                // Create a connection
                con = new SqlConnection("Server=SAI-DELL-PC\\SQLEXPRESS;Database=Student;User Id=sa;Password=password123;Encrypt=False;");

                // Write our SQL Query

                SqlCommand cmd = new SqlCommand("CREATE TABLE STUDENT(id int not null, name varchar(50), join_date date)", con);

                // Opening Connection
                con.Open();

                // Execute the query
                cmd.ExecuteNonQuery();

                Console.WriteLine("Table created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        public static void InsertRecord()
        {
            SqlConnection con = null;

            try
            {
                // Create a connection
                con = new SqlConnection("Server=SAI-DELL-PC\\SQLEXPRESS;Database=Student;User Id=sa;Password=password123;Encrypt=False;");

                // Write our SQL Query

                SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES('101', 'Jane Doe', '1/27/2020')", con);

                // Opening Connection
                con.Open();

                // Execute the query
                cmd.ExecuteNonQuery();

                Console.WriteLine("Record created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        public static void DisplayData()
        {
            SqlConnection con = null;

            try
            {
                // Create a connection
                con = new SqlConnection("Server=SAI-DELL-PC\\SQLEXPRESS;Database=Student;User Id=sa;Password=password123;Encrypt=False;");

                // Write our SQL Query

                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);

                // Opening Connection
                con.Open();

                // Execute the query
                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while(sqlDataReader.Read())
                {
                    Console.WriteLine(sqlDataReader["id"] + " " + sqlDataReader["name"] + " " + sqlDataReader["join_date"]);
                }

                Console.WriteLine("Record created successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        public static void DeleteRecord()
        {
            SqlConnection con = null;

            try
            {
                // Create a connection
                con = new SqlConnection("Server=SAI-DELL-PC\\SQLEXPRESS;Database=Student;User Id=sa;Password=password123;Encrypt=False;");

                // Write our SQL Query

                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE id = '101'", con);

                // Opening Connection
                con.Open();

                // Execute the query
                cmd.ExecuteNonQuery();

                Console.WriteLine("Record Deleted successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }
    }
}
