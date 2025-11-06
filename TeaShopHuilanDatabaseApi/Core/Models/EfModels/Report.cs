using System;
using System.Collections.Generic;

namespace TeaShopHuilanDatabaseApi.Core.Models.EfModels;

public partial class Report
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdReportType { get; set; }

    public DateTime TimeStamp { get; set; }

    public string Path { get; set; } = null!;

    public virtual Reporttype IdReportTypeNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
