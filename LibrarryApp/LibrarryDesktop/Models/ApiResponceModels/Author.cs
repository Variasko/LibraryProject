using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class Author
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }
        [JsonProperty("birth_year")]
        public int? BirthYear { get; set; }
        [JsonProperty("death_year")]
        public int? DeathYear { get; set; }
    }
}