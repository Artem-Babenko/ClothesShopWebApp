using Microsoft.EntityFrameworkCore;
using СlothesShopWebApp.Models;

namespace СlothesShopWebApp;

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

    public DbSet<Color> Colors { get; set; } = null!;

    public DatabaseContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Audience> audiences = new List<Audience>()
        {
            new Audience() { Id = 1, Type = "male" },
            new Audience() { Id = 2, Type = "female" }
        };

        List<Category> categories = new List<Category>()
        {
            // Для чоловіків.
            new Category() { Id = 1,
                Name = "Куртки",
                PhotoPath = "/categoryPhotos/men's jacket.jpeg",
                AudienceId = 1,
            },
            new Category() { Id = 2,
                Name = "Джинси",
                PhotoPath = "/categoryPhotos/men's jeans.jpg",
                AudienceId = 1,
            },
            new Category() { Id = 3,
                Name = "Штани",
                PhotoPath = "/categoryPhotos/men's pants.jpg",
                AudienceId = 1,
            },
            new Category() { Id = 4,
                Name = "Світшоти",
                PhotoPath = "/categoryPhotos/men's sweatshirt.jpg",
                AudienceId = 1,
            },
            new Category() { Id = 5,
                Name = "Светри",
                AudienceId = 1,
            },
            new Category() { Id = 6,
                Name = "Футболки",
                AudienceId = 1,
            },
            new Category() { Id = 7,
                Name = "Сорочки",
                AudienceId = 1,
            },
            new Category() { Id = 8,
                Name = "Шорти",
                AudienceId = 1,
            },

            // Для жінок.
            new Category() { Id = 9,
                Name = "Куртки та пальта",
                AudienceId = 2,
            },
            new Category() { Id = 10,
                Name = "Джинси",
                AudienceId = 2,
            },
            new Category() { Id = 11,
                Name = "Штани і легінси",
                AudienceId = 2,
            },
            new Category() { Id = 12,
                Name = "Світшоти",
                AudienceId = 2,
            },
            new Category() { Id = 13,
                Name = "Светри",
                AudienceId = 2,
            },
            new Category() { Id = 14,
                Name = "Блузки",
                AudienceId = 2,
            },
            new Category() { Id = 15,
                Name = "Футболки та топи",
                AudienceId = 2,
            },
            new Category() { Id = 16,
                Name = "Сукні",
                AudienceId = 2,
            },
            new Category() { Id = 17,
                Name = "Сорочки",
                AudienceId = 2,
            },
            new Category() { Id = 18,
                Name = "Спідниці",
                AudienceId = 2,
            },
            new Category() { Id = 19,
                Name = "Шорти",
                AudienceId = 2,
            },
        };

        List<Clothes> clothes = new List<Clothes>()
        {
            new Clothes()
            {
                Id = 1,
                Name = "Чоловічий пуховик на блискавці",
                MaterialsDescription = "100% поліестер",
                CategoryId = 1,
                Count = 5,
                Prise = 1549
            }
        };

        List<Size> sizes = new List<Size>()
        {
            new Size()
            {
                Id = 1,
                ClothesId = 1,
                Title = "46 (S)"
            },
            new Size()
            {
                Id = 2,
                ClothesId = 1,
                Title = "48 (M)"
            },
            new Size()
            {
                Id = 3,
                ClothesId = 1,
                Title = "50 (L)"
            },
        };

        List<Photo> photos = new List<Photo>()
        {
            new Photo()
            {
                Id = 1,
                ClothesId = 1,
                LocalPath = "/clothesPhotos/169579534755b6b57ee8d8805234309d890fb7.jpg"
            },
            new Photo()
            {
                Id = 2,
                ClothesId = 1,
                LocalPath = "/clothesPhotos/169579534448daa59f7bb9c796ea145ace05723c21_thumbnail_900x.jpg"
            },
            new Photo()
            {
                Id = 3,
                ClothesId = 1,
                LocalPath = "/clothesPhotos/1695795342ad226754a58ed6ff5a733f3599bed69b_thumbnail_900x.jpg"
            },
        };

        List<Color> colors = new List<Color>()
        {
            new Color()
            {
                Id = 1,
                ClothesId = 1,
                Name = "Сірий",
                Hex = "#CCC",
            },
            new Color()
            {
                Id = 2,
                ClothesId = 1,
                Name = "Бордовий",
                Hex = "#3d0f0f",
            },
            new Color()
            {
                Id = 3,
                ClothesId = 1,
                Name = "Синій",
                Hex = "#0f144a",
            },
        };

        modelBuilder.Entity<Audience>().HasData(audiences);
        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Clothes>().HasData(clothes);
        modelBuilder.Entity<Size>().HasData(sizes);
        modelBuilder.Entity<Photo>().HasData(photos);
        modelBuilder.Entity<Color>().HasData(colors);
    }
}
