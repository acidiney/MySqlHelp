using System;
using ConsoleApplication.DAO;
using MySql.Data.MySqlClient;

namespace ConsoleApplication
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // Abrindo instancia da conexão
            var dbConnection = MysqlConnectionClass.Instance();

            // Fornecendo os dados
            dbConnection.Server = "localhost";
            dbConnection.DatabaseName = "Testing";

            if (!dbConnection.IsConnect()) return;
            
            //Supondo que name e email são campos da tabela users na base de dados (VARCHAR)
            const string query = "SELECT name,email FROM users";
            var cmd = new MySqlCommand(query, dbConnection.Connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                var someStringFromName = reader.GetString(0);
                var someStringFromEmail = reader.GetString(1);
                Console.WriteLine(someStringFromName + " - " + someStringFromEmail);
            }
            dbConnection.Close();
        }   
    }
}
