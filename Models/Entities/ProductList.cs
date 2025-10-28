using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.DTO;

namespace TeaShopHuilanManagerWPF.Models.Entities
{
    public class ProductList: ProductsListsDTO
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
