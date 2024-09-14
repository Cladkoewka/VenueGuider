using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueGuider.Domain.Entities;

namespace VenueGuider.Infrastructure.DbContext.Configurations;

public class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.HasKey(v => v.Id);

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(v => v.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(v => v.Description)
            .HasMaxLength(1000);

        // many to many with tag
        builder.HasMany(v => v.VenueTags)
            .WithOne(vt => vt.Venue)
            .HasForeignKey(vt => vt.VenueId);
    }
}