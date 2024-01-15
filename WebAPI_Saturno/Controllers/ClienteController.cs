using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Saturno.Models;
using WebAPI_Saturno.Service.ClienteService;

namespace WebAPI_Saturno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface) 
        {
            _clienteInterface = clienteInterface;
        }


        /// <summary>
        /// Obtém a lista de clientes.
        /// </summary>
        /// <returns>Uma resposta contendo a lista de clientes.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ServiceResponse<List<ClienteModel>>), 200)]
        [Produces("application/json")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> GetClientes()
        {
            return Ok(await _clienteInterface.GetClientes());    
        }

        /// <summary>
        /// Obtém um cliente por ID.
        /// </summary>
        /// <param name="id">O ID do cliente.</param>
        /// <returns>Uma resposta contendo o cliente correspondente ao ID.</returns>
        [HttpGet("{ddd}/{numero}")]
        [ProducesResponseType(typeof(ServiceResponse<ClienteModel>), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<ServiceResponse<ClienteModel>>> GetClienteByTelefone(string ddd, string numero)
        {
            return Ok(await _clienteInterface.GetClienteByTelefone(ddd, numero));
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="novoCliente">Os detalhes do novo cliente.</param>
        /// <returns>Uma resposta contendo a lista atualizada de clientes.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse<List<ClienteModel>>), 200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> CreateCliente(ClienteModel novoCliente)
        {
            return Ok(await _clienteInterface.CreateCliente(novoCliente));
        }

        /// <summary>
        /// Inativa um cliente por ID.
        /// </summary>
        /// <param name="id">O ID do cliente a ser inativado.</param>
        /// <returns>Uma resposta contendo o cliente inativado.</returns>
        [HttpPut("InativarCliente/{id}")]
        [ProducesResponseType(typeof(ServiceResponse<ClienteModel>), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<ServiceResponse<ClienteModel>>> InativaCliente(int id)
        {
            return Ok(await _clienteInterface.InativaCliente(id));
        }


        /// <summary>
        /// Atualiza as informações de um cliente.
        /// </summary>
        /// <param name="editadoCliente">Os detalhes do cliente editado.</param>
        /// <returns>Uma resposta contendo o cliente atualizado.</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ServiceResponse<ClienteModel>), 200)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public async Task<ActionResult<ServiceResponse<ClienteModel>>> UpdateCliente(ClienteModel editadoCliente)
        {           
            return Ok(await _clienteInterface.UpdateCliente(editadoCliente));
        }


        /// <summary>
        /// Exclui um cliente por Email.
        /// </summary>
        /// <param name="email">O Email do cliente a ser excluído.</param>
        /// <returns>Uma resposta contendo a lista atualizada de clientes após a exclusão.</returns>
        [HttpDelete("{email}")]
        [ProducesResponseType(typeof(ServiceResponse<List<ClienteModel>>), 200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> DeleteCliente(string email)
        {
            return Ok(await _clienteInterface.DeleteCliente(email));
        }


    }
}
