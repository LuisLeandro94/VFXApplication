using System.Text.Json.Serialization;

namespace VFXApplication.Models.ApiModels
{
    public class ApiMetaDataModel
    {
        [JsonPropertyName("1. Information")]
        public string? Information { get; set; }
        [JsonPropertyName("2. From Symbol")]
        public string? FromSymbol { get; set; }
        [JsonPropertyName("3. To Symbol")]
        public string? ToSymbol { get; set; }
        [JsonPropertyName("4. Output Size")]
        public string? OutputSize { get; set; }
        [JsonPropertyName("5. Last Refreshed")]
        public string? LastRefreshed { get; set; }
        [JsonPropertyName("6. Time Zone")]
        public string? TimeZone { get; set; }
    }
}
