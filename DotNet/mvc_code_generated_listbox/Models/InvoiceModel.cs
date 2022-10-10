using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace mvc_code_generated_listbox.Models
{
    public class InvoiceModel
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public InvoiceModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable SearchInvoiceRows(string custno)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM INVOICEROW WHERE CUSTNO=@CUSTNO;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@CUSTNO", custno);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable InvoiceRowsTable = ds.Tables["result"];
            dbcon.Close();
            return InvoiceRowsTable;
        }
    }
}
