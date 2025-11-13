using System.Text.RegularExpressions;
using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Services
{
    public static class ValidationService
    {
        public static bool CheckValidness(Booking item)
        {
            var result = false;

            if (item is not null &&
                item.HoursCount > 0 &&
                CheckValidness(item.User) &&
                CheckValidness(item.Table) &&
                item.TableId == item.Table.Id &&
                item.UserId == item.User.Id &&
                item.TimeStamp.Minute % 10 == 0 &&
                item.TimeStamp.Date.Year == DateTime.Now.Year &&
                item.TimeStamp.Date.Month == DateTime.Now.Month &&
                item.TimeStamp.Date.Day > DateTime.Now.Day
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Category item)
        {
            var result = false;

            if (item is not null &&
                item.Title is not null &&
                item.Title != "" &&
                item.Title != " " &&
               !item.Title.Contains('\'') &&
               !item.Title.Contains('\"') &&
               !item.Title.Contains("--")
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Order item)
        {
            var result = false;

            if (item is not null &&
                item.Cost > 0 &&
                CheckValidness(item.Booking) &&
                item.BookingId == item.Booking.Id
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Product item)
        {
            var result = false;

            if (item is not null &&
                item.Title is not null &&
                item.Title != "" &&
                item.Title != " " &&
               !item.Title.Contains('\'') &&
               !item.Title.Contains('\"') &&
               !item.Title.Contains("--") &&
                item.Cost > 0 &&
                item.CategoryId == item.Category.Id &&
                CheckValidness(item.Category)
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(ProductList item)
        {
            var result = false;

            if (item is not null &&
                item.ProductCount > 0 &&
                CheckValidness(item.Product) &&
                CheckValidness(item.Order) &&
                item.ProductId == item.Product.Id &&
                item.OrderId == item.Order.Id
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Report item)
        {
            var result = false;

            if (item is not null &&
                CheckValidness(item.User) &&
                CheckValidness(item.Type) &&
                item.UserId == item.User.Id &&
                item.ReportTypeId == item.Type.Id &&
                item.Path is not null &&
                item.Path != "" &&
                item.Path != " " &&
               !item.Path.Contains("--") &&
                item.TimeStamp != DateTime.MinValue &&
                item.TimeStamp.Date.Ticks <= DateTime.Now.Date.Ticks
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(ReportType item)
        {
            var result = false;

            if (item is not null &&
                item.Title is not null &&
                item.Title != "" &&
                item.Title != " " &&
               !item.Title.Contains('\'') &&
               !item.Title.Contains('\"') &&
               !item.Title.Contains("--")
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Role item)
        {
            var result = false;

            if (item is not null &&
                item.Title is not null &&
                item.Title != "" &&
                item.Title != " " &&
               !item.Title.Contains('\'') &&
               !item.Title.Contains('\"') &&
               !item.Title.Contains("--")
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Status item)
        {
            var result = false;

            if (item is not null &&
                item.Title is not null &&
                item.Title != "" &&
                item.Title != " " &&
               !item.Title.Contains('\'') &&
               !item.Title.Contains('\"') &&
               !item.Title.Contains("--")
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(Table item)
        {
            var result = false;

            if (item is not null &&
                CheckValidness(item.Status) &&
                item.StatusId == item.Status.Id &&
                item.MaxPeopleCount > 0
                )
                result = true;

            return result;
        }

        public static bool CheckValidness(User item)
        {
            var result = false;

            if (item is not null &&
                item.FirstName is not null &&
                item.FirstName != "" &&
                item.FirstName != " " &&
               !item.FirstName.Contains('\'') &&
               !item.FirstName.Contains('\"') &&
               !item.FirstName.Contains("--") &&
                item.LastName is not null &&
                item.LastName != "" &&
                item.LastName != " " &&
               !item.LastName.Contains('\'') &&
               !item.LastName.Contains('\"') &&
               !item.LastName.Contains("--") &&
                CheckValidness(item.Role) &&
                item.RoleId == item.Role.Id &&
                item.BonusesCount > -1 &&
                item.Password is not null &&
                item.Password != "" &&
                item.Password != " " &&
               !item.Password.Contains('\'') &&
               !item.Password.Contains('\"') &&
               !item.Password.Contains("--") &&
               PhoneIsValid(item.PhoneNumber) &&
               PatronymicIsValid(item.Patronymic)
                )
                result = true;

            return result;
        }

        private static bool PatronymicIsValid(string? patr)
        {
            var result = false;

            if (patr is null)
            {
                result = true;
                return result;
            }
            else
            if (patr is not null &&
                patr != "" &&
                patr != " " &&
               !patr.Contains('\'') &&
               !patr.Contains('\"') &&
               !patr.Contains("--")
               )
                result = true;

            return result;
        }

        private static bool PhoneIsValid(string number)
        {
            var result = false;
            var filter = new Regex("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$");

            if (filter.IsMatch(number))
                result = true;

            return result;
        }
    }
}
