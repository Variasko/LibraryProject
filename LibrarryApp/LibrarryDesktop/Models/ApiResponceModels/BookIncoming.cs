using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiResponceModels
{
    public class BookIncoming
    {
        [JsonProperty("id")]
        public int? Id { get; set; }
        [JsonProperty("book_id")]
        public int? BookId { get; set; }
        [JsonProperty("amount")]
        public int? Amount { get; set; }
        [JsonProperty("incoming_date")]
        public DateTime IncomingDate { get; set; }
    }
}