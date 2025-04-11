using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CineProyecto.WebApi.Services
{
    public class PeliculasService(PostgresContext _DbContext) : IPeliculasService
    {

        public async Task<Response<Pelicula?>> Create(CreatePeliculaRequest data)
        {
            try
            {
                var pelicula = new Pelicula()
                {
                    Name = data.Name, 
                    Duracion = data.Duracion,

                }; 
                var result = await _DbContext.AddAsync(pelicula);
                await _DbContext.SaveChangesAsync();

                return new Response<Pelicula?>
                {
                    code = MessagesCode.Created,
                    message = "Película creada correctamente",
                    data = result.Entity
                };
            }
            catch (Exception ex)
            {
                return new Response<Pelicula?>
                {
                    code = MessagesCode.Error,
                    message = $"Error al crear la película: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<Response<Pelicula?>> Delete(int id)
        {

            var pelicula = await _DbContext.FindAsync<Pelicula>(id);

            if (pelicula == null)
            {
                return new Response<Pelicula?>
                {
                    code = MessagesCode.Error,
                    message = "Película no encontrada",
                    data = null
                };
            }

            _DbContext.Remove(pelicula);
            await _DbContext.SaveChangesAsync();

            return new Response<Pelicula?>
            {
                code = MessagesCode.Success,
                message = "Película eliminada correctamente",
                data = pelicula
            };
        }

        public async Task<Response<Pelicula?>> Get(int id)
        {
            var pelicula = await _DbContext.FindAsync<Pelicula>(id);

            if (pelicula == null)
            {
                return new Response<Pelicula?>
                {
                    code = MessagesCode.NotFound,
                    message = "No se encontro pelicula con es id",
                    data = null
                };
            }

            return new Response<Pelicula?>
            {
                code = MessagesCode.Success,
                message = "Busqueda con exito",
                data = pelicula
            }
            ;
        }

        public async Task<Response<List<Pelicula>>> Get()
        {
            var peliculas = await _DbContext.Peliculas.ToListAsync();

            if (peliculas == null || peliculas.Count == 0)
            {
                return new Response<List<Pelicula>>
                {
                    code = MessagesCode.NotFound,
                    message = "No existen peliculas",
                    data = peliculas = []
                };
            }
            return new Response<List<Pelicula>>
            {
                code = MessagesCode.Success,
                message = "Busqueda con exito",
                data = peliculas
            };
        }

        public async Task<Response<Pelicula?>> Get(string name)
        {
            var pelicula = await _DbContext.Peliculas
        .FirstOrDefaultAsync(p => p.Name == name);
            if (pelicula == null)
            {
                return new Response<Pelicula?>
                {
                    code = MessagesCode.NotFound,
                    message = "No se encontro pelicula con ese  nombre",
                    data = null
                };
            }
            return new Response<Pelicula?>
            {
                code = MessagesCode.Success,
                message = "Busqueda con exito",
                data = pelicula
            };
        }

        public async Task<Response<Pelicula?>> Update(int id, UpdatePeliculaRequest data)
        {
            try
            {
                var existingPelicula = await _DbContext.Peliculas.FindAsync(id);

                if (existingPelicula == null)
                {
                    return new Response<Pelicula?>
                    {
                        code = MessagesCode.NotFound,
                        message = "Película no encontrada",
                        data = null
                    };
                }

                existingPelicula.Name = data.Name;
                existingPelicula.Duracion = data.Duracion;

                _DbContext.Peliculas.Update(existingPelicula);
                await _DbContext.SaveChangesAsync();

                return new Response<Pelicula?>
                {
                    code = MessagesCode.Updated,
                    message = "Película actualizada correctamente",
                    data = existingPelicula
                };
            }
            catch (Exception ex)
            {
                return new Response<Pelicula?>
                {
                    code = MessagesCode.Error,
                    message = $"Error al actualizar la película: {ex.Message}",
                    data = null
                };
            }
        }
    }
}
