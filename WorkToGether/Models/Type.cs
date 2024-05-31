using System;
using System.Collections.Generic;

namespace WorkToGether.Models;

public partial class Type
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();
}
