using System;
using System.Collections.Generic;

namespace TeaShopHuilanDatabaseApi.Core.Models.EfModels;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public sbyte IsBlocked { get; set; }

    public int IdRole { get; set; }

    public int BonusesCount { get; set; }

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
