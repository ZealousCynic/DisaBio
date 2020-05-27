using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    class UserRepository : Interface.IUserRepository<User>
    {
        public bool Create(User t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public User[] GetRange(int range)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, User t)
        {
            throw new NotImplementedException();
        }
    }
}
