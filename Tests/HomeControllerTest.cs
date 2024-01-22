using Microsoft.AspNetCore.Mvc;
using Xunit;
using СlothesShopWebApp.Controllers;

namespace СlothesShopWebApp.Tests;

public class HomeControllerTest : TestControllerBase
{
    private HomeController controller;
    public HomeControllerTest() => controller = new HomeController();

    [Fact]
    public void Home_ReturnViewResult()
    {
        // Arrange

        // Act
        IActionResult result = controller.HomePage();
        ViewResult? viewResult = result as ViewResult;

        // Assert
        Assert.NotNull(viewResult);
        Assert.Equal("/Views/Home/Index.cshtml", viewResult.ViewName);
    }
}
