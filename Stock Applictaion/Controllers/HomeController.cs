using Microsoft.AspNetCore.Mvc;

namespace Stock_Applictaion.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
