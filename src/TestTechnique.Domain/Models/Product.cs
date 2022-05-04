using System.ComponentModel.DataAnnotations;

namespace TestTechnique.Domain.Models;

public class Product : IEquatable<Product>
{
    [Key] public Guid Id { get; set; }
    [MaxLength(255)] public string? Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }

    public bool Equals(Product? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id) && Name == other.Name && Description == other.Description && Price == other.Price;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Description, Price);
    }
}