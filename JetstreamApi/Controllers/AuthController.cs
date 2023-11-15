using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
