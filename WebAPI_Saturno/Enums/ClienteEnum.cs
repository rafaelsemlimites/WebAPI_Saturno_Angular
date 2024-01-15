using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WebAPI_Saturno.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClienteEnum
    {
        [Description("Cliente Ouro")]
        Ouro = 0,

        [Description("Cliente Prata")]
        Prata = 1,

        [Description("Cliente Bronze")]
        Bronze = 2,
    }
}
