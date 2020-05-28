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
        public Customer(int id, string firstname, string lastname, string email, string phoneNumber, string password, byte[] salt, bool pushNotifications, Cinema preferredCinema, Genre preferredGenre)
            : base(id, firstname, lastname, email, phoneNumber, password, salt) 
        {
            PushNotifications = pushNotifications;
            PreferredCinema = preferredCinema;
            PreferredGenre = preferredGenre;
        }

    }
}
