using Newtonsoft.Json;

namespace LibraryDesktop.Models.ApiResponceModels
{
    public class TakingBook
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("book_id")]
        public int BookId { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("employee_id")]
        public int EmployeeId { get; set; }

        [JsonProperty("taking_date")]
        public DateOnly TakingDate { get; set; }

        [JsonProperty("is_returned")]
        public bool IsReturned { get; set; }

        [JsonProperty("return_date")]
        public DateOnly? ReturnDate { get; set; }

        // Navigation properties
        [JsonProperty("book")]
        public Book Book { get; set; } = new();

        [JsonProperty("user")]
        public User User { get; set; } = new();

        [JsonProperty("employee")]
        public Employee Employee { get; set; } = new();
    }
}