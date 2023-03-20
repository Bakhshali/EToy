using EToy.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EToy.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("[area]/[controller]/[action]")]
    [AllowAnonymous]
    public class DashboardController : MyController
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]

        public IActionResult AccessDenied() => View();
    }
}
