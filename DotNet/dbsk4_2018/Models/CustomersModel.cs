using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace dbsk4_2018.Models
{
    public class CustomersModel
    {
        private string connectionString = "Server=localhost;Database=a00leifo;User ID=myusername;Password=mypassword;Pooling=false;SslMode=none;";

        public DataTable GetAllCustomers()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable customerTable = ds.Tables["result"];
            dbcon.Close();

            return customerTable;
        }
    }
}
