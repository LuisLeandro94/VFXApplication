using System.Text.Json.Serialization;

namespace VFXApplication.Models.ForexRequestModel
{
    public class DailyPricesModel
    {
        public string? Date { get; set; }
        public string? Open { get; set; }
        public string? High { get; set; }
        public string? Low { get; set; }
        public string? Close { get; set; }
    }
}
