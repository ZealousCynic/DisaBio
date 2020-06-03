using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace DisaBioModel.Repository
{
    public class StarRepository : Interface.IStarRepository<Star>
    {

        /// <summary>
        /// Create a new Star
        /// </summary>
        /// <param name="t"> is the Star you want to create </param>
        /// <returns> returns true if created, false if not created </returns>
        public bool Create(Star t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "InsertStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@FirstName", t.Firstname);
                conn.Cmd.Parameters.AddWithValue("@Lastname", t.Firstname);
                conn.Cmd.Parameters.AddWithValue("@ImageUrl", t.ImageURL);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Delete a Star
        /// </summary>
        /// <param name="id"> is the id of star you want to delete </param>
        /// <returns> returns true if deleted, false if no star is found </returns>
        public bool Delete(int id)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "DeleteStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@StarID", id);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Delete a MovieStar
        /// </summary>
        /// <param name="starID"> is the ID of the Star you want to delete</param>
        /// <param name="movieID"> is the ID of the movie you want to delete a star from </param>
        /// <returns> returns true if star is deleted, returns false if no star is found </returns>
        public bool DeleteMovieStar(int starID, int movieID)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Connect();
                conn.Cmd.CommandText = "DeleteMovieStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@StarID", starID);
                conn.Cmd.Parameters.AddWithValue("@movieID", movieID);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            return false;
        }

        public void Dispose()
        {
        }

        /// <summary>
        /// Get Star by searching the for ID
        /// </summary>
        /// <param name="id"> is the ID of the star you want </param>
        /// <returns> returns the star if it is found, returns null if no star is found </returns>
        public Star GetByID(int id)
        {
            Star returnStar = new Star();

            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "GetStar";
                conn.Cmd.Parameters.AddWithValue("@StarID", id);


                using (conn.Reader = conn.Cmd.ExecuteReader())
                {
                    while (conn.Reader.Read())
                    {
                        returnStar.Firstname = conn.Reader.GetString(0);
                        returnStar.Lastname = conn.Reader.GetString(1);
                        returnStar.ImageURL = conn.Reader.GetString(2);
                    }
                }

            }
            return returnStar;

        }


        // startype
        /// <summary>
        /// Get movie star by seaching for the movieID
        /// </summary>
        /// <param name="movieID"> is the ID of the movie that you want stars from </param>
        /// <returns> returns movie stars if any is found, returns null is no movie stars is found </returns>
        public Star[] GetMovieStar(Movie movie)
        {
            List<Star> Stars = new List<Star>();
            int StarType = 2;

            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "GetMovieStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@MovieID", movie.ID);
                conn.Cmd.Parameters.AddWithValue("@StarType", StarType);

                using (conn.Reader = conn.Cmd.ExecuteReader())
                {
                    while (conn.Reader.Read())
                    {
                        Star Star = new Star();
                        Star.Firstname = conn.Reader.GetString(0);
                        Star.Lastname = conn.Reader.GetString(1);
                        Star.ImageURL = conn.Reader.GetString(2);
                        Star.ID = conn.Reader.GetInt32(3);

                        Stars.Add(Star);
                    }
                }

            }
            return Stars.ToArray();
        }

        public Star[] GetMovieDirector(Movie movie)
        {
            List<Star> Stars = new List<Star>();
            int StarType = 1;

            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "GetMovieStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@MovieID", movie.ID);
                conn.Cmd.Parameters.AddWithValue("@StarType", StarType);

                using (conn.Reader = conn.Cmd.ExecuteReader())
                {
                    while (conn.Reader.Read())
                    {
                        Star Star = new Star();
                        Star.Firstname = conn.Reader.GetString(0);
                        Star.Lastname = conn.Reader.GetString(1);
                        Star.ImageURL = conn.Reader.GetString(2);
                        Star.ID = conn.Reader.GetInt32(3);

                        Stars.Add(Star);
                    }
                }

            }
            return Stars.ToArray();
        }

        /// <summary>
        /// Get stars in a range of id's 
        /// </summary>
        /// <param name="startRange"> is the start number to range from </param>
        /// <param name="endRange"> is the end number to range to </param>
        /// <returns> returns stars if any is found, returns null is no stars is found </returns>
        public Star[] GetRange(int startRange, int endRange)
        {
            List<Star> Stars = new List<Star>();

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Connect();
                conn.Cmd.CommandText = "GetRangeStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@RangeStart", startRange);
                conn.Cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                using (conn.Reader = conn.Cmd.ExecuteReader())
                {

                    while (conn.Reader.Read())
                    {
                        Star Star = new Star();
                        Star.ID = conn.Reader.GetInt32(0);
                        Star.Firstname = conn.Reader.GetString(1);
                        Star.Lastname = conn.Reader.GetString(2);
                        Star.ImageURL = conn.Reader.GetString(3);

                        Stars.Add(Star);
                    }
                }

            }
            return Stars.ToArray();

        }

        /// <summary>
        /// insert a MovieStar
        /// </summary>
        /// <param name="movieID"> is the ID of the movie </param>
        /// <param name="star"> is the star that is to be inserted </param>
        /// <returns> return true if inserted, return false if not </returns>
        public bool InsertMovieStar(int movieID, Star star)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "MovieStarInsert";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@MovieID", movieID);
                conn.Cmd.Parameters.AddWithValue("@FirstName", star.Firstname);
                conn.Cmd.Parameters.AddWithValue("@Lastname", star.Lastname);
                conn.Cmd.Parameters.AddWithValue("@ImageUrl", star.ImageURL);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Update the information of a Star
        /// </summary>
        /// <param name="id"> is the ID of the star that is to be updated </param>
        /// <param name="t"> is the Star information that is to be updated</param>
        /// <returns> returns true if updated, returns false if not</returns>
        public bool Update(int id, Star t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {

                conn.Connect();
                conn.Cmd.CommandText = "UpdateStar";
                conn.Cmd.CommandType = CommandType.StoredProcedure;

                conn.Cmd.Parameters.AddWithValue("@ID", id);
                conn.Cmd.Parameters.AddWithValue("@FirsName", t.Firstname);
                conn.Cmd.Parameters.AddWithValue("@Lastname", t.Lastname);
                conn.Cmd.Parameters.AddWithValue("@ImageUrl", t.ImageURL);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
