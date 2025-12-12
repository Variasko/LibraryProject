using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiRequestModels
{
    public class AuthModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}