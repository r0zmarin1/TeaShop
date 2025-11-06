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

        #region RequestMethods

        public List<Role> GetAllRoles()
        { 
            return  [.. _context.Roles];
        }

        #endregion
    }
}
