using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class AuthorizeLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<User> Authorize(User user)
        {
            if (ValidationService.CheckValidness(user))
            {
                var item = await _requester.Authorize(await ModelsConverterService.FromPdoToEf(user));
                return await ModelsConverterService.FromEfToPdo(item);
            }

            return null;
        }
    }
}
