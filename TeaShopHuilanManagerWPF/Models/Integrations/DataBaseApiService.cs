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
                var result = false;

                var responce = bool.Parse(await _client.PostAsJsonAsync("Bookings/AddItem", val).Result.Content.ReadAsStringAsync());

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
                var result = false;

                var responce = bool.Parse(await _client.PutAsJsonAsync("Bookings/AddItem", val).Result.Content.ReadAsStringAsync());

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
                var result = false;

                var responce = bool.Parse(await _client.DeleteAsync($"Bookings/AddItem?iem={val}").Result.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденная ошибка");
                return default;
            }
        }
    }
}

/*
CategoryView
GET
Categories/GetAll
POST
Categories/AddItem
PUT
Categories/PutItem
DELETE
Categories/DeleteItem

OrderView
GET
Orders/GetAll
POST
Orders/AddItem
PUT
Orders/PutItem
DELETE
Orders/DeleteItem

ProductListView
GET
ProductLists/GetAll
POST
ProductLists/AddItem
PUT
ProductLists/PutItem
DELETE
ProductLists/DeleteItem

ProductView
GET
Products/GetAll
POST
Products/AddItem
PUT
Products/PutItem
DELETE
Products/DeleteItem

ReportTypeView
GET
ReportTypes/GetAll
POST
ReportTypes/AddItem
PUT
ReportTypes/PutItem
DELETE
ReportTypes/DeleteItem

ReportView
GET
Reports/GetAll
POST
Reports/AddItem
PUT
Reports/PutItem
DELETE
Reports/DeleteItem

RoleView
GET
Roles/GetAll

StatusView
GET
Statuses/GetAll
POST
Statuses/AddItem
PUT
Statuses/PutItem
DELETE
Statuses/DeleteItem

TableView
GET
TableView/GetAll
POST
TableView/AddItem
PUT
TableView/PutItem
DELETE
TableView/DeleteItem

UserView
GET
Users/GetAll
POST
Users/AddItem
PUT
Users/PutItem
PUT
Users/BlockUser
PUT
Users/UnBlockUser
DELETE
Users/DeleteItem 
*/
