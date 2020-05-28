using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    public class MovieRepository : Interface.IMovieRepository<Movie, CinemaHall>
    {
        public bool Create(Movie t)
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

        public Movie GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Movie[] GetRange(int startRange, int endRange)
        {
            throw new NotImplementedException();
        }

        public CinemaHall[] ShowHallsDisplayingMovie(Movie t)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Movie t)
        {
            throw new NotImplementedException();
        }
    }
}
