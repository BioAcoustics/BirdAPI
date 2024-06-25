using BirdAPI.ApiService.Database;
using MediatR;

namespace BirdAPI.ApiService.Commands;

public class AddXenoCantoItemCommand :  IRequest<Guid>
{
    public List<XenoCantoEntry> XenoCantoEntries { get; set; }
    
    public class AddXenoCantoItemHandler(ApplicationDBContext context) : IRequestHandler<AddXenoCantoItemCommand, Guid>
    {
        public async Task<Guid> Handle(AddXenoCantoItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // loop through the list of XenoCantoEntries and show the "also" property if it is not empty
                foreach (var entry in request.XenoCantoEntries)
                {
                    if (entry.also.Any())
                    {
                        // Console.WriteLine($"also: {entry.also}");
                    }
                }

                context.XenoCantoEntries.AddRange(request.XenoCantoEntries);
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