using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class MovieShow : BaseEntity
    {
        // Attributess
        private Movie movie;
        private DateTime startTime;
        private DateTime endTime;
        private float priceModification;


        // Properties
        public DateTime StartTime { get => startTime; private set => startTime = value; }
        public DateTime EndTime { get => endTime; private set => endTime = value; }
        public float PriceModification { get => priceModification; }
        internal Movie Movie { get => movie; private set => movie = value; }

        // Constructor
        public MovieShow() : base() { }
        public MovieShow(int id, float priceModification, DateTime startTime, DateTime endTime, Movie movie) : base(id)
        {
            this.priceModification = priceModification;
            StartTime = startTime;
            EndTime = endTime;
            Movie = movie;
        }
    }
}
