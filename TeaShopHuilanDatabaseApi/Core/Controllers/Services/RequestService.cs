using TeaShopHuilanDatabaseApi.Core.Models.DTOs;

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

        public List<Booking> GetAllBookings()
        {
            return [.. _context.Bookings];
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

        public List<Role> GetAllRoles()
        {
            return [.. _context.Roles];
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
