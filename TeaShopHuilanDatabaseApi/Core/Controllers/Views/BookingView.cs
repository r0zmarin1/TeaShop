using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Bookings")]
    [ApiController]
    public class BookingView : ControllerBase
    {
        private BookingLinker _linker;

        public BookingView()
        {
            _linker = new();
        }

        [HttpGet("GetAll")]
        public async  Task<ActionResult<List<Booking>>> GetBookings()
        {
            var result =  await _linker.GetAllBookings();
            if (result == null)
                return NoContent();

            return result;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<bool>> AddItem(Booking item)
        {
            var result = await _linker.AddItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("PutItem")]
        public async Task<ActionResult<bool>> PutItem(Booking item)
        {
            var result = await _linker.PutItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpDelete("DeleteItem")]
        public async Task<ActionResult<bool>> DeleteItem(Booking item)
        {
            var result = await _linker.DeleteItem(item);
            if (!result)
                return BadRequest();

            return result;
        }
    }
}
