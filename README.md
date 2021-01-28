# Registros do Zoológico

API de um Zoológico que abriga gorilas, leões e cobras e apenas dá a seus animais nomes que iniciam com a letra J.

Mantém para todos os animais os registros:

-   nome,
-   sexo,
-   idade,
-   peso,
-   tipo de alimentação

Para as cobras, adicionalmente registra-se a espécie e há um campo que indica se a cobra é peçonhenta ou não. Para os leões há um adicional de tom da pelagem.

Na pasta  **InsertJson**  há exemplos das estruturas que devem ser enviadas no corpo das requisições POST para inserir os animais que habitam o zoológico.


## MongoDB

Para que a API funcione, é necessário fazer um cadastro em [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) e criar gratuitamente - *a depender do serviço* - um *Cluster*.

Para conectar a aplicação, é necessário criar um usuario em **DataBase Access** com senha, os privilégios tem de ser de leitura e escrita. 

Em seguida, clicar em **Connect** e **Connect your application** . Selecionar C#.NET como Driver, e selecionar a versão correspondente. Guardar a Connection String criada.

Buscar por Collections e criar um novo banco em **+ Create Database**.


Com a Connection String e o banco criados, criar um arquivo chamado *appsettings.json* na raiz do projeto:


     {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*",
      "ConnectionString": "<connection string gerada>",
      "NomeBanco": "<nome collection>"
    }


Iniciar a API com o comando

    $ dotnet run


# Documentação API Rest

Com a aplicação rodando, faça a requisição para http://localhost:5000.

Utilize /*(animal)* a depender do animal desejado.
As opções para *(animal)* são [cobra, leao, gorila]

Com a API é possível:
 - Inserir novos animais de uma determinada espécie utilizando **POST** ;
 - Buscar todos os animais de uma determinada espécie utilizando **GET**;
 - Editar o peso de um animal, ao filtrar pelo seu nome, utilizando **PUT**;
 - Excluir o registro de um animal, filtrando pelo seu nome, utilizando **DELETE**


**IMPORTANTE: as informações sempre devem estar no corpo da requisição.**
