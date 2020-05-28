using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class CinemaHall : BaseEntity
    {
        // Attributes
        private int hallNumber;
        private Seat[,] seats;
        private MovieShow movieList;
        private string layoutURL;

        // Properties
        public int HallNumber { get => hallNumber; set => hallNumber = value; }
        public MovieShow MovieList { get => movieList; set => movieList = value; }
        public string LayoutURL { get => layoutURL; set => layoutURL = value; }
        internal Seat[,] Seats { get => seats; set => seats = value; }

        // Constructor
        public CinemaHall():base() { }

        public CinemaHall(int id,int hallNumber, MovieShow movieList, string layoutURL, Seat[,] seats):base(id)
        {
            HallNumber = hallNumber;
            MovieList = movieList;
            LayoutURL = layoutURL;
            Seats = seats;
        }
    }
}
