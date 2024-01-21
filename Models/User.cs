using System.ComponentModel.DataAnnotations;

namespace СlothesShopWebApp.Models;

public class User
{
    [Key] public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();

    public List<Order> Orders { get; set; } = new List<Order>();
}
