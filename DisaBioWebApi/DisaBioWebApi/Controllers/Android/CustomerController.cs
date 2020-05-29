using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisaBioModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Model;
using DisaBioModel.Interface;

namespace DisaBioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IUserRepository<User> repository;

        public CustomerController(IRepository<User> userRepository)
        {
            if (userRepository is IUserRepository<User>)
                repository = userRepository as IUserRepository<User>;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "customer get";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // POST: api/Customer/CreateUser
        [HttpPost]
        public void CreateUser(User u)
        {
            repository.Create(u);
        }

        [Route("[action]/{email}")]
        [HttpGet("{id}")]
        public User GetUser(string email)
        {
            return repository.GetByEmail(email);
        }

        // PUT: api/Customer/5
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
