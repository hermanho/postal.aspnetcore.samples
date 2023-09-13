using Microsoft.AspNetCore.Mvc;

namespace WebSample.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dummy1()
        {
            return View();
        }
    }
}
