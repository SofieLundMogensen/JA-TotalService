using MySql.Data.MySqlClient;
using System;


namespace DataAccessLayer
{
    public class Class1
    {

        public void test()
        {
            System.Console.WriteLine("Virker det her?");
            //TODO: Insert string
            string connStr = "Insert string here";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM `Task` WHERE Id = 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   int test = rdr.GetInt32(0);
                    string test2  =rdr.GetString(1);
                   
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
