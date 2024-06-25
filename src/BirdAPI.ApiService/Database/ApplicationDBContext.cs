using Microsoft.EntityFrameworkCore;
using BirdAPI.ApiService.Database.Models;

namespace BirdAPI.ApiService.Database;

public class ApplicationDBContext : DbContext
{
    public DbSet<Recording> Recordings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<XenoCantoEntry> XenoCantoEntries { get; set; }
    
    
}