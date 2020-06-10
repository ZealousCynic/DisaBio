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
using DisaBioApp.Dtos;


namespace DisaBioApp.Services
{
    public class CinemaDataStore : IDataStore<CinemaWithGpsDistance>
    {
        public List<CinemaWithGpsDistance> items;

        public CinemaDataStore()
        {
            items = new List<CinemaWithGpsDistance>();
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
            //};
        }



        public async Task<bool> AddItemAsync(CinemaWithGpsDistance item)
        {            

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CinemaWithGpsDistance item)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<CinemaWithGpsDistance> GetItemAsync(int id)
        {            
            return await Task.FromResult(items.FirstOrDefault(s => s.Cinema.ID.ToString() == id.ToString()));

        }

        public async Task<IEnumerable<CinemaWithGpsDistance>> GetItemsAsync(bool forceRefresh = false, string webApiUrl = null)
        {
            HttpClient client = new HttpClient();                        
            var uri = new Uri(webApiUrl);
            HttpResponseMessage response = null;
            response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var returnContent = await response.Content.ReadAsStringAsync();

                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(returnContent)))
                {
                    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<CinemaWithGpsDistance>)); 
                    items = (List<CinemaWithGpsDistance>)deseralizer.ReadObject(ms);// 
                }
            }
            else
            {

            }

            return await Task.FromResult(items);

        }
    }
}
