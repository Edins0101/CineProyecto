using CineProyecto.WebApi.Entities;
using CineProyecto.WebApi.Models.Requests.Peliculas;

namespace CineProyecto.WebApi.Interfaces.Classes
{
    public interface IPeliculasManager
    {
        public Pelicula Create(Pelicula pelicula);
        public Pelicula? Get(int id);
        public Pelicula? Get(string name);
        public List<Pelicula> Get();
        public Pelicula Put(Pelicula pelicula);
        public Pelicula? Delete(int id);
    }
}
