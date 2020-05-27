using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    class Ticket : BaseEntity
    {
        // Attributes
        private Guid ticketId;
        private float ticketPrice;


        // Properties
        public Guid TicketId { get => ticketId; private set => ticketId = value; }
        public float TicketPrice { get => ticketPrice; private set => ticketPrice = value; }

        // Constructor
        public Ticket():base() { }

        public Ticket(int id,Guid ticketId, float ticketPrice):base(id)
        {
            TicketId = ticketId;
            TicketPrice = ticketPrice;
        }
    }
}
