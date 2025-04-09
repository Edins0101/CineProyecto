using CineProyecto.WebApi.Entities;
using CineProyecto.WebApi.Models.Requests.Peliculas;

namespace CineProyecto.WebApi.Interfaces.Services
{
    public interface IPeliculasService
    {
        public Pelicula Create(CreatePeliculaRequest model);

        public List<Pelicula>? Get();

        public Pelicula? GetById(int id);

        public Pelicula? GetByName(string name);

        public Pelicula Update(int id,UpdatePeliculaRequest newPelicula);

        public Pelicula Delete(int id);
    }
}
