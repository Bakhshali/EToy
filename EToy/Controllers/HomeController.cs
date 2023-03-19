using Microsoft.AspNetCore.Mvc;

namespace EToy.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
