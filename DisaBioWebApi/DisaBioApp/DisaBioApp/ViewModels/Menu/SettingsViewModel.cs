using Android.App;
using DisaBioApp.Services;
using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DisaBioApp.ViewModels.Menu
{
    public class SettingsViewModel : BaseViewModel
    {
        string genrename = "woop";
        public string GenreName
        {
            get { return genrename; }
            set {
                genrename = value; 
                base.OnPropertyChanged("GenreName");
            }
        }
        // Constructors
        public SettingsViewModel()
        {
            Title = "Indstillinger";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    throw new NotSupportedException();
                case Device.Android:
                    SelectGenreAsync();
                    break;
                default:
                    break;

            }
        }

        public async void SelectGenreAsync()
        {
            GenreName = await DependencyService.Get<IGenreHelper>().SelectGenre();

            DisaBioModel.Model.Genre prefferedGenre = new Genre { Name = GenreName };
        }
    }

}
