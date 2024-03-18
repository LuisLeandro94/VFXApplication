using System.Text.Json.Serialization;

namespace VFXApplication.Models.ApiModels
{
    public class ApiForexRequestModel
    {
        [JsonPropertyName("Meta Data")]
        public ApiMetaDataModel? MetaData { get; set; }
        [JsonPropertyName("Time Series FX (Daily)")]
        public Dictionary<string, ApiForexPriceModel>? DailyPrices { get; set; }
    }
}
