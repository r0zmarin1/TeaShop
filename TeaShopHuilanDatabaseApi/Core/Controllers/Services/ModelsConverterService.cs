namespace TeaShopHuilanDatabaseApi.Core.Controllers.Services
{
    public static class ModelsConverterService
    {
        #region FromEftoPdo

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

        #endregion

        #region FromPdoToEf

        public static async Task<List<Models.EfModels.Booking>> FromPdoToEf (List<Models.DTOs.Booking> items)
        {
            List<Models.EfModels.Booking> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Booking> FromPdoToEf(Models.DTOs.Booking item)
        {
            Models.EfModels.Booking result = new()
            {
                Id = item.Id,
                TimeStamp = item.TimeStamp,
                IdUser = item.UserId,
                IdTable = item.TableId,
                HoursCount = item.HoursCount,

                IdUserNavigation = await FromPdoToEf(item.User),
                IdTableNavigation = await FromPdoToEf(item.Table)
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Category>> FromPdoToEf(List<Models.DTOs.Category> items)
        {
            List<Models.EfModels.Category> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Category> FromPdoToEf(Models.DTOs.Category item)
        {
            Models.EfModels.Category result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Order>> FromPdoToEf(List<Models.DTOs.Order> items)
        {
            List<Models.EfModels.Order> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Order> FromPdoToEf(Models.DTOs.Order item)
        {
            Models.EfModels.Order result = new()
            {
                Id = item.Id,
                Cost = item.Cost,
                IdBooking = item.BookingId,

                IdBookingNavigation = await FromPdoToEf(item.Booking)
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Product>> FromPdoToEf(List<Models.DTOs.Product> items)
        {
            List<Models.EfModels.Product> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Product> FromPdoToEf(Models.DTOs.Product item)
        {
            Models.EfModels.Product result = new()
            {
                Id = item.Id,
                Title = item.Title,
                Cost = item.Cost,
                IdCategory = item.CategoryId,

                IdCategoryNavigation = await FromPdoToEf(item.Category)
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Productslist>> FromPdoToEf(List<Models.DTOs.ProductList> items)
        {
            List<Models.EfModels.Productslist> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Productslist> FromPdoToEf(Models.DTOs.ProductList item)
        {
            Models.EfModels.Productslist result = new()
            {
                IdOrder = item.OrderId,
                IdProduct = item.ProductId,
                ProductCount = item.ProductCount,

                IdOrderNavigation = await FromPdoToEf(item.Order),
                IdProductNavigation = await FromPdoToEf(item.Product)
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Report>> FromPdoToEf(List<Models.DTOs.Report> items)
        {
            List<Models.EfModels.Report> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Report> FromPdoToEf(Models.DTOs.Report item)
        {
            Models.EfModels.Report result = new()
            {
                Id = item.Id,
                IdUser = item.UserId,
                IdReportType = item.ReportTypeId,
                Path = item.Path,
                TimeStamp = item.TimeStamp,

                IdUserNavigation = await FromPdoToEf(item.User),
                IdReportTypeNavigation = await FromPdoToEf(item.Type)
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Reporttype>> FromPdoToEf(List<Models.DTOs.ReportType> items)
        {
            List<Models.EfModels.Reporttype> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Reporttype> FromPdoToEf(Models.DTOs.ReportType item)
        {
            Models.EfModels.Reporttype result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Role>> FromPdoToEf(List<Models.DTOs.Role> items)
        {
            List<Models.EfModels.Role> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Role> FromPdoToEf(Models.DTOs.Role item)
        {
            Models.EfModels.Role result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Status>> FromPdoToEf(List<Models.DTOs.Status> items)
        {
            List<Models.EfModels.Status> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Status> FromPdoToEf(Models.DTOs.Status item)
        {
            Models.EfModels.Status result = new()
            {
                Id = item.Id,
                Title = item.Title
            };

            return result;
        }

        public static async Task<List<Models.EfModels.Table>> FromPdoToEf(List<Models.DTOs.Table> items)
        {
            List<Models.EfModels.Table> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.Table> FromPdoToEf(Models.DTOs.Table item)
        {
            Models.EfModels.Table result = new()
            {
                Id = item.Id,
                IdStatus = item.StatusId,
                MaxPeopleCount = item.MaxPeopleCount,

                IdStatusNavigation = await FromPdoToEf(item.Status)
            };

            return result;
        }

        public static async Task<List<Models.EfModels.User>> FromPdoToEf(List<Models.DTOs.User> items)
        {
            List<Models.EfModels.User> result = [];

            foreach (var item in items)
            {
                result.Add(await FromPdoToEf(item));
            }

            return result;
        }

        public static async Task<Models.EfModels.User> FromPdoToEf(Models.DTOs.User item)
        {
            Models.EfModels.User result = new()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Patronymic = item.Patronymic,
                IsBlocked = (sbyte)(item.IsBlocked ? 1 : 0),
                IdRole = item.RoleId,
                BonusesCount = item.BonusesCount,
                Password = item.Password,
                PhoneNumber = item.PhoneNumber,

                IdRoleNavigation = await FromPdoToEf(item.Role)
            };

            return result;
        }

        #endregion
    }
}
