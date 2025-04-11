using Microsoft.EntityFrameworkCore;

namespace CineProyecto.WebApi.Models.Db;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<PeliculaSalacine> PeliculaSalacines { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("peliculas_pkey");

            entity.ToTable("peliculas");

            entity.Property(e => e.IdPelicula)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id_pelicula");
            entity.Property(e => e.Duracion).HasColumnName("duracion");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PeliculaSalacine>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pelicula_salacine");

            entity.Property(e => e.FechaFin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");
            entity.Property(e => e.IdPeliculaSala)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id_pelicula_sala");
            entity.Property(e => e.IdSalaCine).HasColumnName("id_sala_cine");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany()
                .HasForeignKey(d => d.IdPelicula)
                .HasConstraintName("pelicula_salacine_id_pelicula_fkey");

            entity.HasOne(d => d.IdSalaCineNavigation).WithMany()
                .HasForeignKey(d => d.IdSalaCine)
                .HasConstraintName("pelicula_salacine_id_sala_cine_fkey");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("sala_cine_pkey");

            entity.ToTable("sala_cine");

            entity.Property(e => e.IdSala)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id_sala");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
