using System;
using System.Collections.Generic;

namespace WorkToGether.Models;

public partial class Pack
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int NombreEmplacement { get; set; }

    public decimal Prix { get; set; }

    public double? Reduction { get; set; }

    public string? PicturePath { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
