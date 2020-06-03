using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisaBioWebApi.JsonSerializeHelper
{
    public class MovieUpdate
    {
        // Attribute
        private int id;
        private Movie movie;

        // Properties
        public int ID { get => id; set => id = value; }
        public Movie Movie { get => movie; set => movie = value; }

        // Constructor
        public MovieUpdate() { }
        public MovieUpdate(int iD, Movie movie)
        {
            ID = iD;
            Movie = movie;
        }
    }
}
