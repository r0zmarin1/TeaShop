using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class Table
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int MaxPeopleCount { get; set; }

        public virtual Status Status { get; set; }
    }
}
