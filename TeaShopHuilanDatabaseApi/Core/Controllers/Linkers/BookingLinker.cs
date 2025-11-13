using Microsoft.AspNetCore.Components.Forms;
using TeaShopHuilanDatabaseApi.Core.Controllers.Services;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Linkers
{
    public class BookingLinker
    {
        private RequestService _requester = RequestService.Instance;

        public async Task<List<Booking>> GetAllBookings()
        {
            var items =  await _requester.GetAllBookings();
            return await ModelsConverterService.FromEfToPdo(items);
        }

        /*
        public async Task<bool> AddItem(Booking item)
        {
            var result = false;

            if (!ValidationService.CheckValidness(item))
            { 
                return result;
            }    

            result = await _requester.AddItem(item);

            return result;
        }
        */
    }
}
