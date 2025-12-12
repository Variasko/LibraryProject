using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class Book
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("author_id")]
        public int AuthorId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        // Navigation property
        [JsonProperty("author")]
        public Author Author { get; set; } = new();

        [JsonProperty("takings")]
        public List<TakingBook> Takings { get; set; } = new();

        [JsonProperty("incoming_records")]
        public List<BookIncoming> IncomingRecords { get; set; } = new();
    }
}