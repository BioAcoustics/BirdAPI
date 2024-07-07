using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using Bogus;

namespace BirdAPI.Data.Repositories;


public interface IUserRepository
{
    Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
    Task AddUsersRangeAsync(IEnumerable<User> users, CancellationToken cancellationToken);
    Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<User> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Guid>> AddFakeUsersAsync(int count, CancellationToken cancellationToken);
}

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task AddUsersRangeAsync(IEnumerable<User> users, CancellationToken cancellationToken)
    {
        await context.Users.AddRangeAsync(users, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Users.FindAsync(new object[] { id }, cancellationToken) ?? throw new InvalidOperationException();
    }
    
    public async Task<User> DeleteUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetUserByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new KeyNotFoundException($"Item with ID {id} not found.");
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);

        return user;
    }
    
    public async Task<IEnumerable<Guid>> AddFakeUsersAsync(int count, CancellationToken cancellationToken)
    {
        var users = new Faker<User>()
            .RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .Generate(count);
        
        await context.Users.AddRangeAsync(users, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
 
        return users.Select(u => u.Id).ToList();
    }
}