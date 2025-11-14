using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Authorize")]
    [ApiController]
    public class AuthorizeView : ControllerBase
    {
        private AuthorizeLinker _linker;

        public AuthorizeView()
        {
            _linker = new();
        }

        [HttpGet("Authorize")]
        public async Task<ActionResult<User>> GetRoles(User item)
        {
            var result = await _linker.Authorize(item);
            if (result == null)
                return NoContent();

            return result;
        }
    }
}
