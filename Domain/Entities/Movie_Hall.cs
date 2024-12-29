using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Movie_Hall
{
  //  public int Id { get; set; }

    public int? HallId { get; set; }

    public int? MovieId { get; set; }

    public virtual Hall? Hall { get; set; }

    public virtual Movie? Movie { get; set; }
}
