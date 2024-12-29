using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public decimal? Duration { get; set; }

    public virtual ICollection<Movie_Cast> Movie_Casts { get; set; } = new List<Movie_Cast>();

    public virtual ICollection<Movie_Hall> Movie_Halls { get; set; } = new List<Movie_Hall>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public ICollection<Schedule_Movie> Schedules_Movie { get; set; } = new List<Schedule_Movie>();
}
