using System;
using System.Collections.Generic;

namespace Domain;

public partial class MovieCast
{
    public int CastId { get; set; }

    public int MovieId { get; set; }

    public int? Type { get; set; }

    public virtual Cast Cast { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual CastCategory? TypeNavigation { get; set; }
}
