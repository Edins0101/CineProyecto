namespace CineProyecto.WebApi.Models.Requests.Peliculas
{
    public class CreatePeliculaRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Duracion { get; set; }
    }
}
