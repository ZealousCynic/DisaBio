using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    public class CinemaRepository : Interface.ICinemaRepository<Cinema>
    {
        public bool Create(Cinema c)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "InsertCinema";
                dbcon.Cmd.CommandType = CommandType.StoredProcedure;

                dbcon.Cmd.Parameters.AddWithValue("Name", c.Name);
                dbcon.Cmd.Parameters.AddWithValue("PostalCode", c.Location.PostalCode);
                dbcon.Cmd.Parameters.AddWithValue("StreetName", c.Location.Address);
                dbcon.Cmd.Parameters.AddWithValue("Longitude", c.Gps.Longitude);
                dbcon.Cmd.Parameters.AddWithValue("Latitude", c.Gps.Latitude);

                dbcon.Cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int));
                dbcon.Cmd.Parameters["ReturnValue"].Direction = ParameterDirection.Output;


                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() > 0)
                {
                    //dbcon.Cmd.Parameters["ReturnValue"].Value.ToString();
                    return true;
                }
                
            }

            return false;
        }

        public string test()
        {
            return "abc";
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Cinema GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Cinema[] GetRange(int startRange, int endRange)
        {
            List<Cinema> cinemas = new List<Cinema>();

            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "GetCinema";
                dbcon.Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                dbcon.Connect();
                dbcon.Reader = dbcon.Cmd.ExecuteReader();

                if (dbcon.Reader.HasRows)
                {                    
                    while (dbcon.Reader.Read())
                    {
                        cinemas.Add(
                            new Cinema
                            {
                                ID = Convert.ToInt32(dbcon.Reader["ID"]),
                                Name = dbcon.Reader["CinemaName"].ToString(),
                                Gps = new Gps
                                {
                                    Latitude = Convert.ToDouble(dbcon.Reader["Latitude"]),
                                    Longitude = Convert.ToDouble(dbcon.Reader["Longitude"])
                                },
                                Location = new Location
                                {
                                    Address = dbcon.Reader["StreetName"].ToString(),
                                    PostalCode = Convert.ToInt32(dbcon.Reader["PostalCode"].ToString()),
                                    Province = dbcon.Reader["ProviceName"].ToString()
                                }
                            });
                    }

                }
            }
            return cinemas.ToArray();
        }

        public bool Update(int id, Cinema t)
        {
            throw new NotImplementedException();            
        }

        public void Dispose()
        {
        }
    }
}
