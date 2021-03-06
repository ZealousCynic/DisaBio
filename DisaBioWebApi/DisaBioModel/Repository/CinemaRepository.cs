﻿using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    public class CinemaRepository : Interface.ICinemaRepository<Cinema>
    {

        public IEnumerable<Cinema> Cinemas
        {
            get
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
                                        Province = dbcon.Reader["ProviceName"].ToString(),
                                        City = dbcon.Reader["CityName"].ToString()
                                    }
                                });
                        }

                    }
                }
                return cinemas;
            }
        }

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

        public bool Delete(int id)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "DeleteCinema";
                dbcon.Cmd.CommandType = CommandType.StoredProcedure;
                dbcon.Cmd.Parameters.AddWithValue("@CinemaID", id);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() > 0)
                {                    
                    return true;
                }
            }
            return false;            
        }

        public Cinema GetByID(int id)
        {
            return Cinemas.FirstOrDefault(c => c.ID == id);
        }

        /// <summary>
        /// Prototype method -- Just gets the IEnumerable<Cinema> property and returns it as .ToArray();
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public Cinema[] GetRange(int startRange, int endRange)
        {
            return Cinemas.ToArray();
        }

        public bool Update(int id, Cinema t)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "UpdateCinema";
                dbcon.Cmd.CommandType = CommandType.StoredProcedure;

                dbcon.Cmd.Parameters.AddWithValue("ID", t.ID);
                dbcon.Cmd.Parameters.AddWithValue("Name", t.Name);
                dbcon.Cmd.Parameters.AddWithValue("PostalCode", t.Location.PostalCode);
                dbcon.Cmd.Parameters.AddWithValue("StreetName", t.Location.Address);
                dbcon.Cmd.Parameters.AddWithValue("Longitude", t.Gps.Longitude);
                dbcon.Cmd.Parameters.AddWithValue("Latitude", t.Gps.Latitude);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void Dispose()
        {
        }

        public bool CreateCinemaHall(int cinemaID, CinemaHall h)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "InsertCinemaHall";
                dbcon.Cmd.CommandType = CommandType.StoredProcedure;

                dbcon.Cmd.Parameters.AddWithValue("CinemaID", cinemaID);
                dbcon.Cmd.Parameters.AddWithValue("HallNumber", h.HallNumber);
                dbcon.Cmd.Parameters.AddWithValue("LayoutID", h.LayoutID);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() > 0)
                {                    
                    return true;
                }
            }

            return false;
        }

        public bool UpdateCinemaHall(CinemaHall h)
        {

            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "UpdateCinemaHall";
                dbcon.Cmd.CommandType = CommandType.StoredProcedure;

                dbcon.Cmd.Parameters.AddWithValue("ID", h.ID);
                dbcon.Cmd.Parameters.AddWithValue("HallNumber", h.HallNumber);
                dbcon.Cmd.Parameters.AddWithValue("LayoutID", h.LayoutID);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool DeleteCinemaHall(int id)
        {
            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "DeleteCinemaHall";
                dbcon.Cmd.CommandType = CommandType.StoredProcedure;

                dbcon.Cmd.Parameters.AddWithValue("ID", id);

                dbcon.Connect();

                if (dbcon.Cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public CinemaHall[] GetCinemaHallsByCinemaID(int cinemaID)
        {
            List<CinemaHall> cinemaHalls = new List<CinemaHall>();

            using (DatabaseConnection dbcon = new DatabaseConnection())
            {
                dbcon.Cmd.CommandText = "GetCinemaHall";
                dbcon.Cmd.CommandType = System.Data.CommandType.StoredProcedure;

                dbcon.Cmd.Parameters.AddWithValue("CinemaID", cinemaID);

                dbcon.Connect();
                dbcon.Reader = dbcon.Cmd.ExecuteReader();

                if (dbcon.Reader.HasRows)
                {
                    while (dbcon.Reader.Read())
                    {
                        cinemaHalls.Add(
                            new CinemaHall
                            {
                                ID = Convert.ToInt32(dbcon.Reader["ID"]),
                                HallNumber = Convert.ToInt32(dbcon.Reader["HallNumber"]),
                                LayoutID = Convert.ToInt32(dbcon.Reader["LayoutID"]),
                                MovieShowList = null
                            });
                    }

                }
            }
            return cinemaHalls.ToArray();
        }

    }
}
