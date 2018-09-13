// Use two namespaces creted
using MysqlHelp.DAO;

namespace MysqlHelp
{
    class Program
    {
        
        public static void Main()
        {
            // Abrindo instancia da conexão
            var dbConnection = DBConnection.Instance();

            // Fornecendo os dados
            dbConnection.Server = "localhost";
            dbConnection.DatabaseName = "Testing";

            if (dbConnection.IsConnect())
            {
                //Supondo que name e email são campos da tabela users na base de dados (VARCHAR)
                string query = "SELECT name,email FROM users";
                var cmd = new MySqlCommand(query, dbConnection.Connection);
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string someStringFromName = reader.GetString(0);
                    string someStringFromEmail = reader.GetString(1);
                    Console.WriteLine(someStringFromName + "," + someStringFromEmail);
                }
                dbConnection.Close();
            }
        }   
    }
}