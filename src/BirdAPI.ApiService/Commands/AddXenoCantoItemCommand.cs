using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BirdAPI.ApiService.Commands;

public class AddXenoCantoItemCommand :  IRequest<string>
{
    public List<XenoCantoEntry>? XenoCantoEntries { get; set; }
    
    public class AddXenoCantoItemHandler(ApplicationDbContext context) : IRequestHandler<AddXenoCantoItemCommand, string>
    {
        public async Task<string> Handle(AddXenoCantoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await context.BulkMergeAsync(
                    request.XenoCantoEntries,
                    options => options.IncludeGraph = true, 
                    cancellationToken);
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw; // rethrow the exception after logging
            }
            return "Success";
            
        }

        private void LogException(Exception ex)
        {
            // Log the current exception
            Console.WriteLine($"Exception: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");

            // Recursively log inner exceptions
            if (ex.InnerException != null)
            {
                Console.WriteLine("Inner Exception:");
                LogException(ex.InnerException);
            }
        }

    }
}