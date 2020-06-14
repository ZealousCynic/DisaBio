using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DisaBioApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            string token = Application.Current.Properties["fcm_token"].ToString();
            DisaBioApp.AppConstants.SubscriptionTags = new string[] { "1111111101", "11111111102" };

            string regID = Xamarin.Forms.Application.Current.Properties["fcm_regID"].ToString();
            string templateRegID = Xamarin.Forms.Application.Current.Properties["fcm_templateRegID"].ToString();

            //Xamarin.Forms.Forms.Context
            //MainActivity.InstanceCount;
            //Android.App.Application.Context
            //DependencyService.Get<IFirebaseService>().UpdateTags(token);
            tokenDisplay.Text = token;
            regIDDisplay.Text = regID;
            templateRegIDDisplay.Text = templateRegID;
            //fcm_templateRegID
        }

        public void AddMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (messageDisplay.Children.OfType<Label>().Where(c => c.Text == message).Any())
                {
                    // Do nothing, an identical message already exists
                }
                else
                {
                    Label label = new Label()
                    {
                        Text = message,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.Start
                    };
                    messageDisplay.Children.Add(label);
                }
            });
        }
    }
}