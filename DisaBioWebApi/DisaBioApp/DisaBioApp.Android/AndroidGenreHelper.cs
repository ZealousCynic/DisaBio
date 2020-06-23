using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DisaBioApp.Droid;
using DisaBioApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidGenreHelper))]
namespace DisaBioApp.Droid
{
    class AndroidGenreHelper : IGenreHelper
    {
        public void OpenPage()
        {
            Forms.Context.StartActivity(new Intent(Forms.Context, typeof(Genre)));
        }
    }
}