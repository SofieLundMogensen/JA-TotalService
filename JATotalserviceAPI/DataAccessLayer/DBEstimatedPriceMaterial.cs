using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBEstimatedPriceMaterial : IDB<EstimatedPrice>
    {

        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public bool Create(EstimatedPrice obj)
        {
            bool succes;
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                connection.Open();

                foreach(var element in obj.materials)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO `EstimatedPriceMaterial`(`MaterialId`, `EstimatedPriceId`, `Amount`) VALUES (?,?,?)";
                    cmd.Parameters.Add("?MaterialId", MySqlDbType.Int32).Value = element.Item1.id;
                    cmd.Parameters.Add("?EstimatedPriceId", MySqlDbType.Int32).Value = obj.Id;
                    cmd.Parameters.Add("?Amount", MySqlDbType.Int32).Value = element.Item2;

                    cmd.ExecuteNonQuery();
                }

                succes = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                succes = false;
            }
            connection.Close();
            return succes;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EstimatedPrice Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<EstimatedPrice> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(EstimatedPrice obj)
        {
            throw new NotImplementedException();
        }
    }
}
