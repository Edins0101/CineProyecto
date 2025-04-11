using CineProyecto.WebApi.Models.Db;

namespace CineProyecto.WebApi.Models.Response
{
    public class SalaPeliculaResponse
    {
        public string idSala { get; set; } = string.Empty;
        public List<Pelicula> peliculas { get; set; } = [];
    }
}
