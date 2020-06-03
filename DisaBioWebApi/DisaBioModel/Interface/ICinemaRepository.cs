using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface ICinemaRepository<T>:IRepository<T>
    {
        bool CreateCinemaHall(int cinemaID, CinemaHall h);
        bool UpdateCinemaHall(CinemaHall h);
        bool DeleteCinemaHall(int id);
        CinemaHall[] GetCinemaHallsByCinemaID(int cinemaID);
    }
}
