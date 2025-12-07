using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class ValidationError
    {
        [JsonProperty("loc")]
        public List<object> Loc { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}