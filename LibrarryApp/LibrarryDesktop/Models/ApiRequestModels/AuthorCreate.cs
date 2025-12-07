using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class AuthorCreate
    {
        [JsonProperty("surname")]
        public string Surname { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }
        [JsonProperty("birth_year")]
        public int BirthYear { get; set; }
        [JsonProperty("death_year")]
        public int DeathYear { get; set; }
    }
}