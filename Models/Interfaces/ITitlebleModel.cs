using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopHuilanManagerWPF.Models.Interfaces
{
    internal interface ITitlebleModel: IIncrementalModel
    {
        public string Title { get; set; }
    }
}
