using System;
using System.Collections.Generic;

namespace TeaShopHuilanDatabaseApi.Core.Models.EfModels;

public partial class Table
{
    public int Id { get; set; }

    public int IdStatus { get; set; }

    public int MaxPeopleCount { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
