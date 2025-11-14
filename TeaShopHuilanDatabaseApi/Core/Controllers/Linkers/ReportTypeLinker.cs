using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class ReportTypeLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<bool> AddItem(ReportType item)
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

        public async Task<bool> DeleteItem(ReportType item)
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

        public async Task<List<ReportType>> GetAllReportTypes()
        {
            var items = await _requester.GetAllReportTypes();
            return await ModelsConverterService.FromEfToPdo(items);
        }

        public async Task<bool> PutItem(ReportType item)
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
