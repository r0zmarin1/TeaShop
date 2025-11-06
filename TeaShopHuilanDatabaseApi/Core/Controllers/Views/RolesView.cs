using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.EfModels;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Roles")]
    [ApiController]
    public class RolesView : ControllerBase
    {
        private RolesLinker _linker;

        public RolesView() 
        {
            _linker = new();
        }

        [HttpGet("GetAllRoles")]
        public List<Role> GetRoles()
        {
            return _linker.GetAllRoles();
        }
    }
}
