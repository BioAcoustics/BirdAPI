using BirdAPI.ApiService.Database;
using BirdAPI.ApiService.Database.Models;
using MediatR;


namespace BirdAPI.ApiService.Commands
{
    public class GetXenoCantoItemByIdQuery : IRequest<XenoCantoEntry>
    {
        public string Id { get; set; }
        
        public class GetXenoCantoItemByIdHandler : IRequestHandler<GetXenoCantoItemByIdQuery, XenoCantoEntry>
        {
            private readonly ApplicationDbContext _context;

            public GetXenoCantoItemByIdHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<XenoCantoEntry> Handle(GetXenoCantoItemByIdQuery request, CancellationToken cancellationToken)
            {
                var item = await _context.XenoCantoEntries.FindAsync(new object[] { request.Id }, cancellationToken);
                if (item == null)
                {
                    throw new KeyNotFoundException($"Item with ID {request.Id} not found.");
                }

                return item;
            }
        }
    }
}