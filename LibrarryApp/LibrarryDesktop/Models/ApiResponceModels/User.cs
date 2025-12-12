using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("patronymic")]
        public string? Patronymic { get; set; }

        [JsonProperty("birthday")]
        public DateOnly? Birthday { get; set; }

        [JsonProperty("registration_date")]
        public DateOnly RegistrationDate { get; set; }

        [JsonProperty("takings")]
        public List<TakingBook> Takings { get; set; } = new();
    }
}