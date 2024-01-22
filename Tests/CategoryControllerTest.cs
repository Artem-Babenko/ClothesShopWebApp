using Microsoft.AspNetCore.Mvc;
using Xunit;
using СlothesShopWebApp.Controllers;
using СlothesShopWebApp.Models;

namespace СlothesShopWebApp.Tests;

public class CategoryControllerTest : TestControllerBase
{
    private CategoryController controller;
    public CategoryControllerTest() => controller = new CategoryController(database);

    [Fact]
    public async Task Male_ReturnViewResult()
    {
        // Arrange
        var audiences = new List<Audience>()
        {
            new Audience() { Type = AudienceType.Female },
            new Audience() { Type = AudienceType.Male }
        };
        var categories = new List<Category>()
        {
            new Category() { Name = "MaleCategory1", Audience = audiences[1] },
            new Category() { Name = "MaleCategory2", Audience = audiences[1] },
            new Category() { Name = "FemaleCategory1", Audience = audiences[0] },
            new Category() { Name = "FemaleCategory1", Audience = audiences[0] }
        };
        List<Task> tasks = new List<Task>()
        {
            database.Audiences.AddRangeAsync(audiences),
            database.Categories.AddRangeAsync(categories)
        };
        await Task.WhenAll(tasks);
        await database.SaveChangesAsync();

        // Act
        IActionResult result = await controller.Male();
        ViewResult? viewResult = result as ViewResult;
        var model = viewResult?.Model as List<Category>;

        // Assert
        Assert.NotNull(viewResult);
        Assert.IsType<List<Category>>(model);
        Assert.True(model.All(c => c.Audience?.Type == AudienceType.Male));
        Assert.Equal("Чоловічий одяг", viewResult?.ViewData["AudienceClothes"]?.ToString());
        Assert.Equal("/Views/Home/AudienceCategories.cshtml", viewResult?.ViewName);
    }

    [Fact]
    public async Task Female_ReturnViewResult()
    {
        // Arrange
        var audiences = new List<Audience>()
        {
            new Audience() { Type = AudienceType.Female },
            new Audience() { Type = AudienceType.Male }
        };
        var categories = new List<Category>()
        {
            new Category() { Name = "MaleCategory1", Audience = audiences[1] },
            new Category() { Name = "MaleCategory2", Audience = audiences[1] },
            new Category() { Name = "FemaleCategory1", Audience = audiences[0] },
            new Category() { Name = "FemaleCategory1", Audience = audiences[0] }
        };
        List<Task> tasks = new List<Task>()
        {
            database.Audiences.AddRangeAsync(audiences),
            database.Categories.AddRangeAsync(categories)
        };
        await Task.WhenAll(tasks);
        await database.SaveChangesAsync();

        // Act
        IActionResult result = await controller.Female();
        ViewResult? viewResult = result as ViewResult;
        var model = viewResult?.Model as List<Category>;

        // Assert
        Assert.NotNull(viewResult);
        Assert.IsType<List<Category>>(model);
        Assert.True(model.All(c => c.Audience?.Type == AudienceType.Female));
        Assert.Equal("Жіночий одяг", viewResult?.ViewData["AudienceClothes"]?.ToString());
        Assert.Equal("/Views/Home/AudienceCategories.cshtml", viewResult?.ViewName);
    }

    [Fact]
    public async Task Category_ReturnViewResult()
    {
        // Arrange
        var categories = new List<Category>()
        {
            new Category() { Name = "MaleCategory1" },
            new Category() { Name = "MaleCategory2" },
            new Category() { Name = "FemaleCategory1" },
            new Category() { Name = "FemaleCategory1" }
        };
        var clothes = new List<Clothes>()
        {
            new Clothes() { Name = "Clothes1", Category = categories[0] },
            new Clothes() { Name = "Clothes2", Category = categories[0] },
            new Clothes() { Name = "Clothes3", Category = categories[0] }
        };
        var photos = new List<Photo>()
        {
            new Photo() { LocalPath = "/path1", Clothes = clothes[0] },
            new Photo() { LocalPath = "/path2", Clothes = clothes[0] }
        };
        List<Task> tasks = new List<Task>()
        {
            database.Categories.AddRangeAsync(categories),
            database.Clothes.AddRangeAsync(clothes),
            database.Photos.AddRangeAsync(photos)
        };
        await Task.WhenAll(tasks);
        await database.SaveChangesAsync();

        // Act
        IActionResult result = await controller.Category(categories[0].Id);
        ViewResult? viewResult = result as ViewResult;
        var model = viewResult?.Model as Category;

        // Assert
        Assert.NotNull(viewResult);
        Assert.IsType<Category>(model);
        Assert.NotNull(model.Clothes);
        Assert.NotNull(model.Clothes[0].Photos);
        Assert.Equal(model.Clothes[0].Photos[0].LocalPath, photos[0].LocalPath);
        Assert.Equal("/Views/Home/ClothesCategory.cshtml", viewResult?.ViewName);
    }
}
