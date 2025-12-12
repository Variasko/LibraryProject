using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiRequestModels
{
    public class BookIncomingCreate
    {
        [JsonProperty("book_id")]
        public int BookId { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("incoming_date")]
        public DateTime IncomingDate { get; set; }
    }
}