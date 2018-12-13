using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public class DBTask : IDB<Task>

    {
        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public bool Create(Task obj)
        {
            bool succes = false;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
              
                cmd.CommandText = "INSERT INTO `Task`(`Name`,`Description`,`isComplete`) VALUES (?,?,?)";

                cmd.Parameters.Add("?Name", MySqlDbType.String).Value = obj.name;
                cmd.Parameters.Add("?Description", MySqlDbType.String).Value = obj.description;
                //Konventere bit om til en boolean
                cmd.Parameters.Add("@isComplete", MySqlDbType.Bit);
                var booleanValue = Convert.ToBoolean(cmd.Parameters["@isComplete"].Value);
                cmd.Parameters["@isComplete"].Value = booleanValue;

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
                    cmd.CommandText = "DELETE FROM `Task` WHERE Id = @Id";
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

        public Task Get(int id)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            Task task = new Task();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `Task` WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    task.id = reader.GetInt32(0);
                    task.name = reader.GetString(1);
                    task.description = reader.GetString(2);
                    task.isComplete = reader.GetBoolean(3);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return task;
        }

        public List<Task> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            List<Task> tasks = new List<Task>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `Task`";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Task task = new Task();
                    task.id = reader.GetInt32(0);
                    task.name = reader.GetString(1);
                    task.description = reader.GetString(2);
                    task.isComplete = reader.GetBoolean(3);
                  
                   
                    tasks.Add(task);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return tasks;
        }

        public bool Update(Task obj)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            bool succes = false;
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = " UPDATE `Task` SET `Id`=@Id,`Name`=@Name,`isComplete`=@isComplete,`Description`=@Description WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = obj.id;
                cmd.Parameters.Add("@Name", MySqlDbType.String).Value = obj.name;
                cmd.Parameters.Add("@isComplete", MySqlDbType.Bit).Value = obj.isComplete;
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
