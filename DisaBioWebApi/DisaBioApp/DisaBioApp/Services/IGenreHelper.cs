using Android.App;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DisaBioApp.Services
{
    public interface IGenreHelper
    {
        Task<string> SelectGenre();
        //void OnActivityResult(int requestCode, Result resultCode, Intent data);
    }
}
