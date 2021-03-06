﻿using DisaBioModel.Model;
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
            try
            {
                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "InsertGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@Name", t.Name);

                    conn.Connect();
                    if (conn.Cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "DeleteGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@GenreID", id);

                    conn.Connect();
                    if (conn.Cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }

                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool DeleteMovieGenre(int genreID, int movieID)
        {
            try
            {
                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "DeleteMovieGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@GenreID", genreID);
                    conn.Cmd.Parameters.AddWithValue("@movieID", movieID);

                    conn.Connect();
                    if (conn.Cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }

                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Genre GetByID(int id)
        {
            try
            {
                Genre returnGenre = new Genre();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "GetGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@GenreID", id);

                    conn.Connect();
                    using (SqlDataReader reader = conn.Cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnGenre.ID = reader.GetInt32(0);
                            returnGenre.Name = reader.GetString(1);
                        }
                    }

                }
                return returnGenre;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Genre[] GetGenres()
        {
            try
            {
                List<Genre> genres = new List<Genre>();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "GetGenres";

                    conn.Connect();
                    conn.Reader = conn.Cmd.ExecuteReader();

                        while (conn.Reader.Read())
                        {
                            Genre genre = new Genre();
                            genre.ID = conn.Reader.GetInt32(0);
                            genre.Name = conn.Reader.GetString(1);

                            genres.Add(genre);
                        }
                    }
                return genres.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Genre[] GetMovieGenre(int movieID)
        {
            try
            {
                List<Genre> genres = new List<Genre>();

                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "GetMovieGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@MovieID", movieID);

                    conn.Connect();
                    conn.Reader = conn.Cmd.ExecuteReader();

                    while (conn.Reader.Read())
                    {
                        Genre genre = new Genre();
                        genre.ID = conn.Reader.GetInt32(0);
                        genre.Name = conn.Reader.GetString(1);

                        genres.Add(genre);
                    }
                }
                return genres.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Genre[] GetRange(int startRange, int endRange)
        {
            try
            {
                List<Genre> genres = new List<Genre>();
                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "GetRangeGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@RangeStart", startRange);
                    conn.Cmd.Parameters.AddWithValue("@RangeEnd", endRange);

                    conn.Connect();
                    conn.Reader = conn.Cmd.ExecuteReader();

                    while (conn.Reader.Read())
                    {
                        Genre genre = new Genre();
                        genre.ID = conn.Reader.GetInt32(0);
                        genre.Name = conn.Reader.GetString(1);

                        genres.Add(genre);
                    }
                }
                return genres.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertMovieGenre(int movieID, Genre genre)
        {
            try
            {
                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "MovieGenreInsert";
                    

                    conn.Cmd.Parameters.AddWithValue("@MovieID", movieID);
                    conn.Cmd.Parameters.AddWithValue("@GenreName", genre.Name);

                    conn.Connect();
                    if (conn.Cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }

                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(int id, Genre t)
        {
            try
            {
                using (DatabaseConnection conn = new DatabaseConnection())
                {
                    conn.Cmd.CommandText = "UpdateGenre";
                    

                    conn.Cmd.Parameters.AddWithValue("@ID", id);
                    conn.Cmd.Parameters.AddWithValue("@Name", t.Name);

                    conn.Connect();
                    if (conn.Cmd.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {

        }
    }
}
