using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("employees")]
        public List<Employee> Employees { get; set; } = new();
    }
}