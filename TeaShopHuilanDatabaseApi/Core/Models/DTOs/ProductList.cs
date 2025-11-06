using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanDatabaseApi.Core.Models.DTOs
{
    public class ProductList
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
