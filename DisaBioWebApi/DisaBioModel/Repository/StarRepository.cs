using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    public class StarRepository : Interface.IStarRepository<Star>
    {
        public bool Create(Star t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Star GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Star[] GetRange(int startRange, int endRange)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Star t)
        {
            throw new NotImplementedException();
        }
    }
}
