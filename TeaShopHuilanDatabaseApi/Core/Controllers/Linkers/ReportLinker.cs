using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class ReportLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<bool> AddItem(Report item)
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

        public async Task<bool> DeleteItem(Report item)
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

        public async Task<List<Report>> GetAllReports()
        {
            var items = await _requester.GetAllReports();
            return await ModelsConverterService.FromEfToPdo(items);
        }

        public async Task<bool> PutItem(Report item)
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

        public async Task<ActionResult<byte[]>> GetContent(int id)
        {
            var path = await _requester.GetAllReportById(id);
            var result = await ReporterService.GetContent(path);

            return result;
        }
    }
}
