using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Image_Editor
{
    class DatabaseManager
    {
        public SqlDataReader selectRow(SqlConnection connection, string path)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Images WHERE Path = @Path";
                    cmd.Parameters.AddWithValue("@Path", path);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public SqlDataReader selectRecentRows(SqlConnection connection, int numberOfRows)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"SELECT TOP " + numberOfRows + " * FROM Images ORDER BY [Date Opened] DESC;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
