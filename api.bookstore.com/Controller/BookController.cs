using api.bookstore.com.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.bookstore.com.Controller
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public async Task<IActionResult> Post(BookRentalRequest bookRentalRequest)
        {
            //Service call to process the rental request
            var rentActionResponse = new BookRentResponse
            {
                RentId = 12345,
                ReturnDate = DateTimeOffset.UtcNow.AddDays(7)
            };


            return Ok(rentActionResponse);
        }

    }
}
