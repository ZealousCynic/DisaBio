using DisaBioApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DisaBioApp.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            switch(Device.RuntimePlatform)
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