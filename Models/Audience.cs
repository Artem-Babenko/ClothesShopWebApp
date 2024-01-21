using System.ComponentModel.DataAnnotations;

namespace СlothesShopWebApp.Models;

public class Audience
{
    [Key] public int Id { get; set; }

    public string? Type { get; set; }

    public List<Category> Categories { get; set; } = new List<Category>();
}
