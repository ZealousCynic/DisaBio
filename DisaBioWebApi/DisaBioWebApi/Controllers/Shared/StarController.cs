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
        public IActionResult GetStarByID(int id)
        {
            Star toReturn = repository.GetByID(id);
            if (toReturn != null)
                return Ok(toReturn);
            else
                return BadRequest();
        }

        // GET: api/MovieStar
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetMovieStar([FromBody] Movie movie)
        {
            Star[] toReturn = repository.GetMovieStar(movie);
            if (toReturn != null)
                return Ok(toReturn);
            else
                return BadRequest();
        }

        // GET: api/MovieDirector
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetMovieDirector([FromBody] Movie movie)
        {
            Star[] toReturn = repository.GetMovieDirector(movie);
            if (toReturn != null)
                return Ok(toReturn);
            else
                return BadRequest();
        }

        // POST: api/Star
        [HttpPost]
        [Route("[Action]")]
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
        [Route("[Action]/{movieID}")]
        public IActionResult InsertMovieStar([FromBody] Star star, int movieID)
        {
            if (repository.InsertMovieStar(movieID, star))
            { 
                return Ok(); 
            }
            else
            { 
                return BadRequest(); 
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("[Action]/{starID}")]
        public IActionResult DeleteMovieStar([FromBody] Movie movie, int starID)
        {
            if (repository.DeleteMovieStar(movie.ID, starID))
                return Ok();
            else
                return BadRequest();
        }
    }
}
