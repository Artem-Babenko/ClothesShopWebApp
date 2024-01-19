using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WearShopWebApp.Models;

namespace WearShopWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly DatabaseContext db;
    public CategoryController(DatabaseContext db) => this.db = db;

    // Отримання категорій чоловічого одягу.
    [HttpGet]
    [Route("/categories/male")]
    public async Task<IActionResult> Male()
    {
        var categories = await db.Categories
            .Where(c => c.Audience!.Type == AudienceType.Male)
            .ToListAsync();

        ViewBag.AudienceClothes = "Чоловічий одяг";
        return View("/Views/Home/AudienceCategories.cshtml", categories);
    }

    // Отримання категорій жіночого одягу.
    [HttpGet]
    [Route("/categories/female")]
    public async Task<IActionResult> Female()
    {
        var categories = await db.Categories
            .Where(c => c.Audience!.Type == AudienceType.Female)
            .ToListAsync();

        ViewBag.AudienceClothes = "Жіночий одяг";
        return View("/Views/Home/AudienceCategories.cshtml", categories);
    }

    // Отримання категорії з одягом за ідентифікатором.
    [HttpGet]
    [Route("/categories/{id:int}")]
    public async Task<IActionResult> Category(int id)
    {
        var categoryWithClothes = await db.Categories
            .Include(category => category.Clothes)
            .ThenInclude(clothes => clothes.Photos)
            .FirstOrDefaultAsync(category => category.Id == id);
        if (categoryWithClothes is null) return NotFound();

        return View("/Views/Home/ClothesCategory.cshtml", categoryWithClothes);
    }
}
