using HwAspNet9.Data;
using Microsoft.AspNetCore.Mvc;

namespace HwAspNet9.Controllers
{
    public class AccountController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult IsUserNameInUse(string userName)
        {
            bool isNameTaken = _context.Users.Any(u => u.UserName == userName);
            return Json(!isNameTaken);
        }
    }
}
