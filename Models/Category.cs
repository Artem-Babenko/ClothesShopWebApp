using System.ComponentModel.DataAnnotations;

namespace WearShopWebApp.Models;

public class Category
{
    [Key] public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhotoPath { get; set; }

    public List<Clothes> Clothes { get; set; } = new List<Clothes>();

    public Audience? Audience { get; set; }
    
    public int? AudienceId { get; set; }
}
