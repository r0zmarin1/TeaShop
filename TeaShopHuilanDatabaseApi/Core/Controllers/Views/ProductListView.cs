using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/ProductLists")]
    [ApiController]
    public class ProductListView : ControllerBase
    {
        private ProductListLinker _linker;

        public ProductListView()
        {
            _linker = new();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductList>>> GetProductLists()
        {
            var result = await _linker.GetAllProductLists();
            if (result == null)
                return NoContent();

            return result;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<bool>> AddItem(ProductList item)
        {
            var result = await _linker.AddItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("PutItem")]
        public async Task<ActionResult<bool>> PutItem(ProductList item)
        {
            var result = await _linker.PutItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpDelete("DeleteItem")]
        public async Task<ActionResult<bool>> DeleteItem(ProductList item)
        {
            var result = await _linker.DeleteItem(item);
            if (!result)
                return BadRequest();

            return result;
        }
    }
}
