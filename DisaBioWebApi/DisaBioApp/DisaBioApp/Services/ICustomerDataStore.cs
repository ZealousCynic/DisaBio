using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DisaBioApp.Services
{
    interface ICustomerDataStore<T> : IDataStore<T>
    {
        Task<T> Login(string email);
    }
}
