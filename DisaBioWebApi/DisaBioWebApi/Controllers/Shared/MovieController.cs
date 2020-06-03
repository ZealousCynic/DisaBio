using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DisaBioModel.Interface;
using DisaBioModel.Model;
using DisaBioWebApi.JsonSerializeHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisaBioWebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieRepository<Movie, CinemaHall> repository;

        public MovieController(IRepository<Movie> movieRepository)
        {
            if (movieRepository is IMovieRepository<Movie, CinemaHall>)
                repository = movieRepository as IMovieRepository<Movie, CinemaHall>;
        }

        // GET: api/Movie
        [HttpGet]
        [Route("[Action]/{startRange}/{endRange}")]
        public IEnumerable<Movie> GetMovies(int startRange, int endRange)
        {
            Movie[] movies = null;

            try
            {
                movies = repository.GetRange(startRange, endRange);
            }
            catch (Exception e)
            {
                // TODO log exceptions ?
                Debug.WriteLine(e);
            }
            return movies;
        }

        // GET: api/Movie/5
        [HttpGet]
        [Route("[Action]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Movie movie = repository.GetByID(id);
                int movieid = movie.ID;
                return Ok(movie);
            }
            catch (Exception e)
            {
                // TODO log exceptions ?
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IActionResult ShowHallsDisplayingMovie(int id)
        {
            try
            {
                Movie movie = new Movie();
                movie.ID = id;

                CinemaHall[] cinemaHalls = repository.ShowHallsDisplayingMovie(movie);

                return Ok(cinemaHalls);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Movie/CreateMovie
        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            try
            {
                if (repository.Create(movie))
                { return Ok(); }
                else
                { return BadRequest(); }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Movie/UpdateMovie
        [HttpPost]
        public IActionResult UpdateMovie([FromBody] MovieUpdate movieUpdate)
        {
            try
            {
                if (repository.Update(movieUpdate.ID, movieUpdate.Movie))
                { return Ok(); }
                else
                { return BadRequest(); }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
