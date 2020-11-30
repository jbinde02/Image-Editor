using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

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

        public void insertUpdateDatabase(SqlConnection connection, String path, Image img)
        {
            try
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandText = @"IF EXISTS(SELECT * FROM Images WHERE Path = @Path)
                                            UPDATE Images SET [Date Opened] = @Date, [Horizontal Resolution] = @HorizontalResolution, [Verticle Resolution] = @VerticleResolution, Width = @Width, Height = @Height, [File Size (MB)] = @FileSize, [Pixel Format] = @PixelFormat WHERE Path = @Path
                                            ELSE
                                            INSERT INTO Images VALUES (@Path, @Date, @HorizontalResolution, @VerticleResolution, @Width, @Height, @FileSize, @PixelFormat);";
                    cmd.Parameters.AddWithValue("@Path", path);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@HorizontalResolution", img.HorizontalResolution);
                    cmd.Parameters.AddWithValue("@VerticleResolution", img.VerticalResolution);
                    cmd.Parameters.AddWithValue("@Width", img.Width);
                    cmd.Parameters.AddWithValue("@Height", img.Height);
                    cmd.Parameters.AddWithValue("@FileSize", new System.IO.FileInfo(path).Length * 0.0000009537); //Bytes to MB || 1 Byte = 0.0000009537 MB
                    cmd.Parameters.AddWithValue("@PixelFormat", img.PixelFormat.ToString());
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
