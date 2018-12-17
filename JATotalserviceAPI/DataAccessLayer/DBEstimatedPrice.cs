using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBEstimatedPrice
    {
        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public int Create(EstimatedPrice obj)
        {
            
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO `EstimatedPrice`(`Estimatedtime`, `Name`) VALUES (?, ?);" + "SELECT last_insert_id();";
                //cmd.Parameters.Add("?Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("?Estimatedtime", MySqlDbType.Int32).Value = obj.estimatedTime;
                cmd.Parameters.Add("?Name", MySqlDbType.VarChar).Value = obj.Name;
                //cmd.ExecuteNonQuery();

                return Convert.ToInt32(cmd.ExecuteScalar());
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();

            return -1;
        }

        public bool Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            bool succes = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM `EstimatedPrice` WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
                succes = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return succes;
        }

        public EstimatedPrice Get(int id)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            EstimatedPrice estimatedPrice = new EstimatedPrice();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `EstimatedPrice` WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    estimatedPrice.Id = reader.GetInt32(0);
                    estimatedPrice.estimatedTime = reader.GetInt32(1);
                    estimatedPrice.materials = null;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return estimatedPrice;
        }

        public List<EstimatedPrice> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            List<EstimatedPrice> estimatedPriceList = new List<EstimatedPrice>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `EstimatedPrice`";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EstimatedPrice estimatedPrice = new EstimatedPrice();
                    estimatedPrice.Id = reader.GetInt32(0);
                    estimatedPrice.estimatedTime = reader.GetInt32(1);
                    estimatedPrice.materials = null;
                    estimatedPriceList.Add(estimatedPrice);
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return estimatedPriceList;
        }

        public bool Update(EstimatedPrice obj)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            bool succes = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `EstimatedPrice` SET `Id`=@Id,`Estimatedtime`=@EstimatedTime WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("@EstimatedTime", MySqlDbType.Int32).Value = obj.estimatedTime;

                cmd.ExecuteNonQuery();
                succes = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return false;
        }
    }
}
