using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    interface IUserRepository<T> : IRepository<T>
    {
        T GetByEmail(string email);
    }
}
