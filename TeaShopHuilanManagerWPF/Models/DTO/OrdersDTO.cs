using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.Interfaces;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class OrdersDTO: IIncrementalModel
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal Cost { get; set; }
    }
}
