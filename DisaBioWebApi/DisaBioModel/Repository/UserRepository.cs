﻿using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    public class UserRepository : Interface.IUserRepository<User>
    {
        public bool Create(User u)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "InsertUser";

                dbcon.Cmd.Parameters.AddWithValue("@FirstName", u.Firstname);
                dbcon.Cmd.Parameters.AddWithValue("@LastName", u.Lastname);
                dbcon.Cmd.Parameters.AddWithValue("@Email", u.Email);
                dbcon.Cmd.Parameters.AddWithValue("@PhoneNumber", u.PhoneNumber);
                dbcon.Cmd.Parameters.AddWithValue("@RoleID", u.RoleID);
                dbcon.Cmd.Parameters.AddWithValue("@Password", u.Password);
                dbcon.Cmd.Parameters.AddWithValue("@Salt", Convert.ToBase64String(u.Salt));

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() == 1)
                    return true;

            }
            return false;
        }

        public bool Delete(int id)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "DeleteUser";

                dbcon.Cmd.Parameters.AddWithValue("@ID", id);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() == 1)
                    return true;
            }
            return false;
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(User u)
        {
            User toReturn = null;
            bool ret = false;
            SqlParameter returnparam = new SqlParameter();

            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "GetUserByEmail";

                dbcon.Cmd.Parameters.AddWithValue("@Email", u.Email);
                dbcon.Cmd.Parameters.AddWithValue("@Password", u.Password);

                dbcon.Cmd.Parameters.Add("@returnparam", System.Data.SqlDbType.Bit).Direction = System.Data.ParameterDirection.Output;

                dbcon.Connect();

                dbcon.Reader = dbcon.Cmd.ExecuteReader();

                ret = (bool)dbcon.Cmd.Parameters[2].Value;

                //if (dbcon.Reader.HasRows)
                //{
                //    dbcon.Reader.Read();                    

                //string salt = (string)dbcon.Reader.GetValue(8);
                //byte[] saltBytes = Encoding.ASCII.GetBytes(salt);


                ///*
                // * 0 = ID
                // * 1 = FirstName
                // * 2 = LastName
                // * 3 = Email
                // * 4 = PhoneNumber
                // * 5 = RoleID
                // * 7 = Password
                // * 8 = Salt = saltbytes
                // */
                //toReturn = new User(
                //    (int)dbcon.Reader.GetValue(0),
                //    (string)dbcon.Reader.GetValue(1),
                //    (string)dbcon.Reader.GetValue(2),
                //    (string)dbcon.Reader.GetValue(3),
                //    (string)dbcon.Reader.GetValue(4),
                //    (string)dbcon.Reader.GetValue(7),
                //    (int)dbcon.Reader.GetValue(5),
                //    saltBytes
                //    );
                //}
            }

            return ret;
        }

        public User[] GetRange(int startRange, int endRange)
        {
            User[] users = new User[endRange];

            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "GetRangeUser";

                dbcon.Cmd.Parameters.AddWithValue("@RangeStart", startRange);
                dbcon.Cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                dbcon.Connect();

                dbcon.Reader = dbcon.Cmd.ExecuteReader();

                int count = 0;

                if (dbcon.Reader.HasRows)
                    while (dbcon.Reader.Read())
                    {
                        string salt = (string)dbcon.Reader.GetValue(8);
                        byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

                        /*
                         * 0 = ID
                         * 1 = FirstName
                         * 2 = LastName
                         * 3 = Email
                         * 4 = PhoneNumber
                         * 5 = RoleID
                         * 7 = Password
                         * 8 = Salt = saltbytes
                         */
                        users[count] = new User(
                            (int)dbcon.Reader.GetValue(0),
                            (string)dbcon.Reader.GetValue(1),
                            (string)dbcon.Reader.GetValue(2),
                            (string)dbcon.Reader.GetValue(3),
                            (string)dbcon.Reader.GetValue(4),
                            (string)dbcon.Reader.GetValue(7),
                            (int)dbcon.Reader.GetValue(5),
                            saltBytes
                            );

                        count++;
                    }
            }

            return users;
        }

        public bool Update(int id, User t)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public string GetUserSalt(User u)
        {
            string salt = "Not Found";

            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "GetUserSalt";

                dbcon.Cmd.Parameters.AddWithValue("@Email", u.Email);

                dbcon.Connect();

                dbcon.Reader = dbcon.Cmd.ExecuteReader();

                if (dbcon.Reader.HasRows)
                {
                    dbcon.Reader.Read();

                    salt = (string)dbcon.Reader.GetValue(0);
                }

            }

            return salt;
        }
    }
}
