using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BirdAPI.ApiService.Database.Models;

public class XenoCantoResponse
{
    public string? numRecordings { get; set; }
    public string? numSpecies { get; set; }
    public int page { get; set; }
    public int numPages { get; set; }
    public List<XenoCantoEntry> recordings { get; set; }
}

public class XenoCantoEntry
{
    [Key]
    public string id { get; set; }
    public string? gen { get; set; }
    public string? sp { get; set; }
    public string? ssp { get; set; }
    public string? group { get; set; }
    public string? en { get; set; }
    public string? rec { get; set; }
    public string? cnt { get; set; }
    public string? lat { get; set; }
    public string? loc { get; set; }
    public string? lng { get; set; }
    public string? alt { get; set; }
    public string? type { get; set; }
    public string? sex { get; set; }
    public string? stage { get; set; }
    public string? method { get; set; }
    public string? url { get; set; }
    public string? file { get; set; }
    [JsonPropertyName("file-name")]
    public string? fileName { get; set; }
    
    public Sono? sono { get; set; }
    public Osci? osci { get; set; }

    public string? lic { get; set; }
    public string q { get; set; }
    public string? length { get; set; }
    public string? time { get; set; }
    public string? date { get; set; }
    public string? uploaded { get; set; }
    public List<string>? also { get; set; }
    public string? rmk { get; set; }
    
    [JsonPropertyName("bird-seen")]
    public string? birdSeen { get; set; }
    [JsonPropertyName("animal-seen")]
    public string? animalSeen { get; set; }
    [JsonPropertyName("playback-used")]
    public string? playbackUsed { get; set; }
    public string? temp { get; set; }
    public string? regnr { get; set; }
    public string? auto { get; set; }
    public string? dvc { get; set; }
    public string? mic { get; set; }
    public string? smp { get; set; }
}

public class Sono
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("XenoCantoEntry")]
    public string XcId { get; set; }  // Make sure this is not nullable
    public XenoCantoEntry? XenoCantoEntry { get; set; }
    public string small { get; set; }
    public string med { get; set; }
    public string large { get; set; }
    public string full { get; set; }
}

public class Osci
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("XenoCantoEntry")]
    public string XcId { get; set; }  // Make sure this is not nullable
    public XenoCantoEntry? XenoCantoEntry { get; set; }
    public string small { get; set; }
    public string med { get; set; }
    public string large { get; set; }
}

