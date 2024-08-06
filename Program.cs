using System.Data.SqlClient;

namespace TestConnection
{
    public class Program
    {
        public static void Main()
        {
            string connectionString = "Server=192.168.0.75\\SQLEXPRESS;Database=LivroVault;Integrated Security=True;TrustServerCertificate=True;";

            using SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar: " + ex.Message);
            }
        }
    }
}