using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace dbsk5_2018.Models
{
    public class CustomersModel
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public CustomersModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllCustomers()
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable customersTable = ds.Tables["result"];
            dbcon.Close();

            return customersTable;
        }

        public void DeleteCustomer(string custno)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "DELETE FROM CUSTOMER WHERE CUSTNO=@CUSTNO;";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@CUSTNO", custno);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }

    }
}
