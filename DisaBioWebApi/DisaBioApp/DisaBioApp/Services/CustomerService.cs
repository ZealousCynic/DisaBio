using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DisaBioApp.Services
{
    [Service(Name = "com.DisaBio.CustomerService")]
    class CustomerService : Service
    {
        public readonly string TAG = typeof(CustomerService).FullName;


        public IBinder Binder { get; private set; }


        public override IBinder OnBind(Intent intent)
        {
            base.OnCreate();
            Log.Debug(TAG, "OnBind");
            if (this.Binder == null)
                this.Binder = new CustomerBinder(this);

            return this.Binder;
        }

        public override bool OnUnbind(Intent intent)
        {
            // This method is optional to implement
            Log.Debug(TAG, "OnUnbind");
            return base.OnUnbind(intent);
        }

        public override void OnDestroy()
        {
            // This method is optional to implement
            Log.Debug(TAG, "OnDestroy");
            Binder = null;
            base.OnDestroy();
        }

        public string GetTime()
        {
            return DateTime.Now.ToString();
        }

        public async Task<IEnumerable<Customer>> GetItemsAsync(bool forceRefresh = false)
        {
            List<Customer> items = new List<Customer>();

            HttpClient client = new HttpClient();

            var uri = new Uri("http://10.108.130.72:8088/api/cinema");
            HttpResponseMessage response = null;
            response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var returnContent = await response.Content.ReadAsStringAsync();
                //List<Cinema> items = JsonSerializer.Deserialize<List<RestaurantPlatformMobileApp.Entities.Menu>>(returnContent);


                List<Cinema> obj = Activator.CreateInstance<List<Cinema>>();
                MemoryStream ms1 = new MemoryStream(Encoding.Unicode.GetBytes(returnContent));
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                obj = (List<Cinema>)serializer.ReadObject(ms1);
                ms1.Close();
                ms1.Dispose();

                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(returnContent)))
                {
                    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<Cinema>));
                    //Student model = (Student)deseralizer.ReadObject(ms);//
                    items = (List<Customer>)deseralizer.ReadObject(ms);// 
                }
            }
            else
            {

            }

            return await Task.FromResult(items);

        }
    }
}
