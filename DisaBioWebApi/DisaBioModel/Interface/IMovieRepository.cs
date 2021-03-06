﻿using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface IMovieRepository<T,J>: IRepository<T>
    {
        J[] ShowHallsDisplayingMovie(T t);
    }
}
