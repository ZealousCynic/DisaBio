using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    public class Customer : User
    {
        // Attributes
        private bool pushNotifications;
        private Cinema preferredCinema;
        private Genre preferredGenre;

        // Properties
        public bool PushNotifications { get => pushNotifications; set => pushNotifications = value; }
        public Cinema PreferredCinema { get => preferredCinema; set => preferredCinema = value; }
        public Genre PreferredGenre { get => preferredGenre; set => preferredGenre = value; }


        // Constructor
        public Customer() { }

        public Customer(string email, string password) : base(email, password) { }

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
        public Customer(string firstname, string lastname, string email, string phoneNumber, string password, int roleID) : base(firstname, lastname, email, phoneNumber, password, roleID)
        {

        }

        public Customer(int id, string firstname, string lastname, string email, string phoneNumber, string password, int roleID, byte[] salt, bool pushNotifications, Cinema preferredCinema, Genre preferredGenre)
            : base(id, firstname, lastname, email, phoneNumber, password, roleID, salt) 
        {
            PushNotifications = pushNotifications;
            PreferredCinema = preferredCinema;
            PreferredGenre = preferredGenre;
        }

    }
}
