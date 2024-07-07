using System;
using System.Threading;
using System.Threading.Tasks;
using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using MediatR;

namespace BirdAPI.ApiService.Commands;

public class AddUserCommand : IRequest<Guid>
{
    public string Name { get; set; }

    public AddUserCommand(string name)
    {
        Name = name;
    }

    public class CreateUserHandler(ApplicationDbContext context) : IRequestHandler<AddUserCommand, Guid>
    {
        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Name = request.Name;
            user.Id = Guid.NewGuid();

            await context.Users.AddAsync(user, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"User {user.Id} with Name {user.Name} created");

            return user.Id;
        }
    }
}