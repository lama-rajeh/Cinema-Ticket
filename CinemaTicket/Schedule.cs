using System;
using System.Collections.Generic;

namespace Domain;

public partial class Schedule
{
    public int Id { get; set; }

    public DateOnly? Year { get; set; }

    public int? Week { get; set; }

    public int? CinemaId { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
