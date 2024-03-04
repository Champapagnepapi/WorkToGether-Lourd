using System;
using System.Collections.Generic;

namespace WorkToGether.DBLib.Class;

public partial class Unite
{
    public int Id { get; set; }

    public int BaieId { get; set; }

    public int TypeId { get; set; }

    public int LocationId { get; set; }

    public virtual Baie Baie { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;
}
