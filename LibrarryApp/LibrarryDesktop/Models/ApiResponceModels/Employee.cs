using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class Employee
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

        [JsonProperty("post_id")]
        public int PostId { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; } = string.Empty;

        [JsonProperty("password")]
        public string Password { get; set; } = string.Empty;

        // Navigation
        [JsonProperty("post")]
        public Post Post { get; set; } = new();

        [JsonProperty("takings")]
        public List<TakingBook> Takings { get; set; } = new();
    }
}