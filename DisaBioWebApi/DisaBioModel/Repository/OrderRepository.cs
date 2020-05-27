using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    class OrderRepository : Interface.IOrderRepository<Order>
    {
        public bool Create(Order t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Order[] GetRange(int range)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Order t)
        {
            throw new NotImplementedException();
        }
    }
}
