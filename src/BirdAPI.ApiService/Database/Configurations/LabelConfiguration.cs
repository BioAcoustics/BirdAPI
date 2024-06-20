using BirdAPI.ApiService.Database.Models;
using Neo4j.Berries.OGM.Enums;
using Neo4j.Berries.OGM.Interfaces;
using Neo4j.Berries.OGM.Models.Config;

namespace BirdAPI.ApiService.Database.Configurations;

public class LabelConfiguration : INodeConfiguration<Label>
{
    public void Configure(NodeTypeBuilder<Label> builder)
    {
        builder.HasRelationWithSingle(x => x.Recording, "HAS_LABEL", RelationDirection.Out);
    }
}