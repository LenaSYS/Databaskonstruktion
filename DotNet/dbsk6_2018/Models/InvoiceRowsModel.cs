using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbsk6_2018.Models
{
    public class InvoiceRowsModel
    {
        private string connectionString = "Server=localhost;Port=3308;Database=a00leifo;User ID=sqllab;Password=Hare#2022;Pooling=false;SslMode=none;convert zero datetime=True;";

        public InvoiceRowsModel()
        {

        }

        public DataTable SearchInvoiceRows(string custno)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
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
