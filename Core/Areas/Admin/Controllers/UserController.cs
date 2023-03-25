using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
