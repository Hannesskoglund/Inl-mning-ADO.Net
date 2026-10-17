using Microsoft.Data.SqlClient;

namespace Inlämning_ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
            "Server=localhost;Database=MoviePlex;" +
            "Trusted_Connection=True;TrustServerCertificate=True;";


           
            using var connection = new SqlConnection(connectionString);

            connection.Open();

            App.Run(connection);
        }
        
    }
}
