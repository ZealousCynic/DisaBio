using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using DisaBioApp.Models;
using DisaBioModel.Model;


namespace DisaBioApp.Services
{
    public class CinemaDataStore : IDataStore<Cinema>
    {
        public List<Cinema> items;

        public CinemaDataStore()
        {
            items = new List<Cinema>();
            //{
            //    new Cinema { ID = 1, Name = "Biografen 1"},
            //    new Cinema { ID = 2, Name = "Biografen 2"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "TestBiografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"},
            //    new Cinema { ID = 3, Name = "Biografen 3"}
            //};
        }



        public async Task<bool> AddItemAsync(Cinema item)
        {            

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Cinema item)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<Cinema> GetItemAsync(int id)
        {            
            return await Task.FromResult(items.FirstOrDefault(s => s.ID.ToString() == id.ToString()));

        }

        public async Task<IEnumerable<Cinema>> GetItemsAsync(bool forceRefresh = false)
        {
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
                    items = (List<Cinema>)deseralizer.ReadObject(ms);// 
                }
            }
            else
            {

            }

            return await Task.FromResult(items);

        }
    }
}
