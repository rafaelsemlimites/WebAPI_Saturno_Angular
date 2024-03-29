![image](https://github.com/rafaelsemlimites/WebAPI_Saturno_Angular/assets/7587999/caac9b60-1367-44e5-9d40-92bc5e57bf0d)


Nome do projeto: Saturno

Versão: 1.0.0

Descrição: Este projeto é um serviço de gerenciamento de clientes. Ele fornece APIs para criar, ler, atualizar e excluir clientes.

Requisitos:

.NET 6
Entity Framework Core 6
SQL Server
Instalação:

Clone o repositório do GitHub.
Abra o projeto no Visual Studio.
Instale as dependências do projeto.
Configure o banco de dados.
Configurando o banco de dados:

Crie um banco de dados SQL Server.
Altere o valor da propriedade ConnectionString na classe ApplicationDbContext para apontar para o seu banco de dados.
Execute o script DatabaseInitializer.cs para criar as tabelas do banco de dados.
Uso:

Para usar o serviço de clientes, você pode usar as seguintes APIs:

CreateCliente(): cria um novo cliente.
GetClientes(): recupera uma lista de clientes.
GetClienteByTelefone(): recupera um cliente específico.
UpdateCliente(): atualiza um cliente existente.
DeleteCliente(): exclui um cliente.
Exemplos:

C#
// Criar um novo cliente
var cliente = new Cliente
{
    Nome = "Cliente 1",
    Email = "cliente1@gmail.com",
};

clienteService = new ClienteService(cliente);

// Recuperar uma lista de clientes
var clientes = clienteService.GetClientes().Result

// Recuperar um cliente específico
var cliente = clienteService.GetClienteByTelefone(ddd, telefone);


Use o código com cuidado. Saiba mais
Testes:

O projeto inclui testes unitários para garantir a qualidade do código. Para executar os testes, execute o comando dotnet test no diretório do projeto.

Licenciamento:

Este projeto é licenciado sob a licença MIT.

Contribuições:

Contribuições são bem-vindas. Para contribuir com o projeto, crie uma nova issue ou envie uma pull request.

Contato:

Para mais informações, entre em contato com o autor do projeto.
