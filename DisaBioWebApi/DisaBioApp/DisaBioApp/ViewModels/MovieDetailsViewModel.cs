using Android.Graphics;
using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioApp.ViewModels
{
    class MovieDetailsViewModel
    {
        public DisaBioModel.Model.Movie _movie;

        public MovieDetailsViewModel()
        {
            _movie = null;
        }

        public MovieDetailsViewModel(DisaBioModel.Model.Movie movie)
        {
            _movie = movie;
        }
    }
}
