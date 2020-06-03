using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class User : BaseEntity
    {
        // Attributes
        private string firstname;
        private string lastname;
        private string email;
        private string phoneNumber;
        private string password;
        private int roleID;
        private byte[] salt;

        // Properties
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Password { get => password; set => password = value; }
        public int RoleID { get => roleID; set => roleID = value; }
        public byte[] Salt { get => salt; set => salt = value; }

        // Constructor
        public User() : base() { }
        public User(int id, string firstname, string lastname, string email, string phoneNumber, string password, int roleID, byte[] salt) : base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            RoleID = roleID;
            Salt = salt;
        }
    }
}
