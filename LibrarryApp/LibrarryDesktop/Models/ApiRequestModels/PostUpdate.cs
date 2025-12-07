using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class PostUpdate
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}