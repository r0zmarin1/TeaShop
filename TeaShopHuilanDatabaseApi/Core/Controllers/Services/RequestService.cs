using Microsoft.EntityFrameworkCore;
using TeaShopHuilanDatabaseApi.Core.Models.EfModels;

namespace TeaShopHuilanDatabaseApi.Core.Controllers.Services
{
    public class RequestService
    {
        private static RequestService _inst;
        private LanakaraokebarContext _context;

        public static RequestService Instance { get { return _inst ??= new(); } }

        public RequestService()
        {
            _context = new();
        }

        private void RefreshContext()
        {
            _context = new();
        }

        private async Task SaveContext()
        {
            await _context.SaveChangesAsync();
        }

        #region Bookings

        public async Task<List<Booking>> GetAllBookings()
        {
            RefreshContext();
            return [.. await _context.Bookings.ToListAsync()];
        }

        public async Task<bool> AddItem(Booking item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Bookings.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Bookings.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Bookings.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Booking item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Bookings.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Bookings.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Bookings.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Booking item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Bookings.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Bookings.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Bookings.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Categories

        public async Task<List<Category>> GetAllCategories()
        {
            RefreshContext();
            return [.. await _context.Categories.ToListAsync()];
        }

        public async Task<bool> AddItem(Category item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Categories.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Categories.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Categories.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Category item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Categories.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Categories.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Categories.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Category item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Categories.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Categories.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Categories.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Orders

        public async Task<List<Order>> GetAllOrders()
        {
            RefreshContext();
            return [.. await _context.Orders.ToListAsync()];
        }

        public async Task<bool> AddItem(Order item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Orders.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Orders.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Orders.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Order item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Orders.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Orders.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Orders.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Order item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Orders.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Orders.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Orders.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Products

        public async Task<List<Product>> GetAllProducts()
        {
            RefreshContext();
            return [.. await _context.Products.ToListAsync()];
        }

        public async Task<bool> AddItem(Product item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Products.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Products.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Products.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Product item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Products.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Products.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Products.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Product item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Products.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Products.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Products.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region ProductLists

        public async Task<List<Productslist>> GetAllProductLists()
        {
            RefreshContext();
            return [.. await _context.Productslists.ToListAsync()];
        }

        public async Task<bool> AddItem(Productslist item)
        {
            var result = false;

            RefreshContext();

            if (await _context.Productslists.FirstOrDefaultAsync(s => s.IdOrder == item.IdOrder && s.IdProduct == item.IdProduct) == null)
            {
                await _context.Productslists.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Productslists.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Productslist item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Productslists.FirstOrDefaultAsync(s => s.IdOrder == item.IdOrder && s.IdProduct == item.IdProduct)) == null)
            {
                _context.Productslists.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Productslists.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Productslist item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Productslists.FirstOrDefaultAsync(s => s.IdOrder == item.IdOrder && s.IdProduct == item.IdProduct)) == null)
            {
                _context.Productslists.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Productslists.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Reports

        public async Task<List<Report>> GetAllReports()
        {
            RefreshContext();
            return [.. await _context.Reports.ToListAsync()];
        }

        public async Task<bool> AddItem(Report item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Reports.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Reports.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Reports.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Report item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Reports.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Reports.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Reports.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Report item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Reports.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Reports.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Reports.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region ReportTypes

        public async Task<List<Reporttype>> GetAllReportTypes()
        {
            RefreshContext();
            return [.. await _context.Reporttypes.ToListAsync()];
        }

        public async Task<bool> AddItem(Reporttype item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Reporttypes.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Reporttypes.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Reporttypes.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Reporttype item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Reporttypes.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Reporttypes.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Reporttypes.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Reporttype item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Reporttypes.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Reporttypes.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Reporttypes.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Roles

        public async Task<List<Role>> GetAllRoles()
        {
            RefreshContext();
            return [.. await _context.Roles.ToListAsync()];
        }

        #endregion

        #region Statuses

        public async Task<List<Status>> GetAllStatuses()
        {
            RefreshContext();
            return [.. await _context.Statuses.ToListAsync()];
        }

        public async Task<bool> AddItem(Status item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Statuses.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Statuses.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Statuses.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Status item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Statuses.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Statuses.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Statuses.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Status item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Statuses.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Statuses.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Statuses.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Tables

        public async Task<List<Table>> GetAllTables()
        {
            RefreshContext();
            return [.. await _context.Tables.ToListAsync()];
        }

        public async Task<bool> AddItem(Table item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Tables.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Tables.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Tables.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(Table item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Tables.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Tables.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Tables.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(Table item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Tables.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Tables.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Tables.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Users

        public async Task<List<User>> GetAllUsers()
        {
            RefreshContext();
            return [.. await _context.Users.ToListAsync()];
        }

        public async Task<bool> AddItem(User item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Users.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                await _context.Users.AddAsync(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Users.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UpdateItem(User item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Users.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Users.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Users.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> DeleteItem(User item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Users.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                _context.Users.Remove(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (!_context.Users.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> BlockUser(User item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Users.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                item.IsBlocked = 1;
                _context.Users.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Users.Contains(item))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> UnBlockUser(User item)
        {
            var result = false;

            RefreshContext();

            if ((await _context.Users.FirstOrDefaultAsync(s => s.Id == item.Id)) == null)
            {
                item.IsBlocked = 0;
                _context.Users.Update(item);
            }
            else
            {
                return result;
            }

            await SaveContext();

            if (_context.Users.Contains(item))
            {
                result = true;
            }

            return result;
        }

        #endregion

    }
}
