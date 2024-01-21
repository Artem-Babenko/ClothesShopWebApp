using System.ComponentModel.DataAnnotations;

namespace СlothesShopWebApp.Models;

public class Order
{
    [Key] public int Id { get; set; }

    public string? TestProperty { get; set; }

    public User? User { get; set; }

    public int? UserId { get; set; }
}
