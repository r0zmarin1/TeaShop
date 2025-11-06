using System;
using System.Collections.Generic;

namespace TeaShopHuilanDatabaseApi.Core.Models.EfModels;


public partial class Booking
{
    public int Id { get; set; }

    public DateTime TimeStamp { get; set; }

    public int HoursCount { get; set; }

    public int IdTable { get; set; }

    public int IdUser { get; set; }

    public virtual Table IdTableNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}