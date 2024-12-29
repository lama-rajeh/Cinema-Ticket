using System;
using System.Collections.Generic;

namespace Domain;

public partial class Cast
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
}
