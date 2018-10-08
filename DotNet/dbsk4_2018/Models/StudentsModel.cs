using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace dbsk4_2018.Models
{
    public class StudentsModel
    {
        private string connectionString = "Server=localhost;Database=dbskdemo;User ID=ENTER_DB_USER;Password=ENTER_PASSWORD;Pooling=false;SslMode=none;";

        public StudentsModel(string connectionName)
        {
            //connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public DataTable GetAllStudents()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Student;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable studentsTable = ds.Tables["result"];
            dbcon.Close();

            return studentsTable;
        }
    }
}
