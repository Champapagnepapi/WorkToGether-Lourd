using System;
using System.Collections.Generic;

namespace WorkToGether.Models;

public partial class User
{
    public int Id { get; set; }

    public int? BaieId { get; set; }

    public string Email { get; set; } = null!;

    /// <summary>
    /// (DC2Type:json)
    /// </summary>
    public string Roles { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Numero { get; set; }

    public virtual Baie? Baie { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
