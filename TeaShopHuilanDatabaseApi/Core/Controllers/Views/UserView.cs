using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Users")]
    [ApiController]
    public class UserView : ControllerBase
    {
        private UserLinker _linker;

        public UserView()
        {
            _linker = new();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var result = await _linker.GetAllUsers();
            if (result == null)
                return NoContent();

            return result;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<bool>> AddItem(User item)
        {
            var result = await _linker.AddItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("PutItem")]
        public async Task<ActionResult<bool>> PutItem(User item)
        {
            var result = await _linker.PutItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("BlockUser")]
        public async Task<ActionResult<bool>> BlockUser(User item)
        {
            var result = await _linker.Blockuser(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("UnBlockUser")]
        public async Task<ActionResult<bool>> UnblockUser(User item)
        {
            var result = await _linker.UnBlockUser(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpDelete("DeleteItem")]
        public async Task<ActionResult<bool>> DeleteItem(User item)
        {
            var result = await _linker.DeleteItem(item);
            if (!result)
                return BadRequest();

            return result;
        }
    }
}
