using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Requests.SalaCine;
using CineProyecto.WebApi.Models.Response;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CineProyecto.WebApi.Services
{
    public class SalaService(PostgresContext _DbContext) : ISalaService
    {
        public async Task<Response<SalaCine?>> Create(CreateSalaCine data)
        {
            try
            {
                var salaCine = new SalaCine()
                {
                    Name = data.Name,
                    Estado = true,

                };

                var result = await _DbContext.AddAsync(salaCine);
                await _DbContext.SaveChangesAsync();

                return new Response<SalaCine?>
                {
                    code = MessagesCode.Created,
                    message = "Película creada correctamente",
                    data = result.Entity
                };
            }
            catch (Exception ex)
            {
                return new Response<SalaCine?>
                {
                    code = MessagesCode.Error,
                    message = $"Error al crear la película: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<Response<SalaCine?>> Delete(string id)
        {
            try
            {
                var existingSalaCine = await _DbContext.SalaCines.FindAsync(id);

                if (existingSalaCine == null)
                {
                    return new Response<SalaCine?>
                    {
                        code = MessagesCode.NotFound,
                        message = "Película no encontrada",
                        data = null
                    };
                }

                existingSalaCine.Estado = !existingSalaCine.Estado;

                _DbContext.SalaCines.Update(existingSalaCine);
                await _DbContext.SaveChangesAsync();

                return new Response<SalaCine?>
                {
                    code = MessagesCode.Updated,
                    message = "Película actualizada correctamente",
                    data = existingSalaCine
                };
            }
            catch (Exception ex)
            {
                return new Response<SalaCine?>
                {
                    code = MessagesCode.Error,
                    message = $"Error al actualizar la película: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<Response<List<SalaCine>>> Get()
        {
            var salaCines = await _DbContext.SalaCines.ToListAsync();

            if (salaCines == null || salaCines.Count == 0)
            {
                return new Response<List<SalaCine>>
                {
                    code = MessagesCode.NotFound,
                    message = "No existen peliculas",
                    data = salaCines = []
                };
            }
            return new Response<List<SalaCine>>
            {
                code = MessagesCode.Success,
                message = "Busqueda con exito",
                data = salaCines
            };
        }

        public async Task<Response<SalaCine?>> Get(string id)
        {
            var salaCine = await _DbContext.FindAsync<SalaCine>(id);

            if (salaCine == null)
            {
                return new Response<SalaCine?>
                {
                    code = MessagesCode.NotFound,
                    message = "No se encontro pelicula con es id",
                    data = null
                };
            }

            return new Response<SalaCine?>
            {
                code = MessagesCode.Success,
                message = "Busqueda con exito",
                data = salaCine
            };
        }

        public async Task<Response<SalaCine?>> GetByName(string name)
        {
            var salaCine = await _DbContext.SalaCines
        .FirstOrDefaultAsync(p => p.Name == name);
            if (salaCine == null)
            {
                return new Response<SalaCine?>
                {
                    code = MessagesCode.NotFound,
                    message = "No se encontro pelicula con ese  nombre",
                    data = null
                };
            }
            return new Response<SalaCine?>
            {
                code = MessagesCode.Success,
                message = "Busqueda con exito",
                data = salaCine
            };
        }
        public async Task<Response<SalaCine?>> Update(string id, UpdateSalaCine data)
        {
            try
            {
                var existingSalaCine = await _DbContext.SalaCines.FindAsync(id);

                if (existingSalaCine == null)
                {
                    return new Response<SalaCine?>
                    {
                        code = MessagesCode.NotFound,
                        message = "Película no encontrada",
                        data = null
                    };
                }

                existingSalaCine.Name = data.Name;
                existingSalaCine.Estado = data.Estado;

                _DbContext.SalaCines.Update(existingSalaCine);
                await _DbContext.SaveChangesAsync();

                return new Response<SalaCine?>
                {
                    code = MessagesCode.Updated,
                    message = "Película actualizada correctamente",
                    data = existingSalaCine
                };
            }
            catch (Exception ex)
            {
                return new Response<SalaCine?>
                {
                    code = MessagesCode.Error,
                    message = $"Error al actualizar la película: {ex.Message}",
                    data = null
                };
            }
        }

        public async Task<Response<SalaPeliculaResponse>> SetPeliculaSala(string id, List<Pelicula> peliculas)
        {
            throw new NotImplementedException();
        }

        Task<Response<SalaPeliculaResponse>> ISalaService.GetPeliculaSala(string id)
        {
            throw new NotImplementedException();
        }
    }
}
