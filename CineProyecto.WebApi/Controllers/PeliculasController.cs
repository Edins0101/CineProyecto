using CineProyecto.WebApi.Entities;
using CineProyecto.WebApi.Interfaces.Services;
using CineProyecto.WebApi.Models.Requests.Peliculas;
using CineProyecto.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineProyecto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController(IPeliculasService peliculasService) : ControllerBase
    {
        private readonly IPeliculasService _peliculasService = peliculasService; 

        // GET: api/<PeliculasController>
        [HttpGet]
        public List<Pelicula>? Get()
        {
            return _peliculasService.Get(); 
        }

        // GET api/<PeliculasController>/5
        [HttpGet("{id}")]
        public Pelicula? Get(int id)
        {
            return _peliculasService.GetById(id);
        }

        [HttpGet("name/{name}")]
        public Pelicula? Get(string name)
        {
            return _peliculasService.GetByName(name);
        }

        // POST api/<PeliculasController>
        [HttpPost]
        public Pelicula Post([FromBody] CreatePeliculaRequest model)
        {
            return _peliculasService.Create(model);
        }

        // PUT api/<PeliculasController>/5
        [HttpPut("{id}")]
        public Pelicula Put(int id, [FromBody] UpdatePeliculaRequest model)
        {
            return _peliculasService.Update(id, model);
        }

        // DELETE api/<PeliculasController>/5
        [HttpDelete("{id}")]
        public Pelicula Delete(int id)
        {
            return _peliculasService.Delete(id);
        }
    }
}
