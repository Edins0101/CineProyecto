
using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Db;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Models.Requests.SalaCine;
using CineProyecto.WebApi.Models.Response;
using CineProyecto.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace CineProyecto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController(ISalaService _salaService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Response<List<SalaCine>>>> Get()
        {
            var response = await _salaService.Get();
            return StatusCode(response.code, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<SalaCine?>>> Get(string id)
        {
            var response = await _salaService.Get(id);
            return StatusCode(response.code, response);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Response<SalaCine?>>> GetByName(string name)
        {
            var response = await _salaService.GetByName(name);
            return StatusCode(response.code, response);
        }

        [HttpPost]
        public async Task<ActionResult<Response<Pelicula?>>> Post([FromBody] CreateSalaCine model)
        {
            var response = await _salaService.Create(model);
            return StatusCode(response.code, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Pelicula?>>> Put(string id, [FromBody] UpdateSalaCine model)
        {
            var response = await _salaService.Update(id, model);
            return StatusCode(response.code, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Pelicula?>>> Delete(string id)
        {
            var response = await _salaService.Delete(id);
            return StatusCode(response.code, response);
        }
    }
}
