using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface ICinemaRepository<T>:IRepository<T>
    {
        bool CreateCinemaHall(CinemaHall t);
        bool UpdateCinemaHall(int id, CinemaHall t);
        bool DeleteCinemaHall(int id);
        CinemaHall[] GetCinemaHall(int cinemaID);


    }
}
