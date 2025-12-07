using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiResponceModels
{
    public class Post
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}