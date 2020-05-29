using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    public class StarRepository : Interface.IStarRepository<Star>
    {
        public bool Create(Star t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("InsertStar"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", t.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", t.Firstname);
                    cmd.Parameters.AddWithValue("@ImageUrl", t.ImageURL);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DeleteStar"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StarID", id);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DeleteMovieStar(int starID, int movieID)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DeleteMovieStar"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StarID", starID);
                    cmd.Parameters.AddWithValue("@movieID", movieID);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Star GetByID(int id)
        {
            Star returnStar = new Star();

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetStar"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StarID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnStar.ID = reader.GetInt32(0);
                            returnStar.Firstname = reader.GetString(1);
                            returnStar.Lastname = reader.GetString(2);
                            returnStar.ImageURL = reader.GetString(3);
                        }
                    }
                }
            }
            return returnStar;
        }

        public Star[] GetRange(int startRange, int endRange)
        {
            List<Star> Stars = new List<Star>();

            using (SqlCommand cmd = new SqlCommand("GetRangeStar"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RangeStart", startRange);
                cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Star Star = new Star();
                        Star.ID = reader.GetInt32(0);
                        Star.Firstname = reader.GetString(1);
                        Star.Lastname = reader.GetString(2);
                        Star.ImageURL = reader.GetString(3);

                        Stars.Add(Star);
                    }
                }
            }

            return Stars.ToArray();
        }

        public bool Update(int id, Star t)
        {
            throw new NotImplementedException();
        }

    }
}
