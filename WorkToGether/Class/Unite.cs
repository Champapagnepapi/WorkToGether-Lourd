using System;
using System.Collections.Generic;

namespace WorkToGether.Class;

public partial class Unite
{
    public int Id { get; set; }

    public int BaieId { get; set; }

    public int? TypeId { get; set; }

    public int? LocationId { get; set; }

    public virtual Baie Baie { get; set; } = null!;

    public virtual ICollection<Categorie> Categories { get; set; } = new List<Categorie>();

    public virtual Location? Location { get; set; }

    public virtual Type? Type { get; set; }
}
