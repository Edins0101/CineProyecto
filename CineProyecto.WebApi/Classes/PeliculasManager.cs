using System.Xml.Linq;
using CineProyecto.WebApi.Entities;
using CineProyecto.WebApi.Interfaces.Classes;
using CineProyecto.WebApi.Models.Requests.Peliculas;

namespace CineProyecto.WebApi.Classes
{
    public class PeliculasManager : IPeliculasManager
    {
        private readonly List<Pelicula> peliculas = [];

        public Pelicula Create(Pelicula pelicula)
        {
            peliculas.Add(pelicula);
            return pelicula;
        }

        public Pelicula? Delete(int id)
        {

            var pelicula = peliculas.Find((pelicula) => pelicula.Id == id);

            if (pelicula != null)
            {
                peliculas.Remove(pelicula);

            }
            return pelicula;


        }

        public Pelicula? Get(int id)
        {
            var pelicula = peliculas.Find((pelicula) => pelicula.Id == id);

            return pelicula;
        }

        public List<Pelicula> Get()
        {
            return peliculas;
        }

        public Pelicula? Get(string name)
        {
            var pelicula = peliculas.Find((pelicula) => pelicula.Name == name);

            return pelicula;
        }

        public Pelicula Put(Pelicula pelicula)
        {
            int a = peliculas.FindIndex(p => p.Id == pelicula.Id) ;
            peliculas[a] = pelicula;

            return pelicula;
        }
    }
}
