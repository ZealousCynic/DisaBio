using DisaBioModel.Interface;
using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    public class LocationRepository : Interface.ILocationRepository<Location>
    {
        public bool Create(Location t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Location GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Location[] GetRange(int startRange, int endRange)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Location t)
        {
            throw new NotImplementedException();
        }
    }
}
