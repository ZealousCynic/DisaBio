using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisaBioModel.Interface;
using DisaBioModel.Model;
using DisaBioModel.Repository;
using DisaBioWebApi.Dtos;

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
        }

        // GET: api/Cinema/GetCinemaByID/5
        [HttpGet]
        [Route("GetCinemaByID/{id}")]
        public Cinema GetCinemaByID(int id)
        {
            return this.repository.GetByID(id);
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
        [HttpPut]
        public IActionResult Put([FromBody] Cinema value)
        {
            if (value.ID < 0)
            {
                return BadRequest();
            }
            if (this.repository.Update(value.ID, value))
            { return Ok(); }
            else
            { return BadRequest(); }

        }

        // DELETE: api/Cinema/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (this.repository.Delete(id))
            { return Ok(); }
            else
            { return BadRequest(); }
        }


        // POST: api/Cinema/AddHall/15
        [HttpPost]
        [Route("AddHall/{cinemaID}")]
        public IActionResult Post([FromBody] CinemaHall value, int cinemaID)
        {
            if (this.repository.CreateCinemaHall(cinemaID, value))
            { return Ok(); }
            else
            { return BadRequest(); }
        }

        // GET: api/Cinema/GetHallByCinemaID/15
        [HttpGet]
        [Route("GetHallsByCinemaID/{cinemaID}")]
        public ResultCinemaHall[] Get(int cinemaID)
        {
            List<ResultCinemaHall> cinemaHalls = new List<ResultCinemaHall>();
            CinemaHall[] returnCinemaHall = this.repository.GetCinemaHallsByCinemaID(cinemaID);
            foreach (CinemaHall item in returnCinemaHall)
            {
                cinemaHalls.Add(
                    new ResultCinemaHall
                    {
                        ID = item.ID,
                        HallNumber = item.HallNumber,
                        LayoutID = item.LayoutID
                    });
            }
            return cinemaHalls.ToArray();
        }

        // DELETE: api/Cinema/DelHall/5
        [HttpDelete]
        [Route("DelHall/{cinemahallID}")]
        public IActionResult DeleteHall(int cinemahallID)
        {
            if (this.repository.DeleteCinemaHall(cinemahallID))
            { return Ok(); }
            else
            { return BadRequest(); }
        }

        // PUT: api/Cinema/UpdateHall
        [HttpPut]
        [Route("UpdateHall")]
        public IActionResult Put([FromBody] CinemaHall value)
        {
            if (value.ID < 0)
            {
                return BadRequest();
            }
            if (this.repository.UpdateCinemaHall(value))
            { return Ok(); }
            else
            { return BadRequest(); }
        }

        // GET: api/Cinema/GetNearestCinema/55.753790/12.520434
        [HttpGet]
        [Route("GetNearestCinema/{currentLat}/{currentLng}")]
        public Cinema GetNearestCinema(double currentLat, double currentLng)
        {
            Cinema[] cinemaArr = this.repository.GetRange(0, 0);
            if (cinemaArr.Length > 0)
            {
                Dictionary<int, double> distanceCinemaDic = new Dictionary<int, double>();

                double distance = 0;

                foreach (var item in cinemaArr)
                {
                    distance = DisaBioWebApi.Helper.CalculateGPSDistance.GetDistance(currentLat, currentLng, item.Gps.Longitude, item.Gps.Latitude);
                    distanceCinemaDic.Add(item.ID, distance);
                }
                int nearestCinemaID = distanceCinemaDic.OrderBy(dc => dc.Value).First().Key;
                return this.repository.GetByID(nearestCinemaID);
            }
            return null;
        }


        // GET: api/Cinema/GetCinemaListOrderByGpsDistance/55.753790/12.520434
        [HttpGet]
        [Route("GetCinemaListOrderByGpsDistance/{currentLat}/{currentLng}")]
        public CinemaWithGpsDistance[] GetCinemaListOrderByGpsDistance(double currentLat, double currentLng)
        {
            Cinema[] cinemaArr = this.repository.GetRange(0, 0);
            List<CinemaWithGpsDistance> cinemaWithGpsDistance = new List<CinemaWithGpsDistance>();
            if (cinemaArr.Length > 0)
            {
                Dictionary<int, double> distanceCinemaDic = new Dictionary<int, double>();

                double distance = 0;

                foreach (var item in cinemaArr)
                {
                    distance = DisaBioWebApi.Helper.CalculateGPSDistance.GetDistance(currentLat, currentLng, item.Gps.Longitude, item.Gps.Latitude);
                    distanceCinemaDic.Add(item.ID, distance);
                }

                foreach (var item in distanceCinemaDic.OrderBy(dc => dc.Value))
                {
                    cinemaWithGpsDistance.Add(
                        new CinemaWithGpsDistance { 
                            Cinema = cinemaArr.FirstOrDefault(c => c.ID == item.Key), 
                            DistanceKM = item.Value 
                        });                    
                }

                //int nearestCinemaID = distanceCinemaDic.OrderBy(dc => dc.Value).First().Key;
                return cinemaWithGpsDistance.ToArray();
            }
            return null;
        }

    }
}
