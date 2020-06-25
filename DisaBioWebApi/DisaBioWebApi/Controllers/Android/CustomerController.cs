using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisaBioModel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Model;
using DisaBioModel.Interface;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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
        // How to require specific authorization?
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserByID(int id)
        {
            User toReturn = repository.GetByID(id);
            if (toReturn != null)
                return Ok(toReturn);
            else
                return BadRequest();
        }

        // POST: api/Customer/CreateUser
        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] User u)
        {
            DisaBioModel.Cryptography.EncryptionInitializer initializer = new DisaBioModel.Cryptography.EncryptionInitializer();
            DisaBioModel.Cryptography.CommonEncryption encryptor = initializer.GetAlgorithm("./keys/");

            DisaBioModel.Cryptography.HashGenerator hashgen = new DisaBioModel.Cryptography.HashGenerator();

            byte[] saltbytes = hashgen.GetSalt(16);
            u.Salt = saltbytes;

            byte[] hashed = hashgen.ComputeIteratedHash(u.Password, u.Salt);
            byte[] encrypted = encryptor.Encrypt(hashed);
            u.Password = Encoding.ASCII.GetString(encrypted);

            if (repository.Create(u))
                return Ok();
            else
                return BadRequest();
        }

        // Definitely need authentication on this one.
        // DELETE: api/ApiWithActions/5
        [Authorize]
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
