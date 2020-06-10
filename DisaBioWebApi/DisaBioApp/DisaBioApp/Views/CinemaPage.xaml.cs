using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DisaBioApp.ViewModels;
using PCLAppConfig;

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


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(2000);
            CollectionCinemaView.ItemsSource = viewModel.SearchItems;
            await viewModel.ExecuteLoadItemsCommand();

        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchItemsCommand(e.NewTextValue);
        }

    }
}