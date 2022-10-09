using System;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dbsk9_2018.Models
{
    public class CustomerModel
    {
        private ILogger _logger;
        private IConfiguration _configuration;
        private string connectionString; 

        public CustomerModel(ILogger<CustomerModel> logger,IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _logger.LogInformation("====> CustomersModel {dateTime}", DateTime.UtcNow);

            connectionString = _configuration["ConnectionString"];
            _logger.LogInformation("====> ConnectionString {ConnectionString}", connectionString);
        }

        public DataTable GetAllCustomers()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable CustomerTable = ds.Tables["result"];
            dbcon.Close();
            return CustomerTable;
        }
    }
}
