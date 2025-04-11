
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Response;

namespace CineProyecto.WebApi.Interfaces.Services
{
    public interface IPeliculasService
    {
        public Task<Response<Pelicula?>> Create(CreatePeliculaRequest model);

        public Task<Response<List<Pelicula?>>> Get();

        public Task<Response<Pelicula?>> Get(int id);

        public Task<Response<Pelicula>> Get(string name);

        public Task<Response<Pelicula?>> Update(int id,UpdatePeliculaRequest newPelicula);

        public Task<Response<Pelicula?>> Delete(int id);
    }
}
