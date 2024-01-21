using System.ComponentModel.DataAnnotations;

namespace СlothesShopWebApp.Models;

public class Clothes
{
    [Key] public int Id { get; set; }

    public string? Name { get; set; }

    public List<Photo> Photos { get; set; } = new List<Photo>();

    public List<Size> Sizes { get; set; } = new List<Size>();

    public List<Comment> Comments { get; set; } = new List<Comment>();

    public string? Description { get; set; }

    public float Prise { get; set; }

    public List<Color> Colors { get; set; } = new List<Color>();

    public int Count { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Today;

    public string? MaterialsDescription { get; set; }

    public Category? Category { get; set; }

    public int? CategoryId { get; set; }
}
