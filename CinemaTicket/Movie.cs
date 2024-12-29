using System;
using System.Collections.Generic;

namespace Domain;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public decimal? Duration { get; set; }

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    public virtual ICollection<MovieHall> MovieHalls { get; set; } = new List<MovieHall>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
