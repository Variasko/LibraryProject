using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class BookUpdate
    {
        [JsonProperty("title")]
        public string? Title { get; set; }
        [JsonProperty("author_id")]
        public int? AuthorId { get; set; }
        [JsonProperty("amount")]
        public int? Amount { get; set; }
    }
}