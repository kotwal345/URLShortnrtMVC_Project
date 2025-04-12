using Microsoft.AspNetCore.Mvc;
using URLShortnerMVC_Project.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace URLShortnerMVC_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            var user = FakeUserStore.Users.FirstOrDefault(u =>
                u.Username == model.Username && u.Password == model.Password);

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
            var existingUser = FakeUserStore.Users.FirstOrDefault(u => u.Username == model.Username);
            if (existingUser != null)
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }

            FakeUserStore.Users.Add(model);
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
