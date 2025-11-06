using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class Table
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int MaxPeopleCount { get; set; }

        public Status Status { get; set; }
    }
}
