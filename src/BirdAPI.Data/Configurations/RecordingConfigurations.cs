using BirdAPI.ApiService.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BirdAPI.ApiService.Database.Configurations;

public class RecordingConfigurations : IEntityTypeConfiguration<Recording>
{
    public void Configure(EntityTypeBuilder<Recording> builder)
    {
        
    }
}