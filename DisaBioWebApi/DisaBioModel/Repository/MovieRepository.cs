using DisaBioModel.Interface;
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

                // open db connection
                conn.Connect();

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

                // open db connection
                conn.Connect();

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public void Dispose()
        {
            // Dispose This Thing
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

                conn.Cmd.Parameters.AddWithValue("@MovieID", id);

                // open db connection
                conn.Connect();

                using (conn.Reader = conn.Cmd.ExecuteReader())
                {
                    while (conn.Reader.HasRows)
                    {
                        while (conn.Reader.Read())
                        {
                            returnMovie = new Movie();

                            returnMovie.ID = conn.Reader.GetInt32(0);
                            returnMovie.Title = conn.Reader.GetString(1);
                            returnMovie.Description = conn.Reader.GetString(2);
                            returnMovie.ReleasDate = conn.Reader.GetDateTime(3);
                            returnMovie.PlayTime = conn.Reader.GetInt32(4);
                        }
                        conn.Reader.NextResult();
                        // move assets from the second result set
                        conn.Reader.NextResult();
                        if (conn.Reader.HasRows)
                        {
                            while (conn.Reader.Read())
                            {
                                switch (conn.Reader.GetInt32(1))
                                {
                                    case 1:

                                        returnMovie.ImageUrl.Add(conn.Reader.GetString(0));
                                        break;

                                    case 2:

                                        returnMovie.TrailorUrl.Add(conn.Reader.GetString(0));
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }

                // get the movies starts from StarRepository
                using (IStarRepository<Star> repository = new StarRepository())
                {
                    returnMovie.Actors = new List<Star>(repository.GetMovieStar(returnMovie));
                    returnMovie.Director = new List<Star>(repository.GetMovieDirector(returnMovie));
                }

                // movie genre from GenreRepository
                using (IGenreRepository<Genre> repository = new GenreRepository())
                {
                    returnMovie.Genre = new List<Genre>(repository.GetMovieGenre(returnMovie.ID));
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
                conn.Cmd.CommandText = "[dbo].[GetRangeMovie]";

                conn.Cmd.Parameters.AddWithValue("@RangeStart", startRange);
                conn.Cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                // open db connection
                conn.Connect();

                // get the movies from the database
                returnMovies = GetMoviesSql(conn);

                // get the movies starts from StarRepository
                using (IStarRepository<Star> repository = new StarRepository())
                {
                    foreach (Movie movie in returnMovies)
                    {
                        movie.Actors = new List<Star>(repository.GetMovieStar(movie));
                        movie.Director = new List<Star>(repository.GetMovieDirector(movie));
                    }
                }

                // movie genre from GenreRepository
                using (IGenreRepository<Genre> repository = new GenreRepository())
                {
                    foreach (Movie movie in returnMovies)
                    {
                        movie.Genre = new List<Genre>(repository.GetMovieGenre(movie.ID));
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

                // open db connection
                conn.Connect();
                using (conn.Reader = conn.Cmd.ExecuteReader())
                {
                    CinemaHall returnCinemaHall = new CinemaHall();
                    while (conn.Reader.Read())
                    {
                        returnCinemaHall.ID = conn.Reader.GetInt32(0);
                        returnCinemaHall.HallNumber = conn.Reader.GetInt32(1);
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
                conn.Cmd.Parameters.AddWithValue("@Title", t.Title);
                conn.Cmd.Parameters.AddWithValue("@Decription", t.Description);
                conn.Cmd.Parameters.AddWithValue("@ReleaseDate", t.ReleasDate.ToString("YYYY-MM-DD HH:MM:SS"));
                conn.Cmd.Parameters.AddWithValue("@PlayTimer", t.PlayTime);
                conn.Cmd.Parameters.AddWithValue("@BasePrice", 2);
                conn.Cmd.Parameters.AddWithValue("@Archived", 0);

                // open db connection
                conn.Connect();

                if (conn.Cmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Movie> GetMoviesSql(DatabaseConnection conn)
        {
            List<Movie> returnMovies = new List<Movie>();

            using (conn.Reader = conn.Cmd.ExecuteReader())
            {
                while (conn.Reader.HasRows)
                {
                    Movie returnMovie = new Movie();
                    // The Movie Data from the first resultset
                    while (conn.Reader.Read())
                    {
                        returnMovie.ID = conn.Reader.GetInt32(0);
                        returnMovie.Title = conn.Reader.GetString(1);
                        returnMovie.Description = conn.Reader.GetString(2);
                        returnMovie.ReleasDate = conn.Reader.GetDateTime(3);
                        returnMovie.PlayTime = conn.Reader.GetInt32(4);

                        returnMovies.Add(returnMovie);
                    }
                    // move assets from the second result set
                    conn.Reader.NextResult();
                    if (conn.Reader.HasRows)
                    {
                        while (conn.Reader.Read())
                        {
                            switch (conn.Reader.GetInt32(1))
                            {
                                case 1:

                                    returnMovie.ImageUrl.Add(conn.Reader.GetString(0));
                                    break;

                                case 2:

                                    returnMovie.TrailorUrl.Add(conn.Reader.GetString(0));
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    // get the next move result set
                    conn.Reader.NextResult();
                }
            }
            return returnMovies;
        }
    }
}
