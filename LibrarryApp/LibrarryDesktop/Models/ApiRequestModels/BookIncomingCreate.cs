using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
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