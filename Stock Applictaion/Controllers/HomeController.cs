using Microsoft.AspNetCore.Mvc;
using ServiceContract;
using ServiceContract.DTO;

namespace Stock_Applictaion.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWeatherService _weatherService;
        public HomeController(IConfiguration configuration, IWeatherService weatherService)
        {
            _configuration = configuration;
            _weatherService = weatherService;
        } 

        [Route("/")]
        public IActionResult Index()
        {
            Console.WriteLine(_configuration["Symbol"]);
            string? symbol = _configuration["Symbol"];
            if (!string.IsNullOrEmpty(symbol))
            {
                var price = _weatherService.GetStock(symbol).Result;
                var profile = _weatherService.GetCompanyProfile(symbol).Result;
                StockResponse response = new();
                response.Price = price.Price;
                response.StockName = profile.StockName;
                response.StockSymbol = profile.StockSymbol;

                 return View(response);
            }
            return View();
            
        }
    }
}
