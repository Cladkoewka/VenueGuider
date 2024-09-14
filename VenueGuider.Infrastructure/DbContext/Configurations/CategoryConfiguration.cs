using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueGuider.Domain.Entities;

namespace VenueGuider.Infrastructure.DbContext.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Description)
            .HasMaxLength(1000);

        // One to many with venues
        builder.HasMany(c => c.Venues)
            .WithOne(v => v.Category)
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}