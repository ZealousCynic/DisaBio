using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DisaBioApp.ViewModels;


namespace DisaBioApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CinemaPage : ContentPage
    {
        CinemaViewModel viewModel;

        public CinemaPage()
        {
            InitializeComponent();            
            BindingContext = viewModel = new CinemaViewModel();
        }
    }
}