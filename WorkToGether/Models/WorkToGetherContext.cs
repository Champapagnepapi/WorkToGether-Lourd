using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkToGether.Models;

public partial class WorkToGetherContext : DbContext
{
    public WorkToGetherContext()
    {
    }

    public WorkToGetherContext(DbContextOptions<WorkToGetherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baie> Baies { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<DoctrineMigrationVersion> DoctrineMigrationVersions { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<MessengerMessage> MessengerMessages { get; set; }

    public virtual DbSet<Pack> Packs { get; set; }

    public virtual DbSet<Type> Types { get; set; }

    public virtual DbSet<Unite> Unites { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=WorkToGether;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Baie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__baie__3213E83F6F3F396D");

            entity.ToTable("baie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacite).HasColumnName("capacite");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Statut).HasColumnName("statut");
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83FFEC39D1E");

            entity.ToTable("categorie");

            entity.HasIndex(e => e.UniteId, "IDX_497DD634EC4A74AB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.UniteId).HasColumnName("unite_id");

            entity.HasOne(d => d.Unite).WithMany(p => p.Categories)
                .HasForeignKey(d => d.UniteId)
                .HasConstraintName("FK_497DD634EC4A74AB");
        });

        modelBuilder.Entity<DoctrineMigrationVersion>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK__doctrine__79B5C94CF323CA44");

            entity.ToTable("doctrine_migration_versions");

            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasColumnName("version");
            entity.Property(e => e.ExecutedAt)
                .HasPrecision(6)
                .HasColumnName("executed_at");
            entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__location__3213E83F0E08761F");

            entity.ToTable("location");

            entity.HasIndex(e => e.PackId, "IDX_5E9E89CB1919B217");

            entity.HasIndex(e => e.UsersId, "IDX_5E9E89CB67B3B43D");

            entity.HasIndex(e => e.CategorieId, "IDX_5E9E89CBBCF5E72D");

            entity.HasIndex(e => e.TypeId, "IDX_5E9E89CBC54C8C93");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategorieId).HasColumnName("categorie_id");
            entity.Property(e => e.DateDeb)
                .HasPrecision(6)
                .HasColumnName("date_deb");
            entity.Property(e => e.Datefin)
                .HasPrecision(6)
                .HasColumnName("datefin");
            entity.Property(e => e.NbUnite).HasColumnName("nb_unite");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.PackId).HasColumnName("pack_id");
            entity.Property(e => e.Quantite).HasColumnName("quantite");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.Categorie).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CategorieId)
                .HasConstraintName("FK_5E9E89CBBCF5E72D");

            entity.HasOne(d => d.Pack).WithMany(p => p.Locations)
                .HasForeignKey(d => d.PackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_5E9E89CB1919B217");

            entity.HasOne(d => d.Type).WithMany(p => p.Locations)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_5E9E89CBC54C8C93");

            entity.HasOne(d => d.Users).WithMany(p => p.Locations)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("FK_5E9E89CB67B3B43D");
        });

        modelBuilder.Entity<MessengerMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__messenge__3213E83F6B66AD01");

            entity.ToTable("messenger_messages");

            entity.HasIndex(e => e.DeliveredAt, "IDX_75EA56E016BA31DB");

            entity.HasIndex(e => e.AvailableAt, "IDX_75EA56E0E3BD61CE");

            entity.HasIndex(e => e.QueueName, "IDX_75EA56E0FB7336F0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("available_at");
            entity.Property(e => e.Body)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("created_at");
            entity.Property(e => e.DeliveredAt)
                .HasPrecision(6)
                .HasComment("(DC2Type:datetime_immutable)")
                .HasColumnName("delivered_at");
            entity.Property(e => e.Headers)
                .IsUnicode(false)
                .HasColumnName("headers");
            entity.Property(e => e.QueueName)
                .HasMaxLength(190)
                .HasColumnName("queue_name");
        });

        modelBuilder.Entity<Pack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pack__3213E83F509B92A0");

            entity.ToTable("pack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.NombreEmplacement).HasColumnName("nombre_emplacement");
            entity.Property(e => e.PicturePath)
                .HasMaxLength(255)
                .HasColumnName("picture_path");
            entity.Property(e => e.Prix)
                .HasColumnType("numeric(10, 5)")
                .HasColumnName("prix");
            entity.Property(e => e.Reduction).HasColumnName("reduction");
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type__3213E83F0E6C85F0");

            entity.ToTable("type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Unite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unite__3213E83F6AFB7CB3");

            entity.ToTable("unite");

            entity.HasIndex(e => e.BaieId, "IDX_1D64C11843375062");

            entity.HasIndex(e => e.LocationId, "IDX_1D64C11864D218E");

            entity.HasIndex(e => e.TypeId, "IDX_1D64C118C54C8C93");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaieId).HasColumnName("baie_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Baie).WithMany(p => p.Unites)
                .HasForeignKey(d => d.BaieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_1D64C11843375062");

            entity.HasOne(d => d.Location).WithMany(p => p.Unites)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_1D64C11864D218E");

            entity.HasOne(d => d.Type).WithMany(p => p.Unites)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_1D64C118C54C8C93");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F7A1EEF89");

            entity.ToTable("user");

            entity.HasIndex(e => e.BaieId, "IDX_8D93D64943375062");

            entity.HasIndex(e => e.Email, "UNIQ_8D93D649E7927C74")
                .IsUnique()
                .HasFilter("([email] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaieId).HasColumnName("baie_id");
            entity.Property(e => e.Email)
                .HasMaxLength(180)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
            entity.Property(e => e.Numero)
                .HasMaxLength(255)
                .HasColumnName("numero");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(255)
                .HasColumnName("prenom");
            entity.Property(e => e.Roles)
                .IsUnicode(false)
                .HasComment("(DC2Type:json)")
                .HasColumnName("roles");

            entity.HasOne(d => d.Baie).WithMany(p => p.Users)
                .HasForeignKey(d => d.BaieId)
                .HasConstraintName("FK_8D93D64943375062");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
