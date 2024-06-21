using Microsoft.AspNetCore.SignalR;

namespace BirdAPI.ApiService.Database.Models;

public class User
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
}