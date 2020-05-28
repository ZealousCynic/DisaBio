using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Employee : User
    {
        // Constructor
        public Employee() : base() { }
        public Employee(int id, string firstname, string lastname, string email, string phoneNumber, string password, int roleID, byte[] salt)
            : base(id, firstname, lastname, email, phoneNumber, password, roleID, salt) { }

        // Methods
        public bool ValidateTicket()
        {
            // TODO: ValidateTicket 
            throw new NotImplementedException();
        }
    }
}
