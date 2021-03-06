﻿using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface IStarRepository<T>:IRepository<T>
    {
        bool InsertMovieStar(int movieID, Star star);

        bool DeleteMovieStar(int starID, int movieID);

        Star[] GetMovieStar(Movie movie);

        Star[] GetMovieDirector(Movie movie);
    }
}
