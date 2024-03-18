using System.Text.Json;
using VFXApplication.Models.ApiModels;
using VFXApplication.Models.ForexRequestModel;

namespace VFXFinancial.Services
{
    public interface IForexRequestService
    {
        Task<ForexModel> GetDailyPrices(string fromSymbol, string toSymbol);
    }
    public class ForexRequestService : IForexRequestService
    {
        private readonly HttpClientService _httpClientService;

        public ForexRequestService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ForexModel> GetDailyPrices(string fromSymbol, string toSymbol)
        {
            ForexModel finalResult = new();
            var queryParameters = new Dictionary<string, string>
            {
                {"function", "FX_DAILY" },
                {"from_symbol", fromSymbol },
                {"to_symbol", toSymbol },
                {"apikey", "2Z6ULSTQ7WESLB5C" },
            };

            var queryString = string.Join("&", queryParameters.Select(x => $"{x.Key}={x.Value}"));

            var url = $"https://www.alphavantage.co/query?{queryString}";
            var content = await _httpClientService.GetAsync(url);

            if (content == null)
            {
                throw new Exception("Failed to retrieve data from AlphaVantage API.");
            }

            var forexRequestModel = JsonSerializer.Deserialize<ApiForexRequestModel>(content);

            if (forexRequestModel == null)
            {
                throw new Exception("Failed to deserialize response from AlphaVantage API.");
            }

            finalResult.LastRefreshed = forexRequestModel?.MetaData?.LastRefreshed;

            foreach(var item in forexRequestModel.DailyPrices)
            {
                DailyPricesModel forexListModel = new DailyPricesModel()
                {
                    Close = item.Value.Close,
                    High = item.Value.High,
                    Low = item.Value.Low,
                    Open = item.Value.Open,
                    Date = item.Key
                };

                finalResult?.DailyPrices?.Add(forexListModel);
            }

            return finalResult;
        }
    }
}
