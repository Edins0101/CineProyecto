using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Requests.SalaCine;
using CineProyecto.WebApi.Models.Response;

namespace CineProyecto.WebApi.Interfaces.Services
{
    public interface ISalaService
    {
        public Task<Response<SalaCine?>> Create(CreateSalaCine model);

        public Task<Response<List<SalaCine>>> Get();

        public Task<Response<SalaCine?>> Get(string id);

        public Task<Response<SalaCine?>> GetByName(string name);

        public Task<Response<SalaCine?>> Update(string id, UpdateSalaCine newPelicula);

        public Task<Response<SalaCine?>> Delete(string id);

        public Task<Response<SalaPeliculaResponse>> SetPeliculaSala(string id, List<Pelicula> peliculas);
        public Task<Response<SalaPeliculaResponse>> GetPeliculaSala(string id);
    }
}
