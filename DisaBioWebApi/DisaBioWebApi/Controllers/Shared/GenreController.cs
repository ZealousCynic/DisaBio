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

        [HttpGet("{id}")]
        [Route("[action]")]
        public Genre[] GetMovieGenre(Movie m)
        {
            return repository.GetMovieGenre(m.ID);
        }

        [HttpGet("{id}")]
        [Route("[action]")]
        public Genre[] GetGenres()
        {
            return repository.GetGenres();
        }

        // POST: api/Genre
        [HttpPost]
        [Route("[action]")]
        public IActionResult InsertMovieGenre([FromBody] Genre g, int movieID)
        {
            if (repository.InsertMovieGenre(movieID, g))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGenreFromMovie([FromBody] Genre g, int movieID)
        {
            if (repository.DeleteMovieGenre(g.ID, movieID))
                return Ok();
            else
                return BadRequest();
        }
    }
}
