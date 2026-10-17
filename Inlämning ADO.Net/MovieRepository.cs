using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_ADO.Net
{
    public class MovieRepository
    {
        public static List<string> GetGenres(SqlConnection connection)
        {
            var genres = new List<string>();

            string sql = "SELECT Name FROM Genre ORDER BY Name";


            using var command = new SqlCommand(sql, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                genres.Add(reader.GetString(0));
            }

            return genres;
        }

        public static int GetGenreId(SqlConnection connection, string genre)
        {
            string sql = "SELECT GenreId FROM Genre WHERE Name = @Name";

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", genre);

            object? result = command.ExecuteScalar();

            return result is null ? -1 : Convert.ToInt32(result);
        }


        public static List<string> ListOfMovies(SqlConnection connection) 
        {
            var movies = new List<string>();

            string sql = "SELECT title FROM Movie ORDER BY title";


            using var command = new SqlCommand(sql, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                movies.Add(reader.GetString(0));
            }

            return movies;
        }

        public static void AddNewMovie(SqlConnection connection,int genreID, string title, int releaseYear)
        {

            string sql =
                "INSERT INTO Movie (Title, ReleaseYear,GenreID) VALUES (@title, @ReleaseYear, @GenreID)";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
            command.Parameters.AddWithValue("@GenreID", genreID);

            int rowsAffected = command.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{rowsAffected} Movie created!.");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }

        public static void DeleteMovieByTitle(SqlConnection connection, string selectedMovie)
        {
            string sql = "DELETE FROM Movie WHERE title = @title";

            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@title", selectedMovie);

            int rowsAffected = command.ExecuteNonQuery();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Movie Deleted!");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();

        }
    }
}
