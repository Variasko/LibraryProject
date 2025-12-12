using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiRequestModels
{
    public class UserUpdate
    {
        [JsonProperty("surname")]
        public string? Surname { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("patronymic")]
        public string? Patronymic { get; set; }
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
        [JsonProperty("registration_date")]
        public DateTime? RegistrationDate { get; set; }
    }
}