using Microsoft.AspNetCore.Mvc;
using Xunit;
using СlothesShopWebApp.Controllers;
using СlothesShopWebApp.Models;

namespace СlothesShopWebApp.Tests;

public class ClothesControllerTest : TestControllerBase
{
    private ClothesController controller;
    public ClothesControllerTest() => controller = new ClothesController(database);

    [Fact]
    public async Task ClothesPage_ReturnViewResult()
    {
        // Arrange
        var clothes = new Clothes();
        var category = new Category() { Name = "Category" };
        clothes.Category = category;
        var photo = new Photo() { LocalPath = "/path" };
        clothes.Photos.Add(photo);
        var size = new Size() { Title = "Size" };
        clothes.Sizes.Add(size);
        var color = new Color() { Name = "Color" };
        clothes.Colors.Add(color);
        var comment = new Comment() { Description = "Text" };
        clothes.Comments.Add(comment);
        await database.Clothes.AddAsync(clothes);
        await database.SaveChangesAsync();

        // Act
        var result = await controller.ClothesPage(clothes.Id);
        ViewResult? viewResult = result as ViewResult;
        var model = viewResult?.Model as Clothes;

        // Assert
        Assert.NotNull(viewResult);
        Assert.NotNull(model);
        Assert.Equal(model.Category, category);
        Assert.Equal(model.Colors[0], color);
        Assert.Equal(model.Sizes[0], size);
        Assert.Equal(model.Comments[0], comment);
        Assert.Equal(model.Photos[0], photo);
    }
}
