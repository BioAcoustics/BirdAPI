using System.Collections.Generic;

public class XenoCantoResponse
{
    public string numRecordings { get; set; }
    public string numSpecies { get; set; }
    public int page { get; set; }
    public int numPages { get; set; }
    public List<XenoCantoEntry> recordings { get; set; }
}

public class XenoCantoEntry
{
    public string id { get; set; }
    public string gen { get; set; }
    public string sp { get; set; }
    public string ssp { get; set; }
    public string group { get; set; }
    public string en { get; set; }
    public string rec { get; set; }
    public string cnt { get; set; }
    public string loc { get; set; }
    public string lat { get; set; }
    public string lng { get; set; }
    public string alt { get; set; }
    public string type { get; set; }
    public string sex { get; set; }
    public string stage { get; set; }
    public string method { get; set; }
    public string url { get; set; }
    public string file { get; set; }
    public string fileName { get; set; }
    //public Sono sono { get; set; }
    //public Osci osci { get; set; }
    public string lic { get; set; }
    public string q { get; set; }
    public string length { get; set; }
    public string time { get; set; }
    public string date { get; set; }
    public string uploaded { get; set; }
    public List<string> also { get; set; }
    public string rmk { get; set; }
    public string birdSeen { get; set; }
    public string animalSeen { get; set; }
    public string playbackUsed { get; set; }
    public string temp { get; set; }
    public string regnr { get; set; }
    public string auto { get; set; }
    public string dvc { get; set; }
    public string mic { get; set; }
    public string smp { get; set; }
}

public class Sono
{
    public string small { get; set; }
    public string med { get; set; }
    public string large { get; set; }
    public string full { get; set; }
}

public class Osci
{
    public string small { get; set; }
    public string med { get; set; }
    public string large { get; set; }
}
