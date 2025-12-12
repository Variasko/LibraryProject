using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiRequestModels
{
    public class PostUpdate
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}