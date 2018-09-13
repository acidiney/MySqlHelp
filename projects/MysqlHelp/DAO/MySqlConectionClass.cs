/*
    Primeiro passo use namespace do MySql - Afinal você quer trabalhar com ele, não é mesmo?

*/
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MysqlHelp.DAO
{
    public class DBConnection
    {
        // Gosto de deixar claro o construtor mas podes apagar
        private DBConnection()
        {
        }

        // Defina as variaveis que você vai precisar
        private string server = string.Empty;
        private string databaseName = string.Empty;
        private string userName = "root"; // Essa propriedade é interna do objecto então aconselho a não expor de forma publica
        private string pwd = "";// Essa propriedade é interna do objecto então aconselho a não expor de forma publica

        private MySqlConnection connection = null;
        private static DBConnection _instance = null;

        public string Password { get; set; }

        // Encapsule as variaveis server, databaseName e connection
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public MySqlConnection Connection
        {
            get { return connection; }
        }

        // Esse metodo cria a instacia da conexão (Atenção Deixei o metodo STATIC )
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
           return _instance;
        }

        // Este metodo verifica se está conectado... Se não abri a conexão , do contrario só retorna positivo
        public bool IsConnect()
        {
            // A conexão é nula?
            if (Connection == null)
            {
                // o nome da base de dados está vazia ou nula? Isso é uma guarda, se você quiser poder expor ela num metodo e utiliza-lo aqui
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                
                // String de conexão
                string connstring = string.Format("Server={0}; database={10}; UID={2}; password={3}",server, databaseName, userName, pwd);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        // Este metodo fecha a conexão
        public void Close()
        {
            connection.Close();
        }

        // Até aqui? De boa?       
    }
}