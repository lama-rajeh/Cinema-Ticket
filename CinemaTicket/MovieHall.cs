using System;
using System.Collections.Generic;

namespace Domain;

public partial class MovieHall
{
    public int Id { get; set; }

    public int? HallId { get; set; }

    public int? MovieId { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Hall? Hall { get; set; }

    public virtual Movie? Movie { get; set; }
}
