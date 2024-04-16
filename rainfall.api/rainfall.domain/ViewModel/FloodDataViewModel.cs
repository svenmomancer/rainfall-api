using Newtonsoft.Json;

namespace rainfall.domain.ViewModel
{
    public class FloodDataViewModel
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        public Meta Meta { get; set; }
        public FloodItem Items { get; set; }
    }
}
