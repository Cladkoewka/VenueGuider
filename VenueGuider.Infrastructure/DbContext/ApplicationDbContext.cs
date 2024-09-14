using Microsoft.EntityFrameworkCore;
using VenueGuider.Domain.Entities;
using VenueGuider.Infrastructure.DbContext.Configurations;

namespace VenueGuider.Infrastructure.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<VenueTag> VenueTags { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new VenueConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new VenueTagConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}