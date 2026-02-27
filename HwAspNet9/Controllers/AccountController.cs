using HwAspNet9.Data;
using HwAspNet9.InputModels;
using HwAspNet9.Models;
using HwAspNet9.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HwAspNet9.Controllers
{
    public class AccountController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;
        public IActionResult Index()
        {
            var inputModelCollection = _context.Users
                .Select(u => new AccountIndexViewModel(
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    u.UserName,
                    u.Age,
                    u.Password,
                    u.Email,
                    u.PhoneNumber,
                    u.CreditCardNumber,
                    u.Website,
                    u.TermsOfService
                ))
                .ToList();
            return View(inputModelCollection);
        }

        public IActionResult IsUserNameInUse(string userName)
        {
            bool isNameTaken = _context.Users.Any(u => u.UserName == userName);
            return Json(!isNameTaken);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            User user = new User(
                inputModel.FirstName,
                inputModel.LastName,
                inputModel.UserName,
                inputModel.Age,
                inputModel.Password,
                inputModel.Email,
                inputModel.PhoneNumber,
                inputModel.CreditCardNumber,
                inputModel.Website,
                inputModel.TermsOfService
            );

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
