using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Order:BaseEntity
    {
        // Attributes
        private List<Ticket> tickets;
        private User user;


        // Properties
        public User User { get => user; set => user = value; }
        public List<Ticket> Tickets { get => tickets; set => tickets = value; }

        // Constructor
        public Order(int id,User user, List<Ticket> tickets):base(id)
        {
            User = user;
            Tickets = tickets;
        }

    }
}
