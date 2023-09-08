using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult CreateUser(string user)
    {
        HttpContext.Session.SetString("Name", user);
        HttpContext.Session.SetInt32("Number", 22);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/plusone")]
    public IActionResult PlusOne()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        num += 1;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }
    [HttpPost("dashboard/minusone")]
    public IActionResult MinusOne()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        num -= 1;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }
    [HttpPost("dashboard/xtwo")]
    public IActionResult TimesTwo()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        num *= 2;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/random")]
    public IActionResult RandomNum()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        Random rand = new();
        int RandomNumber = rand.Next(1, 11);
        num += RandomNumber;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }

    [HttpGet("dashboard")]
    public ViewResult Dashboard()
    {
        return View();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
}
