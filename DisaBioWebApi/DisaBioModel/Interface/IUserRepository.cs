using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Interface
{
    public interface IUserRepository<T> : IRepository<T>
    {
        bool AuthenticateUser(User u);
        string GetUserSalt(User u);
    }
}
