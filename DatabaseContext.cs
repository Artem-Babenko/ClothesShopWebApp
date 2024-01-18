using Microsoft.EntityFrameworkCore;
using WearShopWebApp.Models;

namespace WearShopWebApp;

public class DatabaseContext : DbContext
{
    public DbSet<Audience> Audiences { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Clothes> Clothes { get; set; } = null!;

    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Photo> Photos { get; set; } = null!;

    public DbSet<Size> Sizes { get; set; } = null!;

    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
