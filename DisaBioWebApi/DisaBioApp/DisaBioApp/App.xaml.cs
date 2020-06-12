using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DisaBioApp.Services;
using DisaBioApp.Views;
using DisaBioApp.Dtos;
using DisaBioModel.Model;

namespace DisaBioApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CinemaDataStore>();
            //MainPage = new MainPage();
            //MainPage = new AboutPage();
            //MainPage = new UserSettingsPage();
            MainPage = new CinemaPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
