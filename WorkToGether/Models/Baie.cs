using System;
using System.Collections.Generic;

namespace WorkToGether.Models;

public partial class Baie
{
    public int Id { get; set; }

    public int Capacite { get; set; }

    public bool? Statut { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
