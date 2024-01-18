using System.ComponentModel.DataAnnotations;

namespace WearShopWebApp.Models;

public class Audience
{
    [Key] public int Id { get; set; }
    
    public string? Name { get; set; }

    public List<Category> Categories { get; set; } = new List<Category>();
}
