using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopHuilanManagerWPF.Models.Interfaces;

namespace TeaShopHuilanManagerWPF.Models.DTO
{
    public class ReportsDTO : IIncrementalModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReportTypeId { get; set; }
        public string Path { get; set; }
        public DateTime  TimeStamp { get; set; }
    }
}
