using System;
using System.Collections.Generic;

namespace CineProyecto.WebApi.Models.Db;

public partial class Pelicula
{
    public Guid IdPelicula { get; set; }

    public string? Name { get; set; }

    public int? Duracion { get; set; }
}
