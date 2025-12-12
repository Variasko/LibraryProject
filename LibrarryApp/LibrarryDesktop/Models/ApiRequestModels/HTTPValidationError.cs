using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiRequestModels
{
    public class HTTPValidationError
    {
        [JsonProperty("detail")]
        public List<ValidationError> Detail { get; set; }
    }
}