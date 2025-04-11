using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CineProyecto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController(IPeliculasService _peliculasService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Response<List<Pelicula>>>> Get()
        {
            var response = await _peliculasService.Get();
            return StatusCode(response.code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Pelicula?>>> Get(int id)
        {
            var response = await _peliculasService.Get(id);
            return StatusCode(response.code, response);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Response<Pelicula?>>> Get(string name)
        {
            var response = await _peliculasService.Get(name);
            return StatusCode(response.code, response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<Pelicula?>>> Post([FromBody] CreatePeliculaRequest model)
        {
            var response = await _peliculasService.Create(model);
            return StatusCode(response.code, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Pelicula?>>> Put(int id, [FromBody] UpdatePeliculaRequest model)
        {
            var response = await _peliculasService.Update(id, model);
            return StatusCode(response.code, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Pelicula?>>> Delete(int id)
        {
            var response = await _peliculasService.Delete(id);
            return StatusCode(response.code, response);
        }
    }
}
