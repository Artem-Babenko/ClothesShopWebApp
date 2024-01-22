using Microsoft.EntityFrameworkCore;

namespace СlothesShopWebApp.Tests;

public abstract class TestControllerBase : IDisposable
{
    protected readonly DatabaseContext database;
    public TestControllerBase()
    {
        var dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        database = new DatabaseContext(dbContextOptions);
    }

    public void Dispose()
    {
        database.Database.EnsureDeleted();
        database.Dispose();
    }
}
