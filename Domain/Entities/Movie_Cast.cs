using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Movie_Cast
{
    public int CastId { get; set; }

    public int MovieId { get; set; }

    public int? Type { get; set; }

    public virtual Cast Cast { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Cast_Category? TypeNavigation { get; set; }
}
