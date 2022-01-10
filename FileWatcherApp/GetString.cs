using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FileWatcherApp
{
   public class GetString
    {
            string connString = "Data Source = .; Initial Catalog =GymFamily ;Integrated Security=true;";

        public void SqlConnection()
        {
            Console.WriteLine("Getting Connection ...");
            SqlConnection conn = new(connString);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();
        }
    }
}
