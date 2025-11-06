using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.Interfaces;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class BookingsDTO: IIncrementalModel
    {
        public int Id { get; set; }
        public int HoursCount { get; set; }
        public int TableId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
