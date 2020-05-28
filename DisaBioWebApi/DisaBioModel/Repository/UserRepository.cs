using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Repository
{
    class UserRepository : Interface.IUserRepository<User>
    {
        public bool Create(User u)
        {
            using(DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "InsertUser";

                dbcon.Cmd.Parameters.AddWithValue("FirstName", u.Firstname);
                dbcon.Cmd.Parameters.AddWithValue("LastName", u.Lastname);
                dbcon.Cmd.Parameters.AddWithValue("Email", u.Email);
                dbcon.Cmd.Parameters.AddWithValue("PhoneNumber", u.PhoneNumber);
                dbcon.Cmd.Parameters.AddWithValue("RoleID", u.RoleID);
                dbcon.Cmd.Parameters.AddWithValue("Password", u.Password);
                dbcon.Cmd.Parameters.AddWithValue("Salt", u.Salt);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() == 1)
                    return true;

            }
            return false;
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
            User toReturn = null;

            using(DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "GetByNameUser";

                dbcon.Cmd.Parameters.AddWithValue("Email", name);

                dbcon.Reader = dbcon.Cmd.ExecuteReader();

                if (dbcon.Reader.HasRows)
                {
                    string salt = (string)dbcon.Reader.GetValue(6);
                    byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

                    /*
                     * 0 = ID
                     * 1 = FirstName
                     * 2 = LastName
                     * 3 = Email
                     * 4 = PhoneNumber
                     * 5 = Password
                     * 6 = RoleID
                     * saltbytes = salt
                     */
                    toReturn = new User(
                        (int)dbcon.Reader.GetValue(0),
                        (string)dbcon.Reader.GetValue(1),
                        (string)dbcon.Reader.GetValue(2),
                        (string)dbcon.Reader.GetValue(3),
                        (string)dbcon.Reader.GetValue(4),
                        (string)dbcon.Reader.GetValue(5),
                        (int)dbcon.Reader.GetValue(6),
                        saltBytes
                        );
                }
            }

            return toReturn;
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
