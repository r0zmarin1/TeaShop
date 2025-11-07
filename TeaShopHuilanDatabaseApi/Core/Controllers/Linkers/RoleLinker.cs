using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class RoleLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<List<Role>> GetAllRoles()
        { 
            var items =  await _requester.GetAllRoles();
            return await ModelsConverterService.FromEfToPdo(items);
        }
    }
}
