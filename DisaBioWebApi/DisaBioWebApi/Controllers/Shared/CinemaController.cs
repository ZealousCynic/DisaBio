using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Repository;
using DisaBioModel.Interface;
using DisaBioModel.Model;


namespace DisaBioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {        
        private ICinemaRepository<Cinema> repository;

        public CinemaController(ICinemaRepository<Cinema> _cinemaRepository)
        {            
            this.repository = _cinemaRepository;
        }

        // GET: api/Cinema
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { this.repository.test().ToString(), "value2" };
        }

        //GET: api/Cinema/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cinema
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cinema/5
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
