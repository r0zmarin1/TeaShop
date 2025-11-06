using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class RoleLinker
    {
        private RequestService _requester = RequestService.Instance;

        public List<Role> GetAllRoles()
        { 
            return _requester.GetAllRoles();
        }
    }
}
