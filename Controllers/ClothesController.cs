using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WearShopWebApp.Controllers;

public class ClothesController : Controller
{
    private readonly DatabaseContext db;
    public ClothesController(DatabaseContext db) => this.db = db;

    // Отримання одиниці одягу за ідентифікатором.
    [HttpGet]
    [Route("/clothes/{id:int}")]
    public async Task<IActionResult> ClothesPage(int id)
    {
        var clothes = await db.Clothes
            .Include(clothes => clothes.Photos)
            .Include(clothes => clothes.Category)
            .Include(clothes => clothes.Comments)
            .Include(clothes => clothes.Sizes)
            .Include(clothes => clothes.Colors)
            .FirstOrDefaultAsync(clothes => clothes.Id == id);
        if (clothes is null) return NotFound();

        return View("/Views/Home/Clothes.cshtml", clothes);
    }
}
