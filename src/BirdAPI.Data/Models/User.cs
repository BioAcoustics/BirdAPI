namespace BirdAPI.ApiService.Database.Models;

public class User
{
    //public User(AddUserCommand request)
    //{
    //    Id = Guid.NewGuid();
    //    Name = request.Name;
    //}

    public User(){ }
   
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}