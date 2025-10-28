using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.DTO;

namespace TeaShopHuilanManagerWPF.Models.Entities
{
    public class Booking: BookingsDTO
    {
        public Table Table { get; set; }
        public User User { get; set; }
    }
}
