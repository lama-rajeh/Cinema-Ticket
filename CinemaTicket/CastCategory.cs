using System;
using System.Collections.Generic;

namespace Domain;

public partial class CastCategory
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
}
