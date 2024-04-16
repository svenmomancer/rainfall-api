using Newtonsoft.Json;

namespace rainfall.domain.ViewModel
{
    public class ListFloodViewModel
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        public ListMeta Meta { get; set; }
        public List<FloodItems> Items { get; set; }
    }
}
