using BirdAPI.ApiService.Database.Models;
using Neo4j.Berries.OGM.Enums;
using Neo4j.Berries.OGM.Interfaces;
using Neo4j.Berries.OGM.Models.Config;

namespace BirdAPI.ApiService.Database.Configurations;

public class RecordingConfigurations : INodeConfiguration<Recording>
{
    public void Configure(NodeTypeBuilder<Recording> builder)
    {
        builder.HasRelationWithMultiple(x => x.Labels, "HAS_LABEL", RelationDirection.In);
    }
}