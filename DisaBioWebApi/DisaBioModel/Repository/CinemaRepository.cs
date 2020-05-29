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

                if (dbcon.Cmd.ExecuteNonQuery() == 1)
                {
                    var xxx = dbcon.Cmd.Parameters["ReturnValue"].Value.ToString();                    

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
            throw new NotImplementedException();
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
