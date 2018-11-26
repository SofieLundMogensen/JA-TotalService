using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBTimeRegistration : IDB<TimeRegistartion>
    {
        static string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";
        MySqlConnection connection = new MySqlConnection(connStr);

        public bool Create(TimeRegistartion obj)
        {
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `TimeRegistration`(`EndTime`, `TaskId`, `StartTime`, `EmployeeId`) VALUES(?,?,?,?)";
                //cmd.Parameters.Add("?Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("?EndTime", MySqlDbType.DateTime).Value = obj.endTime;
                cmd.Parameters.Add("?TaskId", MySqlDbType.Int32).Value = obj.task.id;
                cmd.Parameters.Add("?StartTime", MySqlDbType.DateTime).Value = obj.startTime;
                cmd.Parameters.Add("?EmployeeId", MySqlDbType.Int32).Value = obj.employee.Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return true;
        }

        public void Delete(int id)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM `TimeRegistration` WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        public TimeRegistartion Get(int id)
        {
            TimeRegistartion timeRegistartion = new TimeRegistartion();
            try
            {
                connection.Open();
                string sql = "SELECT * FROM `TimeRegistration` WHERE Id = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                timeRegistartion.employee = new Employee();
                timeRegistartion.task = new Task();
                while (rdr.Read())
                {
                    timeRegistartion.Id = rdr.GetInt32(0);
                    timeRegistartion.endTime = rdr.GetDateTime(1);
                    timeRegistartion.task.id = rdr.GetInt32(2);
                    timeRegistartion.startTime = rdr.GetDateTime(3);
                    timeRegistartion.employee.Id = rdr.GetInt32(4);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return timeRegistartion;
        }

        public List<TimeRegistartion> GetAll()
        {
            List<TimeRegistartion> timelist = new List<TimeRegistartion>();
            try
            {
                connection.Open();
                string sql = "SELECT * FROM `TimeRegistration`";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TimeRegistartion timeRegistartion = new TimeRegistartion();
                    timeRegistartion.employee = new Employee();
                    timeRegistartion.task = new Task();
                    timeRegistartion.Id = rdr.GetInt32(0);
                    timeRegistartion.endTime = rdr.GetDateTime(1);
                    timeRegistartion.task.id = rdr.GetInt32(2);
                    timeRegistartion.startTime = rdr.GetDateTime(3);
                    timeRegistartion.employee.Id = rdr.GetInt32(4);
                    timelist.Add(timeRegistartion);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return timelist;
        }

        public bool Update(TimeRegistartion obj)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `TimeRegistration` SET `Id`=@Id,`EndTime`=@EndTime,`TaskId`=@TaskId,`StartTime`=@StartTime,`EmployeeId`=@EmployeeId WHERE Id = @Id";
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = obj.Id;
                cmd.Parameters.Add("@EndTime", MySqlDbType.DateTime).Value = obj.endTime;
                cmd.Parameters.Add("@TaskId", MySqlDbType.Int32).Value = obj.task.id;
                cmd.Parameters.Add("@StartTime", MySqlDbType.DateTime).Value = obj.startTime;
                cmd.Parameters.Add("@EmployeeId", MySqlDbType.Int32).Value = obj.employee.Id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return true;
        }
    }
}
