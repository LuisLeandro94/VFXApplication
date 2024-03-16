using System.Text.Json;
using VFXFinancial.Models.ForexRequestModel;

namespace VFXFinancial.Services
{
    public class ForexRequestService
    {
        private readonly HttpClientService _httpClientService;

        public ForexRequestService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ForexRequestModel> GetDailyPrices(string fromSymbol, string toSymbol)
        {
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

            var forexRequestModel = JsonSerializer.Deserialize<ForexRequestModel>(content);

            if (forexRequestModel == null)
            {
                throw new Exception("Failed to deserialize response from AlphaVantage API.");
            }

            return forexRequestModel;
        }
    }
}
