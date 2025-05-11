using System.Text.Json;
using Entites;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using ServiceContract;
using ServiceContract.DTO;

namespace Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiKeys _apiKeys; 
        public WeatherService(IHttpClientFactory httpClientFactory,IOptions<ApiKeys> apiKeys)
        {
            _httpClientFactory = httpClientFactory;
            _apiKeys = apiKeys.Value;
        }   
        public async Task<StockResponse> GetStock(string stockSymbol)
        {
            if (string.IsNullOrWhiteSpace(_apiKeys?.FinHubApi))
            {
                throw new InvalidOperationException("FinHubApi key is missing.");
            }
            using (HttpClient http = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_apiKeys.FinHubApi}")
                };
                HttpResponseMessage response = await http.SendAsync(requestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
              await using  var responseStream = await response.Content.ReadAsStreamAsync();
               
               var stock= await JsonSerializer.DeserializeAsync<Stock>(responseStream);
                
                return stock.ToStockResponse()??new StockResponse();


            }
        }
        public async Task<StockResponse> GetCompanyProfile(string companyName)
        {

            using (HttpClient http = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={companyName}&token={_apiKeys.FinHubApi}")
                };

                HttpResponseMessage response = await http.SendAsync(requestMessage);

                // Log status code and response content
                if (!response.IsSuccessStatusCode)
                {
                    // Log status code and content
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}. Content: {errorContent}");
                    throw new Exception($"API request failed with status code: {response.StatusCode}");
                }

                // Log the raw response content for debugging
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response JSON: {jsonResponse}");

                // Deserialize the response if it's not null or empty
                if (string.IsNullOrEmpty(jsonResponse))
                {
                    throw new Exception("Received empty response from API.");
                }

                // Deserialize the response into StockProfile
                var result = JsonSerializer.Deserialize<Stock>(jsonResponse);

                return result.ToStockResponse();
            }

        }
    }
}
