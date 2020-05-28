using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface IUserRepository<T> : IRepository<T>
    {
        T GetByName(string name);
    }
}
