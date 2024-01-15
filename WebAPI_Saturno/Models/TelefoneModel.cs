using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebAPI_Saturno.Enums;

namespace WebAPI_Saturno.Models
{
    public class TelefoneModel
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Description("DDD do telefone")]
        public string DDD { get; set; }

        [Description("Número do telefone")]
        public string Numero { get; set; }

        [Description("Tipo do telefone")]
        public TelefoneEnum Tipo { get; set; }

        [JsonIgnore]
        [Description("ID do cliente associado ao telefone")]
        public int ClienteId { get; set; }
        
        [JsonIgnore]
        [Description("Classe de navegação")]
        public ClienteModel? Cliente { get; set; }


    }
}
