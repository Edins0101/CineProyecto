using CineProyecto.WebApi.Entities;
using CineProyecto.WebApi.Interfaces.Classes;
using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Requests.Peliculas;

namespace CineProyecto.WebApi.Services
{
    public class PeliculasService(IPeliculasManager peliculasManager) : IPeliculasService
    {
        private readonly IPeliculasManager _peliculasManager = peliculasManager;

        public Pelicula Create(CreatePeliculaRequest model)
        {
            var pelicula = _peliculasManager.Create(new Pelicula
            {
                Id = _peliculasManager.Get().Count + 1,
                Name = model.Name,
                Url = model.Url,
                CreatedAt = DateTime.UtcNow,
            });

            return pelicula;

        }
        public List<Pelicula>? Get()
        {
            var peliculas = _peliculasManager.Get();

            if (peliculas == null)
            {
                return peliculas = [];
            }

            return peliculas;
        }
        public Pelicula? GetById(int id)
        {
            var pelicula = _peliculasManager.Get(id);

            return pelicula;
        }
        public Pelicula? GetByName(string name)
        {
            var pelicula = _peliculasManager.Get(name);

            return pelicula;
        }

        public Pelicula Update(int id,UpdatePeliculaRequest model)
        {
            var oldPelicula = _peliculasManager.Get(id);

            var newPelicula = _peliculasManager.Put(new Pelicula
            {
                Id = oldPelicula.Id,
                Name = model.Name,
                Url = model.Url,
                CreatedAt = DateTime.UtcNow,
            });

            return newPelicula;
        }
        public Pelicula Delete(int id)
        {
            var pelicula = _peliculasManager.Delete(id);

            return pelicula;

        }
    }
}
