using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WearShopWebApp.Models;

public class Photo
{
    [Key] public int Id { get; set; }

    public string? LocalPath { get; set; }

    public Clothes? Clothes { get; set; }

    public int? ClothesId { get; set; }
}
