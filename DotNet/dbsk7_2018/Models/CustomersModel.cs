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

        public DataTable SearchCustomers(string name)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM CUSTOMER WHERE name LIKE @NAME;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@NAME", "%" + name + "%");
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable CustomersTable = ds.Tables["result"];
            dbcon.Close();
            return CustomersTable;
        }
    }
}


/*
 *
 *

       public DataTable SearchStudents(string name, string studyProgram)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Student WHERE name LIKE @NAME AND studyProgram=@SPROGRAM;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@NAME", "%" + name + "%");
            adapter.SelectCommand.Parameters.AddWithValue("@SPROGRAM", studyProgram);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable StudentsTable = ds.Tables["result"];
            dbcon.Close();
            return StudentsTable;
        }
    }

 * 
 */
