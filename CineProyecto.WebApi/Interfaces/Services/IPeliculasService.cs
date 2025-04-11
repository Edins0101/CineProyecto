
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Response;

namespace CineProyecto.WebApi.Interfaces.Services
{
    public interface IPeliculasService
    {
        public Task<Response<Pelicula?>> Create(CreatePeliculaRequest model);

        public Task<Response<List<Pelicula?>>> Get();

        public Task<Response<Pelicula?>> Get(string id);

        public Task<Response<Pelicula>> GetByName(string name);

        public Task<Response<Pelicula?>> Update(string id,UpdatePeliculaRequest newPelicula);

        public Task<Response<Pelicula?>> Delete(string id);
    }
}
