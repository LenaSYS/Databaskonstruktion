using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbsk6_2018.Models
{
    public class StudentsModel
    {
        private string connectionString = "Server=localhost;Database=dbskdemo;User ID=ENTER_DB_USER;Password=ENTER_DB_USER_PWD;Pooling=false;";

        public StudentsModel()
        {

        }

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
}
