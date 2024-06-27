using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using MediatR;

namespace BirdAPI.ApiService.Commands;

public class AddXenoCantoItemCommand :  IRequest<Guid>
{
    public List<XenoCantoEntry> XenoCantoEntries { get; set; }
    
    public class AddXenoCantoItemHandler(ApplicationDbContext context) : IRequestHandler<AddXenoCantoItemCommand, Guid>
    {
        public async Task<Guid> Handle(AddXenoCantoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await context.XenoCantoEntries.AddRangeAsync(request.XenoCantoEntries);
                await context.SaveChangesAsync();

                return Guid.NewGuid();
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw; // rethrow the exception after logging
            }
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