using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;

namespace BirdAPI.Data.Repositories;

public interface IXenoCantoEntriyRepository
{
    Task AddXenoCantoEntryAsync(XenoCantoEntry entry, CancellationToken cancellationToken);
    Task AddXenoCantoEntriesRangeAsync(IEnumerable<XenoCantoEntry> entries, CancellationToken cancellationToken);
    Task AddOrUpdateXenoCantoEntryRangeAsync(IEnumerable<XenoCantoEntry> entries, CancellationToken cancellationToken);
    Task<XenoCantoEntry> GetXenoCantoEntryByIdAsync(string id, CancellationToken cancellationToken);
    Task<XenoCantoEntry> DeleteXenoCantoEntryByIdAsync(string id, CancellationToken cancellationToken);
}

public class XenoCantoEntriyRepository(ApplicationDbContext context)
{
    public async Task AddXenoCantoEntryAsync(XenoCantoEntry entry, CancellationToken cancellationToken)
    {
        await context.XenoCantoEntries.AddAsync(entry, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddXenoCantoEntriesRangeAsync(IEnumerable<XenoCantoEntry> entries, CancellationToken cancellationToken)
    {
        await context.XenoCantoEntries.AddRangeAsync(entries, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task AddOrUpdateXenoCantoEntryRangeAsync(IEnumerable<XenoCantoEntry> entries, CancellationToken cancellationToken)
    {
        await context.BulkMergeAsync(
            entries,
            options => options.IncludeGraph = true, 
            cancellationToken);
    }

    public async Task<XenoCantoEntry> GetXenoCantoEntryByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await context.XenoCantoEntries.FindAsync(new object[] { id }, cancellationToken) ?? throw new InvalidOperationException();
    }
    
    public async Task<XenoCantoEntry> DeleteXenoCantoEntryByIdAsync(string id, CancellationToken cancellationToken)
    {
        var entry = await GetXenoCantoEntryByIdAsync(id, cancellationToken);
        if (entry == null)
        {
            throw new KeyNotFoundException($"Item with ID {id} not found.");
        }

        context.XenoCantoEntries.Remove(entry);
        await context.SaveChangesAsync(cancellationToken);

        return entry;
    }
}