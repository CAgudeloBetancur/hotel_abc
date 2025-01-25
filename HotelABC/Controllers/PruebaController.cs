using Microsoft.AspNetCore.Mvc;

namespace HotelABC.Controllers;

public class PruebaController : Controller
{
    [HttpGet("[controller]/Primero")]
    public IActionResult Primero()
    {
        return View();
    }

    [HttpGet("[controller]/Segundo")]
    public IActionResult Segundo()
    {
        return View();
    }
}
