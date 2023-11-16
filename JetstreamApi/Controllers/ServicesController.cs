using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
