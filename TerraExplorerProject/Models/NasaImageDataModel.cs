using Newtonsoft.Json;

namespace TerraExplorerProject.Models
{
    public class NasaImageDataModel
    {
        public NasaImageCollection Collection { get; set; }
    }

    public class NasaImageCollection
    {
        public string Version { get; set; }
        public string Href { get; set; }
        public List<NasaImageItem> Items { get; set; }
        public NasaMetadata Metadata { get; set; }
        public List<NasaLink> Links { get; set; }
    }

    public class NasaImageItem
    {
        public int? ItemId { get; set; }
        public string Href { get; set; }
        public List<NasaImageData> Data { get; set; }
        public List<NasaImageLink> Links { get; set; }
    }

    public class NasaImageData
    {
        public string Title { get; set; }
        public List<string> Keywords { get; set; }
        [JsonProperty("nasa_id")]
        public string NasaId { get; set; }
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }
        [JsonProperty("media_type")]
        public string MediaType { get; set; }
        [JsonProperty("description_508")]
        public string Description508 { get; set; }
        public string Description { get; set; }
        [JsonProperty("secondary_creator")]
        public string SecondaryCreator { get; set; }
    }

    public class NasaImageLink
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Render { get; set; }
    }

    public class NasaMetadata
    {
        [JsonProperty("total_hits")]
        public int TotalHits { get; set; }
    }

    public class NasaLink
    {
        public string Rel { get; set; }
        public string Prompt { get; set; }
        public string Href { get; set; }
    }


}
