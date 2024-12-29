using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cast_Category
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Movie_Cast> Movie_Casts { get; set; } = new List<Movie_Cast>();
}
