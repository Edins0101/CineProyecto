using System;
using System.Collections.Generic;

namespace CineProyecto.WebApi.Models.Db;

public partial class SalaCine
{
    public Guid IdSala { get; set; }

    public string? Name { get; set; }

    public bool? Estado { get; set; }
}
