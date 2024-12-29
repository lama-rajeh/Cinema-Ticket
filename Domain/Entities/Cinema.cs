using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cinema
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
