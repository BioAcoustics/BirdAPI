using BirdAPI.ApiService.Database;
using MediatR;

namespace BirdAPI.ApiService.Commands;

public class AddXenoCantoItemCommand :  IRequest<Guid>
{
    public List<XenoCantoEntry> XenoCantoEntries { get; set; }
    
    public class AddXenoCantoItemHandler(ApplicationGraphContext context) : IRequestHandler<AddXenoCantoItemCommand, Guid>
    {
        public async Task<Guid> Handle(AddXenoCantoItemCommand request, CancellationToken cancellationToken)
        {
            context.XenoCantoEntries.AddRange(request.XenoCantoEntries);
            await context.SaveChangesAsync();
            
            return Guid.NewGuid();
        }
    }
}