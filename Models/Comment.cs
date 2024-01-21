using System.ComponentModel.DataAnnotations;

namespace СlothesShopWebApp.Models;

public class Comment
{
    [Key] public int Id { get; set; }

    public string? Description { get; set; }

    public float Rating { get; set; }

    public User? User { get; set; }

    public int? UserId { get; set; }

    public Clothes? Clothes { get; set; }

    public int? ClothesId { get; set; }
}
