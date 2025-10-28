using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.Interfaces;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class TablesDTO: IIncrementalModel
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int MaxPeopleCount { get; set; }
    }
}
