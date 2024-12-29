using System;
using System.Collections.Generic;

namespace Domain;

public partial class Hall
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<MovieHall> MovieHalls { get; set; } = new List<MovieHall>();
}
