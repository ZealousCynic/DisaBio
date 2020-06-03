using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisaBioModel.Interface;
using DisaBioModel.Model;
using DisaBioModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisaBioWebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private GenreRepository repository;

        public GenreController(IRepository<Genre> genreRepository)
        {
            if (genreRepository is GenreRepository)
                repository = genreRepository as GenreRepository;
            else
                repository = new GenreRepository();
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public Genre[] GetMovieGenre(Movie m)
        {
            return repository.GetMovieGenre(m.ID);
        }

        // POST: api/Genre
        [HttpPost]
        public IActionResult InsertMovieGenre([FromBody] Movie m, Genre g)
        {
            if (repository.InsertMovieGenre(m.ID, g))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Movie m, [FromBody] Genre g)
        {
            if (repository.DeleteMovieGenre(g.ID, m.ID))
                return Ok();
            else
                return BadRequest();
        }
    }
}
