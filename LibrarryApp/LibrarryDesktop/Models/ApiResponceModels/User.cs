using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class User
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }
        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
        [JsonProperty("registration_date")]
        public DateTime RegistrationDate { get; set; }
    }
}