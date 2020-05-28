using DisaBioModel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DisaBioModel.Repository
{
    public class GenreRepository : Interface.IGenreRepository<Genre>
    {
        public bool Create(Genre t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("InsertGenre"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name",t.Name);

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
                using (SqlCommand cmd = new SqlCommand("DeleteGenre"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GenreID", id);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DeleteMovieGenre(int genreID, int movieID)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DeleteMovieGenre"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GenreID", genreID);
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
            
        }

        public Genre GetByID(int id)
        {
            Genre returnGenre = new Genre();

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetGenre"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@GenreID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnGenre.ID = reader.GetInt32(0);
                            returnGenre.Name = reader.GetString(1);
                        }
                    }
                }
            }
            return returnGenre;
        }

        public Genre[] GetMovieGenre(int movieID)
        {
            List<Genre> genres = new List<Genre>();

            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("GetMovieGenre"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MovieID", movieID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Genre genre = new Genre();
                            genre.ID = reader.GetInt32(0);
                            genre.Name = reader.GetString(1);

                            genres.Add(genre);
                        }
                    }
                }
            }
            return genres.ToArray();
        }

        public Genre[] GetRange(int startRange, int endRange)
        {
            List<Genre> genres = new List<Genre>();

            using (SqlCommand cmd = new SqlCommand("GetRangeGenre"))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RangeStart", startRange);
                cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        Genre genre = new Genre();
                        genre.ID = reader.GetInt32(0);
                        genre.Name = reader.GetString(1);

                        genres.Add(genre);
                    }
                }
            }

            return genres.ToArray();
        }

        public bool InsertMovieGenre(int movieID, Genre genre)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("MovieGenreInsert"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MovieID", movieID);
                    cmd.Parameters.AddWithValue("@GenreName", genre.Name);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Update(int id, Genre t)
        {
            using (DatabaseConnection conn = new DatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UpdateGenre"))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", t.Name);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
