using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Gps : BaseEntity
    {
        private double longitude;
        private double latitude;

        // Properties
        public double Longitude { get => longitude; set => longitude = value; }
        public double Latitude { get => latitude; set => latitude = value; }

        public Gps() : base() { }

        public Gps(int id, double longitude, double latitude) : base(id)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

    }
}
