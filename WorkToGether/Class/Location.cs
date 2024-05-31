using System;
using System.Collections.Generic;

namespace WorkToGether.Class;

public partial class Location
{
    public int Id { get; set; }

    public int? TypeId { get; set; }

    public int PackId { get; set; }

    public int? UsersId { get; set; }

    public int? CategorieId { get; set; }

    public DateTime DateDeb { get; set; }

    public DateTime Datefin { get; set; }

    public int? NbUnite { get; set; }

    public string? Nom { get; set; }

    public int? Quantite { get; set; }

    public virtual Categorie? Categorie { get; set; }

    public virtual Pack Pack { get; set; } = null!;

    public virtual Type? Type { get; set; }

    public virtual ICollection<Unite> Unites { get; set; } = new List<Unite>();

    public virtual User? Users { get; set; }
}
