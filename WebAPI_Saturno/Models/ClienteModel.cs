using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebAPI_Saturno.Enums;

namespace WebAPI_Saturno.Models
{
    public class ClienteModel
    {
        [Key]
        [Description("Id do cliente gerado pelo Banco de Dados")]
        public int Id { get; set; }

        [Description("Nome do cliente")]
        public string Nome { get; set; }

        [Description("Endereço de e-mail do cliente")]
        public string Email { get; set; }

        [Description("Lista de telefones associados ao cliente")]
        public List<TelefoneModel> Telefones { get; set; } = new List<TelefoneModel>();

        [Description("Tipo do cliente")]
        public ClienteEnum TipoCliente { get; set; }

        [Description("Indica se o cliente está ativo")]
        public bool Ativo { get; set; }
        
        [JsonIgnore]
        [Description("Data de criação do cliente")]
        public DateTime DataDeCriacao { get; set;} = DateTime.Now.ToLocalTime();

        [Description("Data de alteração do cliente")]
        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();


    }



}
