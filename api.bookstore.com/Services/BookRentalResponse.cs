namespace api.bookstore.com.Services
{
    public class BookRentResponse
    {
        public long RentId { get; set; }
        public DateTimeOffset ReturnDate { get; set; }
    }
}
