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

        // GET: api/Genre
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "genre get";
        }

        // POST: api/Genre
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
