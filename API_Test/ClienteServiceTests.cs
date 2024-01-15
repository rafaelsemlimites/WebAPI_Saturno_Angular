
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI_Saturno.Models;
using WebAPI_Saturno.DataContext;
using WebAPI_Saturno.Enums;
using WebAPI_Saturno.Service.ClienteService;

namespace API_Test
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
                var cliente1 = resultado.Dados.First(c => c.Nome == "Cliente 1");
                Assert.AreEqual("Cliente 1", cliente1.Nome);
                Assert.AreEqual("cliente1@gmail.com", cliente1.Email);
                Assert.AreEqual(2, cliente1.Telefones.Count);
                Assert.AreEqual("11", cliente1.Telefones.First().DDD);
                Assert.AreEqual("111111111111", cliente1.Telefones.First().Numero);
                Assert.AreEqual(TelefoneEnum.Movel, cliente1.Telefones.First().Tipo);

                var cliente2 = resultado.Dados.First(c => c.Nome == "Cliente 2");
                Assert.AreEqual("Cliente 2", cliente2.Nome);
                Assert.AreEqual("cliente2@gmail.com", cliente2.Email);
                Assert.AreEqual(2, cliente2.Telefones.Count);
                Assert.AreEqual("33", cliente2.Telefones.First().DDD);
                Assert.AreEqual("33333333333333", cliente2.Telefones.First().Numero);
                Assert.AreEqual(TelefoneEnum.Movel, cliente2.Telefones.First().Tipo);



                // Realizar asserções
                Assert.IsNotNull(resultado.Dados);
                Assert.IsTrue(resultado.Dados.Count > 0);
                Assert.IsTrue(resultado.Sucesso);
                

            }
        }


    }
}