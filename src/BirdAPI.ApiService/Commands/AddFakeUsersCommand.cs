using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using Bogus;
using MediatR;

namespace BirdAPI.ApiService.Commands;

public class AddFakeUsersCommand : IRequest<List<Guid>>
{
    public Int32 Count { get; set; } = 10; // Default count is set to 10
    
    public class AddFakeUsersHandler(ApplicationGraphContext context) : IRequestHandler<AddFakeUsersCommand, List<Guid>>
    {
        public async Task<List<Guid>> Handle(AddFakeUsersCommand request, CancellationToken cancellationToken)
        {
            var users = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, f => f.Person.FullName)
                .Generate(request.Count);
            
            context.Users.AddRange(users);
            await context.SaveChangesAsync();
            
            Console.WriteLine($"Created {users.Count} users with Ids: {String.Join(", ", users.Select(u => u.Id))}");
            Console.WriteLine($"with names: {String.Join(", ", users.Select(u => u.Name))}");
            
            return users.Select(u => u.Id).ToList();
        }
    }
}
