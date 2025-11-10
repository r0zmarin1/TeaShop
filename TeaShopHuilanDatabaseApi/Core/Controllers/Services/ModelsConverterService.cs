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

        public static async Task<List<Models.DTOs.Product>> FromEfToPdo(List<Models.EfModels.Product> items)
        {
            List<Models.DTOs.Product> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Product> FromEfToPdo(Models.EfModels.Product item)
        {
            Models.DTOs.Product result = new()
            {
                Id = item.Id,
                Title = item.Title,
                Cost = item.Cost,
                CategoryId = item.IdCategoryNavigation.Id,

                Category = await FromEfToPdo(item.IdCategoryNavigation)
            };

            return result;
        }

        public static async Task<List<Models.DTOs.ProductList>> FromEfToPdo(List<Models.EfModels.Productslist> items)
        {
            List<Models.DTOs.ProductList> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.ProductList> FromEfToPdo(Models.EfModels.Productslist item)
        {
            Models.DTOs.ProductList result = new()
            {
                OrderId = item.IdOrderNavigation.Id,
                ProductId = item.IdProductNavigation.Id,
                ProductCount = item.ProductCount,

                Order = await FromEfToPdo(item.IdOrderNavigation),
                Product = await FromEfToPdo(item.IdProductNavigation)
            };

            return result;
        }

        public static async Task<List<Models.DTOs.Report>> FromEfToPdo(List<Models.EfModels.Report> items)
        {
            List<Models.DTOs.Report> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Report> FromEfToPdo(Models.EfModels.Report item)
        {
            Models.DTOs.Report result = new()
            {
                Id = item.Id,
                UserId = item.IdUserNavigation.Id,
                ReportTypeId = item.IdReportTypeNavigation.Id,
                Path = item.Path,
                TimeStamp = item.TimeStamp,

                User = await FromEfToPdo(item.IdUserNavigation),
               Type = await FromEfToPdo(item.IdReportTypeNavigation)
            };

            return result;
        }

        public static async Task<List<Models.DTOs.ReportType>> FromEfToPdo(List<Models.EfModels.Reporttype> items)
        {
            List<Models.DTOs.ReportType> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.ReportType> FromEfToPdo(Models.EfModels.Reporttype item)
        {
            Models.DTOs.ReportType result = new()
            {
                Id = item.Id,
                Title = item.Title
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

        public static async Task<List<Models.DTOs.Status>> FromEfToPdo(List<Models.EfModels.Status> items)
        {
            List<Models.DTOs.Status> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Status> FromEfToPdo(Models.EfModels.Status item)
        {
            Models.DTOs.Status result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }

        public static async Task<List<Models.DTOs.Table>> FromEfToPdo(List<Models.EfModels.Table> items)
        {
            List<Models.DTOs.Table> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.Table> FromEfToPdo(Models.EfModels.Table item)
        {
            Models.DTOs.Table result = new()
            {
                Id = item.Id,
                StatusId = item.IdStatusNavigation.Id,
                MaxPeopleCount = item.MaxPeopleCount,

                Status = await FromEfToPdo(item.IdStatusNavigation)
            };

            return result;
        }

        public static async Task<List<Models.DTOs.User>> FromEfToPdo(List<Models.EfModels.User> items)
        {
            List<Models.DTOs.User> result = [];

            foreach (var item in items)
            {
                result.Add(await FromEfToPdo(item));
            }

            return result;
        }

        public static async Task<Models.DTOs.User> FromEfToPdo(Models.EfModels.User item)
        {
            Models.DTOs.User result = new()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Patronymic = item.Patronymic,
                IsBlocked = item.IsBlocked == 1,
                RoleId = item.IdRoleNavigation.Id,
                BonusesCount = item.BonusesCount,
                Password = item.Password,
                PhoneNumber = item.PhoneNumber,

                Role = await FromEfToPdo(item.IdRoleNavigation)
            };

            return result;
        }
    }
}
