using System.ComponentModel;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

namespace WebAPI_Saturno.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TelefoneEnum
    {
        [Description("Telefone Fixo")]
        Fixo = 0,

        [Description("Telefone Móvel")]
        Movel = 1,
    }
}
