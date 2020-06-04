using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DisaBioApp.Models;
using DisaBioApp.Views.Menu;

namespace DisaBioApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Settings:
                        // TODO Settings
                        MenuPages.Add(id, new NavigationPage(new SettingsPage()));
                        break;
                    case (int)MenuItemType.Search_Cinema:
                        // TODO Cinema
                        MenuPages.Add(id, new NavigationPage(new SearchCinemaPage()));
                        break;
                    case (int)MenuItemType.Search_Movie:
                        // TODO Search Movie
                        MenuPages.Add(id, new NavigationPage(new SearchMoviePage()));
                        break;
                    case (int)MenuItemType.Show_Orders:
                        // TODO Show Order
                        MenuPages.Add(id, new NavigationPage(new ShowOrdersPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}