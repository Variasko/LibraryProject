using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class HTTPValidationError
    {
        [JsonProperty("detail")]
        public List<ValidationError> Detail { get; set; }
    }
}