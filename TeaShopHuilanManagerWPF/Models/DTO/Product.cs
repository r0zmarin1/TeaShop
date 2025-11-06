using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class Product 
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
