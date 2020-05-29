﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Interface;
using DisaBioModel.Model;
using DisaBioModel.Repository;

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
        public Cinema[] Get()
        {
            return this.repository.GetRange(0, 0);            
            //return new string[] { repository.test().ToString(), "value2" };
        }

        // GET: api/Cinema/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cinema
        [HttpPost]
        public IActionResult Post([FromBody] Cinema value)
        {
            if (this.repository.Create(value))
            { return Ok(); }
            else
            { return BadRequest(); }            
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
