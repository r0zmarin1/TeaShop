using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class Booking
    {
        public int Id { get; set; }
        public int HoursCount { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }

        public User User { get; set; }
        public Table Table { get; set; }
    }
}
