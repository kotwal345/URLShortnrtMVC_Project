using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using URLShortnerMVC_Project.Models;
using System;
using System.Linq;

namespace URLShortnerMVC_Project.Controllers
{
    public class UrlController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult Shorten(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl))
                return View("Index");

            string shortCode = Guid.NewGuid().ToString().Substring(0, 6);
            string shortUrl = $"{Request.Scheme}://{Request.Host}/r/{shortCode}";

            string username = HttpContext.Session.GetString("Username");
            var user = FakeUserStore.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.Urls.Add(new ShortUrl
                {
                    OriginalUrl = originalUrl,
                    ShortenedUrl = shortUrl
                });
            }

            ViewBag.ShortUrl = shortUrl;
            return View("Index");
        }

        public IActionResult PreviousUrls()
        {
            string username = HttpContext.Session.GetString("Username");
            var user = FakeUserStore.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user.Urls);
        }
    }
}
