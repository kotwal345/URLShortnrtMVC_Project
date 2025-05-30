using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using URLShortnerMVC_Project.Models;
using URLShortnerMVC_Project.Data;

namespace URLShortnerMVC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Url");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = _context.Users
                .FirstOrDefault(u => u.Username == model.Username);

            if (existingUser != null)
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }

            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
