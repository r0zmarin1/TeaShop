using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class Report 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReportTypeId { get; set; }
        public string Path { get; set; }
        public DateTime  TimeStamp { get; set; }

        public virtual User User { get; set; }
        public virtual Type Type { get; set; }
    }
}
