using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class Author
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("patronymic")]
        public string? Patronymic { get; set; }

        [JsonProperty("birth_year")]
        public int? BirthYear { get; set; }

        [JsonProperty("death_year")]
        public int? DeathYear { get; set; }

        // Navigation property
        [JsonProperty("books")]
        public List<Book> Books { get; set; } = new();
    }
}