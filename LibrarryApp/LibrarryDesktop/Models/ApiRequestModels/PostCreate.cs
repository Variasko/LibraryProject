using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiRequestModels
{
    public class PostCreate
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}