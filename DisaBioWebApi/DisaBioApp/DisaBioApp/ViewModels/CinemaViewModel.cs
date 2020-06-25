using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisaBioModel.Model;
using DisaBioApp.Dtos;
using Xamarin.Forms;
using PCLAppConfig;
using System.Globalization;

namespace DisaBioApp.ViewModels
{
    public class CinemaViewModel : BaseViewModel
    {
        public ObservableCollection<CinemaWithGpsDistance> Items { get; set; }
        public ObservableCollection<CinemaWithGpsDistance> SearchItems { get; set; }

        public double CurrentLat = 0;

        public double CurrentLng = 0;
        public Command LoadItemsCommand { get; set; }

        public CinemaViewModel()
        {
            Title = "Cinema List";
            Items = new ObservableCollection<CinemaWithGpsDistance>();
            SearchItems = new ObservableCollection<CinemaWithGpsDistance>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var items = await CinemaDataStore.GetItemsAsync(
                    true, 
                    String.Format(
                        ConfigurationManager.AppSettings["WebApiCinemaGet"].ToString(),
                        CurrentLat.ToString("G", CultureInfo.InvariantCulture), 
                        CurrentLng.ToString("G", CultureInfo.InvariantCulture)
                        ));
                Items.Clear();
                SearchItems.Clear();
                foreach (var item in items)
                {
                    Items.Add(item);
                    SearchItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public void SearchItemsCommand(string queryString)
        {
            try
            {
                SearchItems.Clear();
                var normalizedQuery = queryString?.ToUpper() ?? "";
                var items = Items.Where(f => f.Cinema.Name.ToUpper().Contains(normalizedQuery)).ToList();
                foreach (var item in items)
                {
                    SearchItems.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
