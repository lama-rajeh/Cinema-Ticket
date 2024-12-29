
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Schedule
{
    public int Id { get; set; }
    public DateOnly? Year { get; set; }
    public int? Week { get; set; }
    public TimeOnly?FromTime { get; set; }
    public TimeOnly? ToTime { get; set; }
    public int? CinemaId { get; set; }
    public virtual Cinema? Cinema { get; set; }
    public bool? IsDeleted { get; set; } = false;
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? UpDateDate { get; set; }   
    public string? UpdateBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }

    public virtual ICollection<Movie>? Movies { get; set; } = new List<Movie>();
    public ICollection<Schedule_Movie> Schedules_Movie { get; set; } = new List<Schedule_Movie>();

}
