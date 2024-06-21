using Microsoft.AspNetCore.SignalR;


namespace BirdAPI.ApiService.Database.Models;

public class Recording
{
    public Guid Id { get; set; }
    public decimal Duration { get; set; }
    public List<Label> Labels { get; set; }
}