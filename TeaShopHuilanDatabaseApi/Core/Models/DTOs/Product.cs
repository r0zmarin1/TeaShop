using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class Product 
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
