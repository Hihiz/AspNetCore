using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index() => View(_userManager.Users.ToList());

        public IActionResult Create() => View();
    }
}
