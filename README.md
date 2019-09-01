# BookStore

Projeto de Testes

# Para o backend é necessário realizar os passos abaixo para criar o banco de dados SqlServer

No Visual Studio:
* Dentro do projeto BookStore.Api, no appsettings.json alterar a BookStoreConnectionString;
* Setar BookStore.Api como StartUp Project e no Package Manager Console rodar o comando Update-Database

# Para o frontend é necessário realiazar os passos abaixo para instalar as dependencias

Em um terminal:
* Acessar a pasta BookStore.UI e rodar o comando "npm install"	

# Para inicializar o projeto

* Inicializar o backend no Visual Studio, deverá subir na porta 64861
* Acessar a pasta BookStore.UI no terminal e rodar o comando "ng serve"

## TODO List

* Implementar async no codigo
* Microservico de Login
* Adicionar Jwt
* Connection string em variavel de ambiente
* Exception Middleware
* Virtual delete
* Ajustar testes
* Ajustar Rotas
* Reescrever frontend