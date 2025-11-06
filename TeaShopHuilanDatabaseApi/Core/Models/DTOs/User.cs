using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }
        public bool IsBlocked { get; set; }
        public int RoleId { get; set; }
        public int BonusesCount { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public Role Role { get; set; }
    }
}
