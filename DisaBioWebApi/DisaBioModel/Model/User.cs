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

        public User(string email, string password) : base() { Email = email; Password = password; }

        /// <summary>
        /// Creates an incomplete User object. For use at the android end.
        /// Expects the web api to generate salt.
        /// Expects ID to be assigned by the database.
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        /// <param name="roleID"></param>
        public User(string firstname, string lastname, string email, string phoneNumber, string password, int roleID) : base()
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            RoleID = roleID;
        }

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
