using Microsoft.AspNetCore.Mvc;

namespace NorthWindWithControllersApp.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
