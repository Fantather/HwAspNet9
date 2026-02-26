using Microsoft.AspNetCore.Mvc;

namespace HwAspNet9.Controllers
{
    public class AccountController() : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IsUserNameInUse(string userName)
        {

        }
    }
}
