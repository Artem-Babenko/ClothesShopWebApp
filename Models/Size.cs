using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace СlothesShopWebApp.Models;

public class Size
{
    [Key] public int Id { get; set; }

    public string? Title { get; set; }

    public Clothes? Clothes { get; set; }

    public int? ClothesId { get; set; }
}
