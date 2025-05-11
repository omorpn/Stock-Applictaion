using Entites;
using Microsoft.Extensions.Primitives;
using ServiceContract.DTO;

namespace ServiceContract
{
    public interface IWeatherService
    {
        Task<StockResponse?> GetStock(string stockSymbol);
        Task<StockProfile> GetCompanyProfile(string companyName);
    }
}
