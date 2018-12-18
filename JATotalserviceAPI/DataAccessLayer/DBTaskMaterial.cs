using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBTaskMaterial : IDB<Task>
    {

        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public bool Create(Task obj)
        {
            bool succes;
            MySqlConnection connection = new MySqlConnection(connStr);
            try
            {
                connection.Open();
                foreach (var element in obj.materials)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "INSERT INTO `TaskMaterial`(`TaskId`, `MaterialId`, `Amount`) VALUES (?,?,?)";
                    cmd.Parameters.Add("?TaskId", MySqlDbType.Int32).Value = obj.id;
                    cmd.Parameters.Add("?MaterialId", MySqlDbType.Int32).Value = element.Item1.id;
                    cmd.Parameters.Add("?Amount", MySqlDbType.Int32).Value = element.Item2;
                    
                    cmd.ExecuteNonQuery();

                }
                succes = true;

            }
            catch (Exception e)
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

        public Task Get(int id)
        {
            throw new NotImplementedException();
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
                cmd.CommandText = "SELECT * FROM `TaskMaterial`";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Task task = new Task();
                    task.id = reader.GetInt32(0);
                    task.materials = new List<Tuple<Material, int>>();

                    Material material = new Material();
                    material.id = reader.GetInt32(1);
                    task.materials.Add(Tuple.Create(material, reader.GetInt32(2)));
                    
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
            throw new NotImplementedException();
        }

        public List<Tuple<Material, int>> GetMaterialTask(int taskid)
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            List<Tuple<Material, int>> tasks = new List<Tuple<Material, int>>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `TaskMaterial` WHERE TaskId = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = taskid;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Task task = new Task();
                    task.id = reader.GetInt32(0);
                    task.materials = new List<Tuple<Material, int>>();

                    Material material = new Material();
                    material.id = reader.GetInt32(1);
                    var tuple = Tuple.Create(material, reader.GetInt32(2));

                    tasks.Add(tuple);
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

    }
}
