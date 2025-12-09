using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopHuilanDatabaseApi.Core.Controllers.Linkers;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Views
{
    [Route("api/Reports")]
    [ApiController]
    public class ReportView : ControllerBase
    {
        private ReportLinker _linker;

        public ReportView()
        {
            _linker = new();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Report>>> GetReports()
        {
            var result = await _linker.GetAllReports();
            if (result == null)
                return NoContent();

            return result;
        }

        [HttpGet("GetData/{id}")]
        public async Task<ActionResult<byte[]>> GetReportData(int id)
        {
            var result = await _linker.GetContent(id);
            if (result == null)
                return NoContent();

            return result;
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<bool>> AddItem(Report item)
        {
            var result = await _linker.AddItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpPut("PutItem")]
        public async Task<ActionResult<bool>> PutItem(Report item)
        {
            var result = await _linker.PutItem(item);
            if (!result)
                return BadRequest();

            return result;
        }

        [HttpDelete("DeleteItem/{item}")]
        public async Task<ActionResult<bool>> DeleteItem(Report item)
        {
            var result = await _linker.DeleteItem(item);
            if (!result)
                return BadRequest();

            return result;
        }
    }
}
