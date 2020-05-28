using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    interface IGenreRepository<T> : IRepository<T>
    {
        bool InsertMovieGenre(int movieID, Genre genre);
        bool DeleteMovieGenre(int genreID, int movieID);
        Genre[] GetMovieGenre(int movieID);
    }
}
