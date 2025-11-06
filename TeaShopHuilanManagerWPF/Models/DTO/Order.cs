using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class Order
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Cost { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
