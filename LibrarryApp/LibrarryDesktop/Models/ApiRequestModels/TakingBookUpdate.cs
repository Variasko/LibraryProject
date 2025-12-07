using Newtonsoft.Json;

namespace LibrarryDesktop.Models.ApiRequestModels
{
    public class TakingBookUpdate
    {
        [JsonProperty("book_id")]
        public int? BookId { get; set; }
        [JsonProperty("user_id")]
        public int? UserId { get; set; }
        [JsonProperty("employee_id")]
        public int? EmployeeId { get; set; }
        [JsonProperty("taking_date")]
        public DateTime? TakingDate { get; set; }
        [JsonProperty("is_returned")]
        public bool? IsReturned { get; set; }
        [JsonProperty("return_date")]
        public DateTime? ReturnDate { get; set; }
    }
}