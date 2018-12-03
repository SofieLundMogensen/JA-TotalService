using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{

    public class DBMaterial :IDB<Material>
    {

        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public bool Create(Material obj)
        {
            bool succes = false;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO `Material`(`Name`, `Price`, `Description`) VALUES (?,?,?)";
                //cmd.Parameters.Add("?Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("?Name", MySqlDbType.String).Value = obj.name;
                cmd.Parameters.Add("?Price", MySqlDbType.Double).Value = obj.price;
                cmd.Parameters.Add("?Description", MySqlDbType.String).Value = obj.description;
                cmd.ExecuteNonQuery();
                succes = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            return succes;
        }

        public bool Delete(int id)
        {
            bool succes = false;
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM `Material` WHERE Id = @Id";
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

        public Material Get(int id)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            Material material = new Material();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `Material` WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    material.id = reader.GetInt32(0);
                    material.name = reader.GetString(1);
                    material.price = reader.GetFloat(2);
                    material.description = reader.GetString(3);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return material;
        }

        public List<Material> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            List<Material> materials = new List<Material>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `Material`";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material material = new Material();
                    material.id = reader.GetInt32(0);
                    material.name = reader.GetString(1);
                    material.price = reader.GetFloat(2);
                    material.description = reader.GetString(3);
                    materials.Add(material);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return materials;
        }

        public bool Update(Material obj)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            bool succes = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
               
                cmd.CommandText = " UPDATE `Material` SET `Id`=@Id,`Name`=@Name,`Price`=@Price,`Description`=@Description WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = obj.id;
                cmd.Parameters.Add("@Name", MySqlDbType.String).Value = obj.name;
                cmd.Parameters.Add("@Price", MySqlDbType.Double).Value = obj.price;
                cmd.Parameters.Add("@Description", MySqlDbType.String).Value = obj.description;
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
    }
}
