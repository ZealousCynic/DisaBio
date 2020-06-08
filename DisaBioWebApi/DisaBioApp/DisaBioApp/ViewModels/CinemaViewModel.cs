using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisaBioModel.Model;
using Xamarin.Forms;

namespace DisaBioApp.ViewModels
{
    public class CinemaViewModel : BaseViewModel
    {
        public ObservableCollection<Cinema> Items { get; set; }
        public ObservableCollection<Cinema> SearchItems { get; set; }

        public Command LoadItemsCommand { get; set; }

        public CinemaViewModel()
        {
            Title = "Cinema List";
            Items = new ObservableCollection<Cinema>();
            SearchItems = new ObservableCollection<Cinema>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


            //Items = CinemaDataStore.GetItemsAsync(true);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            //try
            //{
                Items.Clear();
                SearchItems.Clear();
                var items = await CinemaDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                    SearchItems.Add(item);
                }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
            //finally
            //{
            //    IsBusy = false;
            //}
            IsBusy = false;
        }


        public void SearchItemsCommand(string queryString)
        {
            try
            {
                var normalizedQuery = queryString?.ToUpper() ?? "";
                SearchItems.Clear();
                var items = Items.Where(f => f.Name.ToUpper().Contains(normalizedQuery)).ToList();
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
