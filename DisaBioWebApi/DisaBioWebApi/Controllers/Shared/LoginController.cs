using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisaBioModel.Interface;
using DisaBioModel.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DisaBioWebApi.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserRepository<User> repository;
        IConfiguration _config;


        public LoginController(IRepository<User> userRepository, IConfiguration config)
        {
            if (userRepository is IUserRepository<User>)
                repository = userRepository as IUserRepository<User>;
            _config = config;
        }

        [HttpGet]
        [Route("[Action]")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] User u)
        {
            string salt = repository.GetUserSalt(u);

            DisaBioModel.Cryptography.EncryptionInitializer initializer = new DisaBioModel.Cryptography.EncryptionInitializer();
            DisaBioModel.Cryptography.CommonEncryption encryptor = initializer.GetAlgorithm("./keys/");

            DisaBioModel.Cryptography.HashGenerator hashgen = new DisaBioModel.Cryptography.HashGenerator();

            u.Salt = Convert.FromBase64String(salt);

            byte[] hashed = hashgen.ComputeIteratedHash(u.Password, u.Salt);
            byte[] encrypted = encryptor.Encrypt(hashed);
            u.Password = Encoding.ASCII.GetString(encrypted);

            bool status = repository.AuthenticateUser(u);
            // Token code?

            if (status)
            {
                Helper.JwtTokenGenerator jwtgen = new Helper.JwtTokenGenerator(_config);

                var tokenstring = jwtgen.GenerateJSONWebToken(u);
                u.Token = tokenstring;

                return Ok(u);
            }
            else
                return Unauthorized();
        }
    }
}
