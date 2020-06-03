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

        // GET: api/Star
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Star/GetStarByID/5
        [HttpGet]
        [Route("GetStarByID/{id}")]
        public Star GetStarByID(int id)
        {
            return this.repository.GetByID(id);
        }

        // POST: api/Star
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Star/5
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
