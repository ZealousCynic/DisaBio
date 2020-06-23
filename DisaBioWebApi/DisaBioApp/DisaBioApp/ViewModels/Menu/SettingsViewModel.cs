using Android.App;
using DisaBioApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DisaBioApp.ViewModels.Menu
{
    public class SettingsViewModel : BaseViewModel
    {
        // Constructors
        public SettingsViewModel()
        {
            Title = "Indstillinger";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    throw new NotSupportedException();
                case Device.Android:
                    DependencyService.Get<IGenreHelper>().OpenPage();
                    break;
                default:
                    break;

            }
        }
    }
}
