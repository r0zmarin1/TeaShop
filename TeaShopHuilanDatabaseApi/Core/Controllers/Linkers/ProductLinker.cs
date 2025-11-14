using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class ProductLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<bool> AddItem(Product item)
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

        public async Task<bool> DeleteItem(Product item)
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

        public async Task<List<Product>> GetAllProducts()
        {
            var items = await _requester.GetAllProducts();
            return await ModelsConverterService.FromEfToPdo(items);
        }

        public async Task<bool> PutItem(Product item)
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
    }
}
