using BirdAPI.ApiService.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using BirdAPI.ApiService.Database.Models;

namespace BirdAPI.ApiService.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Recording> Recordings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<XenoCantoEntry> XenoCantoEntries { get; set; }
    public DbSet<Sono> Sonos { get; set; }
    public DbSet<Osci> Oscis { get; set; }    
    public string DbPath { get; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new XenoCantoEntryConfiguration());
        // Weitere Konfigurationen hier
    }
}