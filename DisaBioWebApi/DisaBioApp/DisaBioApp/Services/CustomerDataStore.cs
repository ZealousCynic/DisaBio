using DisaBioApp.Dtos;
using DisaBioModel.Model;
using PCLAppConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DisaBioApp.Services
{
    class CustomerDataStore : ICustomerDataStore<Customer>
    {
        List<Customer> items;
        Customer customer;
        string url;

        public async Task<bool> AddItemAsync(Customer item)
        {
            url = ConfigurationManager.AppSettings["CreateUser"];

            HttpClient client = new HttpClient();
            var uri = new Uri(url);

            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Customer));

                serializer.WriteObject(ms, item);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                var body = new StringContent(sr.ReadToEnd(), Encoding.ASCII, "application/json");
                body.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync(uri, body);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Login(string email)
        {
            url = ConfigurationManager.AppSettings["Authenticate"];

            HttpClient client = new HttpClient();
            var uri = new Uri(url);
            HttpResponseMessage response = null;
            response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var returnContent = await response.Content.ReadAsStringAsync();

                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(returnContent)))
                {
                    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(Customer));
                    customer = (Customer)deseralizer.ReadObject(ms);// 
                }
            }
            else
            {

            }

            return await Task.FromResult(customer);
        }

        public Task<Customer> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetItemsAsync(bool forceRefresh = false, string webApiUrl = null)
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
                    DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(List<Customer>));
                    items = (List<Customer>)deseralizer.ReadObject(ms);// 
                }
            }
            else
            {

            }

            return await Task.FromResult(items);
        }

        public Task<bool> UpdateItemAsync(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
