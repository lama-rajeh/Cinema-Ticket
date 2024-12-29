using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Hall
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<Movie_Hall> Movie_Halls { get; set; } = new List<Movie_Hall>();
}
