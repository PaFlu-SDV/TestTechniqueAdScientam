using Microsoft.EntityFrameworkCore;
using TestTechnique.Domain.Models;

namespace TestTechnique.Persistence;

public sealed class TestTechniqueDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public TestTechniqueDbContext()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public TestTechniqueDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
}