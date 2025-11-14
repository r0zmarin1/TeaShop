using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class UserLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<bool> AddItem(User item)
        {
            var result = false;

            if (!ValidationService.CheckValidness(item))
            {
                return result;
            }

            var convertedValue = await ModelsConverterService.FromPdoToEf(item);
            result = await _requester.AddItem(convertedValue);

            return result;
        }

        public async Task<bool> Blockuser(User item)
        {
            var result = false;

            if (!ValidationService.CheckValidness(item))
            {
                return result;
            }

            var convertedValue = await ModelsConverterService.FromPdoToEf(item);
            result = await _requester.BlockUser(convertedValue);

            return result;
        }

        public async Task<bool> DeleteItem(User item)
        {
            var result = false;

            if (!ValidationService.CheckValidness(item))
            {
                return result;
            }

            var convertedValue = await ModelsConverterService.FromPdoToEf(item);
            result = await _requester.DeleteItem(convertedValue);

            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var items = await _requester.GetAllUsers();
            return await ModelsConverterService.FromEfToPdo(items);
        }

        public async Task<bool> PutItem(User item)
        {
            var result = false;

            if (!ValidationService.CheckValidness(item))
            {
                return result;
            }

            var convertedValue = await ModelsConverterService.FromPdoToEf(item);
            result = await _requester.UpdateItem(convertedValue);

            return result;
        }

        public async Task<bool> UnBlockUser(User item)
        {
            var result = false;

            if (!ValidationService.CheckValidness(item))
            {
                return result;
            }

            var convertedValue = await ModelsConverterService.FromPdoToEf(item);
            result = await _requester.UnBlockUser(convertedValue);

            return result;
        }
    }
}
