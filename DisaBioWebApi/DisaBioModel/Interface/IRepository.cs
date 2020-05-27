using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    interface IRepository<T>
    {
        bool Create(T t);
        T GetByID(int id);
        T[] GetRange(int range);
        bool Update(int id , T t);
        bool Delete(int id);
    }
}
