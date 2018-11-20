using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBEstimatedPrice : IDB<EstimatedPrice>
    {
        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public bool Create(EstimatedPrice obj)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO `EstimatedPrice`(`Id`, `Estimatedtime`) VALUES (?,?)";
                cmd.Parameters.Add("?Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("?Estimatedtime", MySqlDbType.Int32).Value = obj.estimatedTime;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            return true;
        }

        public void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM `EstimatedPrice` WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
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
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `EstimatedPrice` SET `Id`=@Id,`Estimatedtime`=@EstimatedTime WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("@EstimatedTime", MySqlDbType.Int32).Value = obj.estimatedTime;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return true;
        }
    }
}
