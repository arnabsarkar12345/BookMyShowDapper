using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPIDapper.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        //[HttpGet("{id}", Name = "BookingById")]
        //public async Task<IActionResult> GetBooking(int id)
        //{
        //    try
        //    {
        //        var bookings = await _bookingService.GetBooking(id);
        //        return Ok(bookings);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        [HttpGet("{id}", Name = "BookingById")]
        public async Task<IActionResult> GetParticularBooking(int id)
        {
            try
            {
                var booking = await _bookingService.GetParticularBooking(id);
                if (booking == null)
                    return NotFound();
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingDTO booking)
        {
            try
            {
                var createdBooking = await _bookingService.CreateBooking(booking);
                return CreatedAtRoute("BookingById", new { id = createdBooking.BookingId }, createdBooking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
