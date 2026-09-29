using System.Data;
using MySql.Data.MySqlClient;

namespace mvc_connect_model_to_mysql.Models
{
    public class CustomersModel
    {
        private IConfiguration _configuration;
        private string connectionString;

        public CustomersModel(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = "Server=localhost;Port=3308;Database=a00leifo;User ID=dbkonstruktion;Password=Bontebok#26;Pooling=false;SslMode=Required;convert zero datetime=True;";
        }

        public DataTable GetAllInvoices()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM INVOICEROW ORDER BY INVOICENO;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable invoiceTable = ds.Tables["result"];
            dbcon.Close();

            return invoiceTable;
        }
    }
}
