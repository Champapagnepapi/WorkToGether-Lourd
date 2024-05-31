using System;
using System.Collections.Generic;

namespace WorkToGether.Models;

public partial class Categorie
{
    public int Id { get; set; }

    public int? UniteId { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual Unite? Unite { get; set; }
}
