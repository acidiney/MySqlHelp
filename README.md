## Exemplo de conexão do Mysql com C#

E aí?
Criei essa classe para exemplificar de maneira visual como funciona uma conexão do MySQL com o C#.
Essa classe se encontra dentro da pasta  `DAO`.

### Atenção

Essa classe só funcionara se você tiver o driver do `MySQL` , no teu projecto. Neste caso o Driver é o `MySql.Data.dll`, você pode adicionar ele indo em referências e logo depois cliar no browser para procurar por ela.

## Exemplo
O arquivo na raiz `MySqlUsingClass.cs`, é apenas uma ilustração de como isso funcionária.

Na linha `12` do mesmo `var dbConnection = DBConnection.Instance();`. Presta atenção que eu não usei o `new` para criar uma instância da classe, porque o metodo `Instace()` é estatico e é apartir dele que é feita a instancia da classe :-). Após a instancia ser feita o retorno ficará na variavel `dbConnection`, e isso me possibilita controlar quantas instâncias existem, fechar elas e sem dizer que não vou precisar sempre criar uma instância quando uma tarefa for executada.


## Refs

[POST - PROGRAMADORES ANGOLA](https://www.facebook.com/groups/Programadores.Angola/permalink/2284728065096110/)

## Creditos

Acidiney Dias
