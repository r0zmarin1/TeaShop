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

        public List<Category> GetAllCategories()
        {
            return [.. _context.Categories];
        }

        #endregion

        #region Orders

        public List<Order> GetAllOrders()
        {
            return [.. _context.Orders];
        }

        #endregion

        #region Products

        public List<Product> GetAllProducts()
        {
            return [.. _context.Products];
        }

        #endregion

        #region ProductLists

        public List<Productslist> GetAllProductLists()
        {
            return [.. _context.Productslists];
        }

        #endregion

        #region Reports

        public List<Report> GetAllReports()
        {
            return [.. _context.Reports];
        }

        #endregion

        #region ReportTypes

        public List<Reporttype> GetAllReportTypes()
        {
            return [.. _context.Reporttypes];
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

        public List<Status> GetAllStatuses()
        {
            return [.. _context.Statuses];
        }

        #endregion

        #region Tables

        public List<Table> GetAllTables()
        {
            return [.. _context.Tables];
        }

        #endregion

        #region Users

        public List<User> GetAllUsers()
        {
            return [.. _context.Users];
        }

        #endregion
    }
}
