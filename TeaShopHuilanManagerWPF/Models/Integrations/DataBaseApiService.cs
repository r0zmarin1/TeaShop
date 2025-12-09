using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeaShopHuilanManagerWPF.Models.DTO;

namespace TeaShopHuilanManagerWPF.Models.Integrations
{
    public class DataBaseApiService
    {
        private static DataBaseApiService _instance;
        private User _currentUser;
        private HttpClient _client;

        public static DataBaseApiService Instance { get => _instance ??= new(); }
        public User CurrentUser { get => _currentUser ??= new(); }

        public DataBaseApiService()
        {
            _client = new() { BaseAddress = new Uri("http://localhost:5120/api/") };
        }

        #region AuthorizeView

        public async Task<bool> Authorize(string password)
        {
            try
            {
                var result = false;
                var defaultUser = new User() { BonusesCount = 1, FirstName = "default", LastName = "default", IsBlocked = false, Id = 0, Password = password, Patronymic = "default", PhoneNumber = "+79149999999", RoleId = 1, Role = new() { Id = 1, Title = "default" } };

                var responce = await _client.GetFromJsonAsync<User>($"Authorize/Authorize?item={defaultUser}");

                if (responce != null)
                {
                    result = true;
                    _currentUser = responce;
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region BookingView

        public async Task<List<Booking>> GetAllBookings()
        {
            try
            {
                var result = new List<Booking>();

                result = await _client.GetFromJsonAsync<List<Booking>>("Bookings/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddBooking(Booking val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("Bookings/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditBooking(Booking val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Bookings/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteBooking(Booking val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"Bookings/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region CategoryView

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var result = new List<Category>();

                result = await _client.GetFromJsonAsync<List<Category>>("Categories/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddCategory(Category val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("Categories/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditCategory(Category val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Categories/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteCategory(Category val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"Categories/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region OrderView

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                var result = new List<Order>();

                result = await _client.GetFromJsonAsync<List<Order>>("Orders/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddOrder(Order val)
        {
            try
            {
                var result = false;

                var responce = bool.Parse(await _client.PostAsJsonAsync("Orders/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditOrder(Order val)
        {
            try
            {
                var result = false;

                var responce = bool.Parse(await _client.PutAsJsonAsync("Orders/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteOrder(Order val)
        {
            try
            {
                var result = false;

                var responce = bool.Parse(await _client.DeleteAsync($"Bookings/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region ProductListView

        public async Task<List<ProductList>> GetAllProductLists()
        {
            try
            {
                var result = new List<ProductList>();

                result = await _client.GetFromJsonAsync<List<ProductList>>("ProductLists/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddProductList(ProductList val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("ProductLists/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditProductList(ProductList val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("ProductLists/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteProductList(ProductList val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"ProductLists/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region ProductView

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var result = new List<Product>();

                result = await _client.GetFromJsonAsync<List<Product>>("Products/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddProduct(Product val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("Products/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditProduct(Product val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Products/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteProduct(Product val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"Products/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region ReportTypeView

        public async Task<List<ReportType>> GetAllReportTypes()
        {
            try
            {
                var result = new List<ReportType>();

                result = await _client.GetFromJsonAsync<List<ReportType>>("ReportTypes/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddReportType(ReportType val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("ReportTypes/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditReportType(ReportType val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("ReportTypes/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteReportType(ReportType val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"ReportTypes/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region ReportView

        public async Task<List<Report>> GetAllReports()
        {
            try
            {
                var result = new List<Report>();

                result = await _client.GetFromJsonAsync<List<Report>>("Reports/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<byte[]> GetReportData(int id)
        {
            using var response = await _client.GetAsync($"Reports/GetData/{id}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Ошибка загрузки документа: {response.StatusCode}");

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<bool> AddReport(Report val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("Reports/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditReport(Report val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Reports/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteReport(Report val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"Reports/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region RoleView

        public async Task<List<Role>> GetAllRoles()
        {
            try
            {
                var result = new List<Role>();

                result = await _client.GetFromJsonAsync<List<Role>>("Roles/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region StatusView

        public async Task<List<Status>> GetAllStatuses()
        {
            try
            {
                var result = new List<Status>();

                result = await _client.GetFromJsonAsync<List<Status>>("Statuses/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddStatus(Status val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("Statuses/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditStatus(Status val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Statuses/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteStatus(Status val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"Statuses/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region TableView

        public async Task<List<Table>> GetAllTables()
        {
            try
            {
                var result = new List<Table>();

                result = await _client.GetFromJsonAsync<List<Table>>("TableView/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddTable(Table val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("TableView/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditTable(Table val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("TableView/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteTable(Table val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"TableView/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion

        #region UserView

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var result = new List<User>();

                result = await _client.GetFromJsonAsync<List<User>>("Users/GetAll");

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> AddUser(User val)
        {
            try
            {
                var result = bool.Parse(await _client.PostAsJsonAsync("Users/AddItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> EditUser(User val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Users/PutItem", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> BlockUser(User val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Users/BlockUser", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> UnBlockUser(User val)
        {
            try
            {
                var result = bool.Parse(await _client.PutAsJsonAsync("Users/UnBlockUser", val).Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        public async Task<bool> DeleteUser(User val)
        {
            try
            {
                var result = bool.Parse(await _client.DeleteAsync($"Users/DeleteItem/{val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }

        #endregion
    }
}
