using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    public class PrioritiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
