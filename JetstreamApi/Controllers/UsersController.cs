using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
