namespace VFXApplication.Models.ForexRequestModel
{
    public class ForexModel
    {
        public string? LastRefreshed { get; set; }
        public List<DailyPricesModel>? DailyPrices { get; set; } = new List<DailyPricesModel>();
    }
}
