using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    class Seat : BaseEntity
    {
        // Attributes
        private int row;
        private int number;
        private SeatStatus status;
        private SeatType seatType;
        private float priceModification;


        // Properties
        public int Row { get => row; set => row = value; }
        public int Number { get => number; set => number = value; }
        public SeatStatus Status { get => status; set => status = value; }
        public SeatType SeatType { get => seatType; set => seatType = value; }
        public float PriceModification { get => priceModification; set => priceModification = value; }

        // Constructor
        public Seat():base() { }

        public Seat(int id,int row, int number, SeatStatus status, SeatType seatType, float priceModification):base(id)
        {
            Row = row;
            Number = number;
            Status = status;
            SeatType = seatType;
            PriceModification = priceModification;
        }
    }
}
