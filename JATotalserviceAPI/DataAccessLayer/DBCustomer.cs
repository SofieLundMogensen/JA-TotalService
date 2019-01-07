using BusinessLogicLayer;
using ModelLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBCustomer :IDB<Customer>
    {
        string connStr = "server=mysql85.unoeuro.com;user=slund_info;database=slund_info_db_jatotalservice;port=3306;password=14Unicorn01";

        public bool Create(Customer obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            MySqlConnection connection = new MySqlConnection(connStr);
            List<Customer> customerList = new List<Customer>();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM `Customer`";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        houseNumber = reader.GetString(2),
                        road = reader.GetString(3),
                        city = reader.GetString(4),
                        zipcode = reader.GetString(5),
                        mail = reader.GetString(6),
                        phone = reader.GetString(7)
                    };
                    customerList.Add(customer);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            connection.Close();
            return customerList;
        }

        public bool Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
