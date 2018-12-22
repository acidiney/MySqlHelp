using MySql.Data.MySqlClient;

namespace ConsoleApplication.DAO
{
    public class MysqlConnectionClass
    {
        // Gosto de deixar claro o construtor mas podes apagar
        private MysqlConnectionClass()
        {
        }

        // Defina as variaveis que você vai precisar

        private const string UserName = "root"; // Essa propriedade é interna do objecto então aconselho a não expor de forma publica
        private const string Pwd = ""; // Essa propriedade é interna do objecto então aconselho a não expor de forma publica

        private static MysqlConnectionClass _instance;

        // Encapsule as variaveis server, databaseName e connection
        public string Server { private get; set; } = string.Empty;

        public string DatabaseName { private get; set; } = string.Empty;

        public MySqlConnection Connection { get; private set; }

        // Esse metodo cria a instacia da conexão (Atenção Deixei o metodo STATIC )
        public static MysqlConnectionClass Instance()
        {
            return _instance ?? (_instance = new MysqlConnectionClass());
        }

        // Este metodo verifica se está conectado... Se não abri a conexão , do contrario só retorna positivo
        public bool IsConnect()
        {
            // A conexão não é nula?
            if (Connection != null) return true;
            // o nome da base de dados está vazia ou nula? Isso é uma guarda, se você quiser poder expor ela num metodo e utiliza-lo aqui
            if (string.IsNullOrEmpty(DatabaseName))
                return false;
                
            // String de conexão
            var connstring = $"Server={Server}; database={DatabaseName}; UID={UserName}; password={Pwd}";
            Connection = new MySqlConnection(connstring);
            Connection.Open();

            return true;
        }

        // Este metodo fecha a conexão
        public void Close()
        {
            Connection.Close();
        }

        // Até aqui? De boa?       
    }

 }
