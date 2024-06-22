using BirdAPI.ApiService.Database.Models;
using Neo4j.Berries.OGM.Enums;
using Neo4j.Berries.OGM.Interfaces;
using Neo4j.Berries.OGM.Models.Config;

namespace BirdAPI.ApiService.Database.Configurations;

public class XenoCantoEntryConfiguration : INodeConfiguration<XenoCantoEntry>
{
    public void Configure(NodeTypeBuilder<XenoCantoEntry> builder)
    {
        builder.HasIdentifier(x => x.id);
    }
    
}