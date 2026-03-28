using System;
using System.Data;
using System.Data.SqlClient;

namespace MakineYonetimSistemi // Proje adın farklıysa burayı düzelt
{
    public class SqlHelper
    {
        // BAĞLANTI CÜMLESİ
        // Eğer SQL Server ismin farklıysa (örneğin SQLEXPRESS) "Data Source=." kısmını "Data Source=.\\SQLEXPRESS" yapman gerekebilir.
        // "localhost\SQLEXPRESS" yazarken araya çift slaş koyuyoruz:
        private static string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=FabriTrack;Integrated Security=True";

        // Bağlantı Döndüren Metot
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Veri Çekme (SELECT işlemleri için)
        public static DataTable GetTable(string query)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Veri çekme hatası: " + ex.Message);
                    }
                }
            }
        }

        // Veri İşleme (INSERT, UPDATE, DELETE işlemleri için)
        public static void ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection con = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}