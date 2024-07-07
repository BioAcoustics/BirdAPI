using BirdAPI.ApiService.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirdAPI.ApiService.Database.Configurations;

public class XenoCantoEntryConfiguration : IEntityTypeConfiguration<XenoCantoEntry>
{
    public void Configure(EntityTypeBuilder<XenoCantoEntry> builder)
    {
        builder.HasKey(e => e.id);

        builder
            .HasOne(e => e.sono)
            .WithOne(e => e.XenoCantoEntry)
            .HasForeignKey<Sono>(a => a.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(e => e.osci)
            .WithOne(e => e.XenoCantoEntry)
            .HasForeignKey<Osci>(a => a.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

    }
}