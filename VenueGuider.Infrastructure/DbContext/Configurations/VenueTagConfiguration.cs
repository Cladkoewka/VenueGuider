using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VenueGuider.Domain.Entities;

namespace VenueGuider.Infrastructure.DbContext.Configurations;

public class VenueTagConfiguration : IEntityTypeConfiguration<VenueTag>
{
    public void Configure(EntityTypeBuilder<VenueTag> builder)
    {
        builder.HasKey(vt => new { vt.VenueId, vt.TagId });

        builder.HasOne(vt => vt.Venue)
            .WithMany(v => v.VenueTags)
            .HasForeignKey(vt => vt.VenueId);

        builder.HasOne(vt => vt.Tag)
            .WithMany(t => t.VenueTags)
            .HasForeignKey(vt => vt.TagId);
    }
}