using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Manager : Employee
    {
        // Constructor
        public Manager() : base() { }
        public Manager(int id, string firstname, string lastname, string email, string phoneNumber, string password, byte[] salt) : base(id, firstname, lastname, email, phoneNumber, password, salt) { }
    }
}
