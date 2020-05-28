using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    interface IRepository<T> : IDisposable
    {
        bool Create(T t);
        T GetByID(int id);
        T[] GetRange(int startRange, int endRange);
        bool Update(int id , T t);
        bool Delete(int id);
    }
}
