using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbsk6_2018.Models
{
    public class CustomersModel
    {
        private string connectionString = "Server=localhost;Database=a00leifo;User ID=myusername;Password=mypassword;Pooling=false;SslMode=none;";

        public CustomersModel()
        {

        }

        public DataTable GetAllCustomers()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable CustomersTable = ds.Tables["result"];
            dbcon.Close();
            return CustomersTable;
        }
    }
}
