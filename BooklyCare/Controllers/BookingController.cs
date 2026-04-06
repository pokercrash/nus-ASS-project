using BooklyCare.Models;
using BooklyCare.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooklyCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingRequest request)
        {
            var result = await _service.CreateBooking(request);
            return Ok(result);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            await _service.CancelBooking(id);
            return Ok();
        }

        [HttpPost("{id}/reschedule")]
        public async Task<IActionResult> Reschedule(Guid id, CreateBookingRequest request)
        {
            var result = await _service.RescheduleBooking(id, request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var booking = await _service.GetBookingById(id);

            if (booking == null)
                return NotFound(new { message = "Booking not found" });

            return Ok(booking);
        }
    }
}
