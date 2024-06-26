using BirdAPI.ApiService.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirdAPI.ApiService.Database.Configurations;

public class XenoCantoEntryConfiguration : IEntityTypeConfiguration<XenoCantoEntry>
{
    public void Configure(EntityTypeBuilder<XenoCantoEntry> builder)
    {
        builder
            .HasOne(s => s.sono)
            .WithOne(e => e.XenoCantoEntry)
            .HasForeignKey<Sono>(e => e.XcId)
            .HasPrincipalKey<XenoCantoEntry>(x => x.id)
            .IsRequired(true);  // Ensure this is required

        builder
            .HasOne(o => o.osci)
            .WithOne(e => e.XenoCantoEntry)
            .HasForeignKey<Osci>(e => e.XcId)
            .HasPrincipalKey<XenoCantoEntry>(x => x.id)
            .IsRequired(true);  // Ensure this is required
    }
}