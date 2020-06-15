using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisaBioModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Model;
using DisaBioModel.Interface;
using DisaBioWebApi.Cryptography;
using System.Text;

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

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            User toReturn = repository.GetByID(id);
            if (toReturn != null)
                return Ok(toReturn);
            else
                return BadRequest();
        }

        // POST: api/Customer/CreateUser
        [Route("[action]")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] User u)
        {
            Cryptography.EncryptionInitializer initializer = new Cryptography.EncryptionInitializer();

            CommonEncryption encryptor = initializer.GetAlgorithm("./keys/");
            

            byte[] plaintextbytes = Encoding.ASCII.GetBytes(u.Email);
            byte[] encrypted = encryptor.Encrypt(plaintextbytes);
            u.Email = Encoding.ASCII.GetString(encrypted);

            plaintextbytes = Encoding.ASCII.GetBytes(u.Password);
            encrypted = encryptor.Encrypt(plaintextbytes);
            u.Password = Encoding.ASCII.GetString(encrypted);

            if (repository.Create(u))
                return Ok();
            else
                return BadRequest();
        }

        [Route("[action]/{email}")]
        [HttpGet("{id}")]
        public IActionResult GetUser(string email)
        {
            User toReturn = repository.GetByEmail(email);
            if (toReturn != null)
                return Ok(toReturn);
            else
                return BadRequest();
        }

        // Definitely need authentication on this one.
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] User u)
        {
            if (repository.Delete(u.ID))
                return Ok();
            else
                return BadRequest();
        }
    }
}
