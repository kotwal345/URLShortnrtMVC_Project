using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using URLShortnerMVC_Project.Models;

namespace URLShortnerMVC_Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactModel model)
    {
        if (ModelState.IsValid)
        {
            // You can log it, send an email, or store it
            TempData["SuccessMessage"] = "Thank you for contacting us!";
            return RedirectToAction("Contact");
        }

        return View(model);
    }
}
