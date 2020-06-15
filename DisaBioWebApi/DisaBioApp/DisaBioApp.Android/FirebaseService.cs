using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;
using System;
using System.Linq;
using WindowsAzure.Messaging;
using Xamarin.Forms;
using DisaBioApp.Droid;
using DisaBioApp.Services;
using Plugin.CurrentActivity;
using System.Threading.Tasks;

[assembly: Dependency(typeof(FirebaseService))]
namespace DisaBioApp.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseService : FirebaseMessagingService, IFirebaseService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            string messageBody = string.Empty;

            if (message.GetNotification() != null)
            {
                messageBody = message.GetNotification().Body;
            }

            // NOTE: test messages sent via the Azure portal will be received here
            else
            {
                messageBody = message.Data.Values.First();
            }

            // convert the incoming message to a local notification
            SendLocalNotification(messageBody);

            // send the incoming message directly to the MainPage
            SendMessageToMainPage(messageBody);
        }

        public override void OnNewToken(string token)
        {
            // TODO: save token instance locally, or log if desired


            Xamarin.Forms.Application.Current.Properties["fcm_token"] = token;
            Xamarin.Forms.Application.Current.SavePropertiesAsync();

            SendRegistrationToServer(token, this);
        }

        void SendLocalNotification(string body)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("message", body);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, AppConstants.NotificationChannelName)
                .SetContentTitle("DisaBio Beskeder")
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetContentText(body)
                .SetAutoCancel(true)
                .SetShowWhen(false)
                .SetContentIntent(pendingIntent);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                notificationBuilder.SetChannelId(AppConstants.NotificationChannelName);
            }

            var notificationManager = NotificationManager.FromContext(this);
            notificationManager.Notify(0, notificationBuilder.Build());
        }

        void SendMessageToMainPage(string body)
        {
            //(App.Current.MainPage as MainPage)?.AddMessage(body);
        }

        public void SendRegistrationToServer(string token, Context context)
        {
            try
            {
                NotificationHub hub = new NotificationHub(AppConstants.NotificationHubName, AppConstants.ListenConnectionString, this);

                //CrossCurrentActivity.Current.Init(this);  CrossCurrentActivity.Current.Activity
                // register device with Azure Notification Hub using the token from FCM                
                Registration registration = hub.Register(token, AppConstants.SubscriptionTags);

                var regID = registration.RegistrationId;
                Xamarin.Forms.Application.Current.Properties["fcm_regID"] = regID.ToString();
                Xamarin.Forms.Application.Current.SavePropertiesAsync();


                // subscribe to the SubscriptionTags list with a simple template.
                string pnsHandle = registration.PNSHandle;
                TemplateRegistration templateReg = hub.RegisterTemplate(pnsHandle, "defaultTemplate", AppConstants.FCMTemplateBody, AppConstants.SubscriptionTags);

                var templateRegID = templateReg.RegistrationId;
                Xamarin.Forms.Application.Current.Properties["fcm_templateRegID"] = templateRegID.ToString();
                Xamarin.Forms.Application.Current.SavePropertiesAsync();
            }
            catch (Exception e)
            {
                Log.Error(AppConstants.DebugTag, $"Error registering device: {e.Message}");
            }
        }

    }
}