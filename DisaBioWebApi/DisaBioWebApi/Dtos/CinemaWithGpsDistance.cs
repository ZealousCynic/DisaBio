using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using DisaBioModel.Model;

namespace DisaBioWebApi.Dtos
{
    public class CinemaWithGpsDistance
    {
        public Cinema Cinema { get; set; }
        public double DistanceKM { get; set; }
    }
}
