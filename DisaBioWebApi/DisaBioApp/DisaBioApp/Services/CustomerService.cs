using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace DisaBioApp.Services
{
    [Service(Name ="com.DisaBio.CustomerService")]
    class CustomerService : Service
    {
        public readonly string TAG = typeof(CustomerService).FullName;


        public IBinder Binder { get; private set; }


        public override IBinder OnBind(Intent intent)
        {
            base.OnCreate();
            Log.Debug(TAG, "OnBind");
            this.Binder = new CustomerBinder(this);

            return this.Binder;
        }
    }
}
