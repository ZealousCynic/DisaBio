﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class CinemaHall : BaseEntity
    {
        // Attributes
        private int hallNumber;
        private int layoutID;
        private List<MovieShow> movieShow;

        // Properties
        public int HallNumber { get => hallNumber; set => hallNumber = value; }
        public int LayoutID { get => layoutID; set => layoutID = value; }
        public List<MovieShow> MovieShowList { get => movieShow; set => movieShow = value; }

        // Constructor
        public CinemaHall():base() { }

        public CinemaHall(int id,int hallNumber, List<MovieShow> movieShowList):base(id)
        {
            HallNumber = hallNumber;
            MovieShowList = movieShowList;
            LayoutID = layoutID;
        }
    }
}
