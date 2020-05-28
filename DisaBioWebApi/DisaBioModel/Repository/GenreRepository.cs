using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    class GenreRepository : Interface.IGenreRepository<Genre>
    {
        public bool Create(Genre t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Genre GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Genre[] GetRange(int startRange, int endRange)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Genre t)
        {
            throw new NotImplementedException();
        }
    }
}
