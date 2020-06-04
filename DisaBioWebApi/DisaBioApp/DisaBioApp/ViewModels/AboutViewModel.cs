using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using DisaBioModel.Model;

namespace DisaBioApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Cinema c = new Cinema();

            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}