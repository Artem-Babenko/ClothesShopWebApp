using Microsoft.AspNetCore.Mvc;

namespace СlothesShopWebApp.Controllers;

public class HomeController : Controller
{
    // Отримання головної сторінки.
    [HttpGet]
    [Route("/")]
    public IActionResult HomePage()
    {
        return View("/Views/Home/Index.cshtml");
    }
}
