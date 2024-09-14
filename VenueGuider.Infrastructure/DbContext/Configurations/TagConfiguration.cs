using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueGuider.Domain.Entities;

namespace VenueGuider.Infrastructure.DbContext.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        // many to many with venue
        builder.HasMany(t => t.VenueTags)
            .WithOne(vt => vt.Tag)
            .HasForeignKey(vt => vt.TagId);
    }
}