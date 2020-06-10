using System;
using System.Collections.Generic;
using System.Text;
using DisaBioModel.Model;

namespace DisaBioApp.Dtos
{
    public class CinemaWithGpsDistance
    {
        public Cinema Cinema { get; set; }
        public double DistanceKM { get; set; }
    }
}
