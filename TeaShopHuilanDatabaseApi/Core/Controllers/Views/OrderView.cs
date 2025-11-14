using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Orders")]
    [ApiController]
    public class OrderView : ControllerBase
    {
        private OrderLinker _linker;

        public OrderView()
        {
            _linker = new();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var result = await _linker.GetAllOrders();
            if (result == null)
                return NoContent();

            return result;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<bool>> AddItem(Order item)
        {
            var result = await _linker.AddItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("PutItem")]
        public async Task<ActionResult<bool>> PutItem(Order item)
        {
            var result = await _linker.PutItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpDelete("DeleteItem")]
        public async Task<ActionResult<bool>> DeleteItem(Order item)
        {
            var result = await _linker.DeleteItem(item);
            if (!result)
                return BadRequest();

            return result;
        }
    }
}
