using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    public class MovieRepository : Interface.IMovieRepository<Movie, CinemaHall>
    {
        /// <summary>
        /// Create a new movie
        /// </summary>
        /// <param name="t">The movie you want to create</param>
        /// <returns>true if it is created</returns>
        public bool Create(Movie t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Cmd.CommandText = "InsertMovie";
                
                conn.Cmd.Parameters.AddWithValue("@Title", t.Title);
                conn.Cmd.Parameters.AddWithValue("@Decription", t.Description);
                conn.Cmd.Parameters.AddWithValue("@ReleaseDate", t.ReleasDate.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                conn.Cmd.Parameters.AddWithValue("@PlayTimer", t.PlayTime);
                conn.Cmd.Parameters.AddWithValue("@BasePrice", 2);
                conn.Cmd.Parameters.AddWithValue("@Archived", 1);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id">The movie id you want to delete</param>
        /// <returns>true if it is deleted</returns>
        public bool Delete(int id)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Cmd.CommandText = "DeleteMovie";
                
                conn.Cmd.Parameters.AddWithValue("@ID", id);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a movie by id
        /// </summary>
        /// <param name="id">The movie id you want to get</param>
        /// <returns>the movie you wants to get</returns>
        /// <returns>null if nothing is found</returns>
        public Movie GetByID(int id)
        {
            Movie returnMovie = null;

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Cmd.CommandText = "GetMovie";
                
                conn.Cmd.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = conn.Cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        returnMovie = new Movie();
                        returnMovie.ID = reader.GetInt32(0);
                        returnMovie.Title = reader.GetString(1);
                        returnMovie.Description = reader.GetString(2);
                        returnMovie.ReleasDate = reader.GetDateTime(3);
                        returnMovie.PlayTime = reader.GetInt32(4);
                    }
                }
            }
            return returnMovie;
        }

        /// <summary>
        /// Get a range of movies
        /// </summary>
        /// <param name="startRange">id from where the range start</param>
        /// <param name="endRange">the range of the items you want</param>
        /// <returns>the movies you wants to get</returns>
        /// <returns>null if nothing is found</returns>
        public Movie[] GetRange(int startRange, int endRange)
        {
            List<Movie> returnMovies = null;

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Cmd.CommandText = "GetMovie";
                
                conn.Cmd.Parameters.AddWithValue("@RangeStart", startRange);
                conn.Cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                using (SqlDataReader reader = conn.Cmd.ExecuteReader())
                {
                    returnMovies = new List<Movie>();
                    Movie returnMovie = new Movie();
                    while (reader.Read())
                    {
                        returnMovie.ID = reader.GetInt32(0);
                        returnMovie.Title = reader.GetString(1);
                        returnMovie.Description = reader.GetString(2);
                        returnMovie.ReleasDate = reader.GetDateTime(3);
                        returnMovie.PlayTime = reader.GetInt32(4);

                        returnMovies.Add(returnMovie);
                    }
                }
            }
            return returnMovies.ToArray();
        }

        /// <summary>
        /// Get a list og moviehalls with id and hall number
        /// </summary>
        /// <param name="t">The movie you want to get</param>
        /// <returns>a list of CinemaHalls</returns>
        /// /// <returns>null if nothing is found</returns>
        public CinemaHall[] ShowHallsDisplayingMovie(Movie t)
        {
            List<CinemaHall> returnCinemaHalls = new List<CinemaHall>();

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Cmd.CommandText = "GetHallsDisplayingMovie";
                
                conn.Cmd.Parameters.AddWithValue("@MovieID", t.ID);

                using (SqlDataReader reader = conn.Cmd.ExecuteReader())
                {
                    CinemaHall returnCinemaHall = new CinemaHall();
                    while (reader.Read())
                    {
                        returnCinemaHall.ID = reader.GetInt32(0);
                        returnCinemaHall.HallNumber = reader.GetInt32(1);
                    }
                }
            }
            return returnCinemaHalls.ToArray();
        }

        /// <summary>
        /// Update a movie 
        /// </summary>
        /// <param name="id">id of the movie you want to update</param>
        /// <param name="t">the new movie information you want</param>
        /// <returns>true if it is updated</returns>
        public bool Update(int id, Movie t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                conn.Cmd.CommandText = "UpdateMovie";

                conn.Cmd.Parameters.AddWithValue("@ID", id);
                conn.Cmd.Parameters.AddWithValue("@Title", id);
                conn.Cmd.Parameters.AddWithValue("@Decription", id);
                conn.Cmd.Parameters.AddWithValue("@ReleaseDate", id);
                conn.Cmd.Parameters.AddWithValue("@PlayTimer", id);
                conn.Cmd.Parameters.AddWithValue("@BasePrice", id);
                conn.Cmd.Parameters.AddWithValue("@Archived", id);

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
