using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace TestConnection
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine($"Versão do .NET: {RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"Sistema Operacional: {Environment.OSVersion}");
            Console.WriteLine($"Nome da Máquina: {Environment.MachineName}");
            Console.WriteLine($"Usuário Atual: {Environment.UserName}");

            string connectionString = "Server=192.168.0.75\\SQLEXPRESS;Database=LivroVault;Integrated Security=True;TrustServerCertificate=True;";

            using SqlConnection connection = new(connectionString);

            int numeroTentativas = 0;
            while (numeroTentativas < 3)
            {
                try
                {
                    numeroTentativas++;
                    Console.WriteLine($"Tentativa {numeroTentativas} de conexão...");

                    Console.WriteLine($"Estado da conexão antes de abrir: {connection.State}");

                    connection.Open();

                    Console.WriteLine("Conexão bem-sucedida!");
                    break;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Erro de SQL na tentativa {numeroTentativas}: {ex.Message}");
                    Console.WriteLine($"Código do Erro: {ex.Number}");
                    Console.WriteLine($"Fonte do Erro: {ex.Source}");
                    Console.WriteLine($"Detalhes do erro: {ex.StackTrace}");

                    foreach (SqlError error in ex.Errors)
                    {
                        Console.WriteLine($"Erro de SQL: {error.Number} - {error.Message}");
                        Console.WriteLine($"Linha: {error.LineNumber}, Procedimento: {error.Procedure}");
                    }

                    if (numeroTentativas == 3)
                    {
                        Console.WriteLine("Falha após 3 tentativas. Abortando...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado na tentativa {numeroTentativas}: {ex.Message}");
                    Console.WriteLine($"Detalhes do erro: {ex.StackTrace}");

                    if (numeroTentativas == 3)
                    {
                        Console.WriteLine("Falha após 3 tentativas. Abortando...");
                    }
                }
            }
        }
    }
}