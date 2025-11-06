using System;
using System.Collections.Generic;

namespace TeaShopHuilanDatabaseApi.Core.Models.EfModels;

public partial class Reporttype
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
