using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.Interfaces;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class RoleDTO : ITitlebleModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
    }
}
