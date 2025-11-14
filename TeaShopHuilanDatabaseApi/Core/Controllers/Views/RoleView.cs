using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Roles")]
    [ApiController]
    public class RoleView : ControllerBase
    {
        private RoleLinker _linker;

        public RoleView() 
        {
            _linker = new();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            var result = await _linker.GetAllRoles();
            if (result == null)
                return NoContent();

            return result;
        }
    }
}
