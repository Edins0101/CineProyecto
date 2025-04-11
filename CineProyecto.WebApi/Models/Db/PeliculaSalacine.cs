using System;
using System.Collections.Generic;

namespace CineProyecto.WebApi.Models.Db;

public partial class PeliculaSalacine
{
    public Guid? IdPeliculaSala { get; set; }

    public Guid? IdSalaCine { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public DateTime? FechaFin { get; set; }

    public Guid? IdPelicula { get; set; }

    public virtual Pelicula? IdPeliculaNavigation { get; set; }

    public virtual SalaCine? IdSalaCineNavigation { get; set; }
}
