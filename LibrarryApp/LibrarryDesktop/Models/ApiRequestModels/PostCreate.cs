using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class PostCreate
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}