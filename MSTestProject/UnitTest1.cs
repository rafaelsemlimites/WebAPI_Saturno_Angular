using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_Saturno.Models;
using WebAPI_Saturno.DataContext;
using WebAPI_Saturno.Enums;
using WebAPI_Saturno.Service.ClienteService;


namespace MSTestProject
{
    [TestClass]
    public class ClienteServiceTests
    {

        [TestMethod]
        public void GetClientes_DeveRetornarClientes()
        {
            // Configurar um contexto de teste ou usar um banco de dados em memória
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Criar um contexto de banco de dados usando o contexto de teste
            using (var dbContext = new ApplicationDbContext(options))
            {
                // Adicionar dados de teste ao contexto
                dbContext.Clientes.Add(new ClienteModel
                {
                    Nome = "Cliente 1",
                    Email = "cliente1@gmail.com",
                    Telefones = new List<TelefoneModel>
                        {
                            new TelefoneModel
                            {
                                DDD = "11",
                                Numero = "111111111111",
                                Tipo = TelefoneEnum.Movel
                            },
                            new TelefoneModel
                            {
                                DDD = "22",
                                Numero = "2222222222",
                                Tipo = TelefoneEnum.Fixo
                            }
                        },
                    TipoCliente = ClienteEnum.Ouro,
                    Ativo = true,
                    DataDeAlteracao = DateTime.Now.ToLocalTime()

                });



                dbContext.Clientes.Add(new ClienteModel
                {
                    Nome = "Cliente 2",
                    Email = "cliente2@gmail.com",
                    Telefones = new List<TelefoneModel>
                        {
                            new TelefoneModel
                            {
                                DDD = "33",
                                Numero = "33333333333333",
                                Tipo = TelefoneEnum.Movel
                            },
                            new TelefoneModel
                            {
                                DDD = "44",
                                Numero = "4444444444444",
                                Tipo = TelefoneEnum.Movel
                            }
                        },
                    TipoCliente = ClienteEnum.Prata,
                    Ativo = true,
                    DataDeAlteracao = DateTime.Now.ToLocalTime()

                });



                dbContext.SaveChanges();

                // Criar uma instância do serviço, passando o contexto de teste               
                var clienteService = new ClienteService(dbContext);

                // Chamar o método que para testar
                var resultado = clienteService.GetClientes().Result;


                // Validar os dados dos clientes
                Assert.AreEqual(2, resultado.Dados.Count);
                Assert.AreEqual("Cliente 1", resultado.Dados.First().Nome);
                Assert.AreEqual("Cliente 2", resultado.Dados.Last().Nome);


                // Realizar asserções
                Assert.IsNotNull(resultado.Dados);
                Assert.IsTrue(resultado.Dados.Count > 0);
                Assert.IsTrue(resultado.Sucesso);
                Assert.IsNull(resultado.Mensagem);

            }
        }



        [TestMethod]
        public void GetClientes_SemClientes_DeveRetornarMensagem()
        {
            // Configurar um contexto de teste ou usar um banco de dados em memória
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Criar um contexto de banco de dados usando o contexto de teste
            using (var dbContext = new ApplicationDbContext(options))
            {
                // Criar uma instância do serviço, passando o contexto de teste               
                var clienteService = new ClienteService(dbContext);

                // Chamar o método que você deseja testar
                var resultado = clienteService.GetClientes().Result;

                // Realizar asserções
                Assert.IsNull(resultado.Dados);
                Assert.IsFalse(resultado.Sucesso);
                Assert.AreEqual("Nenhum dado encontrado!", resultado.Mensagem);
            }
        }
    }
}