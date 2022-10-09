using System;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace dbsk7_2018.Models
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

        public void InsertCustomer(string custno, string ssn, string name)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "INSERT INTO CUSTOMER(CUSTNO,SSN,NAME, REGDATE) VALUES(@CUSTNO,@SSN,@NAME,NOW());";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@CUSTNO", custno);
            sqlCmd.Parameters.AddWithValue("@SSN", ssn);
            sqlCmd.Parameters.AddWithValue("@NAME", name);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }

    }
}
