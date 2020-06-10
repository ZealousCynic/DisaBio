using Android.OS;
using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioApp.Services
{
    class CustomerBinder : Binder
    {
        CustomerService service;
        public CustomerService Service { get; private set; }


        public CustomerBinder(CustomerService service)
        {
            this.service = service;
        }
    }
}
