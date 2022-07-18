using System.Data;
using System.Data.SqlClient;

namespace DeployAzureApp.Controllers
{
    public static class AzureSQLService
    {
        //Azure SQL Server
        static string sqlConnectionString = "";

        // File table creation query
        //CREATE TABLE FilesData (FileName varchar(max),OCRText varchar(max),);

        public static void WriteFileNameAndTextToSQL(string fileName, List<string> fileResult)
        {

            using (SqlConnection openCon = new SqlConnection(sqlConnectionString))
            {
                string saveStaff = "INSERT into FilesData (FileName,OCRText) VALUES (@fileName,@OCRText)";

                using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                {
                    querySaveStaff.Connection = openCon;
                    querySaveStaff.Parameters.Add("@fileName", SqlDbType.VarChar, -1).Value = fileName;
                    querySaveStaff.Parameters.Add("@OCRText", SqlDbType.VarChar, -1).Value = string.Join(",", fileResult);
                    ;
                    openCon.Open();
                    querySaveStaff.ExecuteNonQuery();
                }
            }

        }
    }
}
