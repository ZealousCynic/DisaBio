using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DisaBioApp.ViewModels;
using PCLAppConfig;
using Xamarin.Essentials;

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

            //Get gps coordinates;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    viewModel.CurrentLat = location.Latitude;
                    viewModel.CurrentLng = location.Longitude;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }


            await viewModel.ExecuteLoadItemsCommand();

        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchItemsCommand(e.NewTextValue);
        }

    }
}