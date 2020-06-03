using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Model;
using DisaBioModel.Interface;
using DisaBioModel.Repository;

namespace DisaBioWebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {
        private IStarRepository<Star> repository;

        public StarController(IRepository<Star> starRepository)
        {
            if (starRepository is IStarRepository<Star>)
                repository = starRepository as IStarRepository<Star>;
        }

        // GET: api/Star/GetStarByID/5
        [HttpGet]
        [Route("GetStarByID/{id}")]
        public Star GetStarByID(int id)
        {
            return repository.GetByID(id);
        }

        // GET: api/MovieStar
        [HttpGet]
        public Star[] GetMovieStar(Movie movie)
        {
            return repository.GetMovieStar(movie);
        }

        // GET: api/MovieDirector
        [HttpGet]
        public Star[] GetMovieDirector(Movie movie)
        {
            return repository.GetMovieDirector(movie);
        }

        // POST: api/Star
        [HttpPost]
        public IActionResult InsertStar([FromBody] Star star)
        {
            if (repository.Create(star))
            { 
                return Ok(); 
            }
            else
            { 
                return BadRequest(); 
            }
        }

        // POST: api/MovieStar
        [HttpPost]
        public IActionResult InsertMovieStar([FromBody]Movie movie, Star star)
        {
            if (repository.InsertMovieStar(movie.ID, star))
            { 
                return Ok(); 
            }
            else
            { 
                return BadRequest(); 
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovieStar([FromBody] Movie movie, [FromBody] Star star)
        {
            if (repository.DeleteMovieStar(movie.ID, star.ID))
                return Ok();
            else
                return BadRequest();
        }
    }
}
