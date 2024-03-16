using System.Text.Json.Serialization;

namespace VFXFinancial.Models.ForexRequestModel
{
    public class ForexRequestModel
    {
        [JsonPropertyName("Meta Data")]
        public MetaDataModel? MetaData { get; set; }
        [JsonPropertyName("Time Series FX (Daily)")]
        public Dictionary<string, ForexPriceModel>? DailyPrices { get; set; }
    }
}
