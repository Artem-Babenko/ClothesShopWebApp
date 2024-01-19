using System.ComponentModel.DataAnnotations;

namespace WearShopWebApp.Models;

// Представляє інформацію про колір одягу.
public class Color
{
    [Key] public int Id { get; set; }

    public string? Name { get; set; }

    public string? Hex { get; set; }

    public Clothes? Clothes { get; set; }

    public int? ClothesId { get; set; }
}
