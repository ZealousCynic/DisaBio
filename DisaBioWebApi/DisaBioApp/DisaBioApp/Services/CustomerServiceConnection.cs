using System;
using System.Collections.Generic;
using System.Text;
using Android.Util;
using Android.OS;
using Android.Content;
using Android.App;

namespace DisaBioApp.Services
{
    class CustomerServiceConnection
    {
        static readonly string TAG = typeof(CustomerServiceConnection).FullName;

        public CustomerServiceConnection()
        {
            IsConnected = false;
            Binder = null;

        }

        public bool IsConnected { get; private set; }
        public CustomerBinder Binder { get; private set; }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            Binder = service as CustomerBinder;
            IsConnected = this.Binder != null;

            string message = "onServiceConnected - ";
            Log.Debug(TAG, $"OnServiceConnected {name.ClassName}");

            if (IsConnected)
            {
                message = message + " bound to service " + name.ClassName;
                
            }
            else
            {
                message = message + " not bound to service " + name.ClassName;
            }

            Log.Info(TAG, message);

        }

        public void OnServiceDisconnected(ComponentName name)
        {
            Log.Debug(TAG, $"OnServiceDisconnected {name.ClassName}");
            IsConnected = false;
            Binder = null;
        }

        public string GetFormattedTimestamp()
        {
            if (!IsConnected)
            {
                return null;
            }

            return Binder?.Service.GetTime();
        }
    }
}
