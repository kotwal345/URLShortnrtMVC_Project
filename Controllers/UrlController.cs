using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using URLShortnerMVC_Project.Models;
using URLShortnerMVC_Project.Data;

namespace URLShortnerMVC_Project.Controllers
{
    public class UrlController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrlController(ApplicationDbContext context)
        {
            _context = context;
        }

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
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                var newUrl = new ShortUrl
                {
                    OriginalUrl = originalUrl,
                    ShortenedUrl = shortUrl,
                    UserId = user.Id // foreign key to User table
                };

                _context.ShortUrls.Add(newUrl);
                _context.SaveChanges();

                ViewBag.ShortUrl = shortUrl;
            }

            return View("Index");
        }

        public IActionResult PreviousUrls()
        {
            string username = HttpContext.Session.GetString("Username");
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var urls = _context.ShortUrls
                        .Where(u => u.UserId == user.Id)
                        .ToList();

            return View(urls);
        }
    }
}
