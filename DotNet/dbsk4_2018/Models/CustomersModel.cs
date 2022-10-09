using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace dbsk4_2018.Models
{
    public class CustomersModel
    {
        private IConfiguration _configuration;
        private string connectionString;

        public CustomersModel(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionString"];
        }

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
