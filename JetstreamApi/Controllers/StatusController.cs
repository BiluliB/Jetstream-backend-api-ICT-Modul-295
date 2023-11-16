using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
