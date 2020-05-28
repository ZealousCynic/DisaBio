using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    public class TicketRepository : Interface.ITicketRepository<Ticket>
    {
        public bool Create(Ticket t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket[] GetRange(int startRange, int endRange)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Ticket t)
        {
            throw new NotImplementedException();
        }
    }
}
