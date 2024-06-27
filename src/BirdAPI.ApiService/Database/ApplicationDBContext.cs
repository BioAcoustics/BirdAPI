using System;
using System.IO;
using BirdAPI.ApiService.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using BirdAPI.ApiService.Database.Models;

namespace BirdAPI.ApiService.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Recording> Recordings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<XenoCantoEntry> XenoCantoEntries { get; set; }
    public DbSet<Sono> Sonos { get; set; }
    public DbSet<Osci> Oscis { get; set; }    
    public string DbPath { get; }
    
    public ApplicationDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Combine(path, "BirdAPI.db");
    }
    
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new XenoCantoEntryConfiguration());
        // Weitere Konfigurationen hier
    }
}