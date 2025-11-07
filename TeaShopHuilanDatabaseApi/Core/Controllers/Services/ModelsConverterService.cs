namespace TeaShopHuilanDatabaseApi.Core.Controllers.Services
{
    public static class ModelsConverterService
    {
        public static async Task<List<Models.DTOs.Booking>> FromEfToPdo(List<Models.EfModels.Booking> items)
        {
            List<Models.DTOs.Booking> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Booking> FromEfToPdo(Models.EfModels.Booking item)
        {
            Models.DTOs.Booking result = new()
            {
                Id = item.Id,
                TimeStamp = item.TimeStamp,
                UserId = item.IdUserNavigation.Id,
                TableId = item.IdUserNavigation.Id,
                HoursCount = item.HoursCount,

                User = await FromEfToPdo(item.IdUserNavigation),
                Table = await FromEfToPdo(item.IdTableNavigation)
            };
            //resultItem.User.FirstName = item.IdUserNavigation.FirstName;
            //resultItem.User.LastName = item.IdUserNavigation.LastName;
            //resultItem.User.Patronymic = item.IdUserNavigation.Patronymic;
            //resultItem.User.IsBlocked = item.IdUserNavigation.IsBlocked == 1;
            //resultItem.User.BonusesCount = item.IdUserNavigation.BonusesCount;
            //resultItem.User.Password = item.IdUserNavigation.Password;
            //resultItem.User.PhoneNumber = item.IdUserNavigation.PhoneNumber;

            return result;
        }

        public static async Task<List<Models.DTOs.Category>> FromEfToPdo(List<Models.EfModels.Category> items)
        {
            List<Models.DTOs.Category> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Category> FromEfToPdo(Models.EfModels.Category item)
        {
            Models.DTOs.Category result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }

        public static async Task<List<Models.DTOs.Order>> FromEfToPdo(List<Models.EfModels.Order> items)
        {
            List<Models.DTOs.Order> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Order> FromEfToPdo(Models.EfModels.Order item)
        {
            Models.DTOs.Order result = new()
            {
                Id = item.Id,
                Cost = item.Cost,
                BookingId = item.IdBookingNavigation.Id,

                Booking = await FromEfToPdo(item.IdBookingNavigation)
            };

            return result;
        }

        public static async Task<List<Models.DTOs.Order>> FromEfToPdo(List<Models.EfModels.Order> items)
        {
            List<Models.DTOs.Order> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Order> FromEfToPdo(Models.EfModels.Order item)
        {
            Models.DTOs.Order result = new()
            {
                Id = item.Id,
                Cost = item.Cost,
                BookingId = item.IdBookingNavigation.Id,

                Booking = await FromEfToPdo(item.IdBookingNavigation)
            };

            return result;
        }

        public static async Task<List<Models.DTOs.Role>> FromEfToPdo(List<Models.EfModels.Role> items)
        {
            List<Models.DTOs.Role> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Role> FromEfToPdo(Models.EfModels.Role item)
        {
            Models.DTOs.Role result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }
    }
}
