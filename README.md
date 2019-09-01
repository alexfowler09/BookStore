# BookStore

Projeto de Testes de um CRUD de Livraria

Como não existe uma tela de cadastro de autor, para fins de testes, ao criar o banco de dados alguns autores são adicionados automaticamente

# Funciondalides

* Incluir, Alterar (vinculando a um Autor) e Excluir Livros 
* Não permite cadastrar livros com o mesmo título
* Não permite cadastrar livros com quantidade em estoque negativa
* Listar todos os livros ou somente livros em estoque

# Utilizado no desenvolvimento

Visual Studio 2017
MySQL 8
.NET Core 2.2
Angular 5.2

# Para o backend é necessário realizar os passos abaixo para criar o banco de dados MySql

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