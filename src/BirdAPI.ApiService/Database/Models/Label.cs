namespace BirdAPI.ApiService.Database.Models;

public class Label
{
    public Guid Id { get; set; }
    public Recording Recording { get; set; }
}