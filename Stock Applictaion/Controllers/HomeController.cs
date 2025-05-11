using Microsoft.AspNetCore.Mvc;
using ServiceContract;

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
            var stock = _weatherService.GetStock(_configuration["Symbol"]).Result;
            var stock2 = _weatherService.GetCompanyProfile(_configuration["Symbol"]).Result;
            ViewBag.Stock = stock;
            ViewBag.Stock2 = stock2.Country;
            return View();
        }
    }
}
