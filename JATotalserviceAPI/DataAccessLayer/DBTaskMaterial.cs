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
                    
                    cmd.Parameters.Add("?MaterialId", MySqlDbType.Int32).Value = element.Item1;
                    cmd.Parameters.Add("?Amount", MySqlDbType.Int32).Value = element.Item2;
                    
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return true;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Task obj)
        {
            throw new NotImplementedException();
        }
    }
}
