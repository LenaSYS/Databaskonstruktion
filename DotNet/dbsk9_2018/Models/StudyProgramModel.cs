using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace dbsk9_2018.Models
{
    public class StudyProgramModel
    {
        private string connectionString = "Server=localhost;Database=a00leifo;User ID=myusername;Password=mypassword;Pooling=false;SslMode=none;";

        public StudyProgramModel()
        {

        }

        public DataTable GetAllStudyPrograms()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM StudyProgram;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable StudyProgramsTable = ds.Tables["result"];
            dbcon.Close();
            return StudyProgramsTable;
        }
    }
}
