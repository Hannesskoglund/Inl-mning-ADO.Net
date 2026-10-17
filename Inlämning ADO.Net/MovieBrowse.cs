using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_ADO.Net
{
    internal class MovieBrowse
    {

        public static void AllMovies(SqlConnection connection)
        {
            string sql = @"
    SELECT Movie.Title, Movie.ReleaseYear, Genre.Name
    FROM Movie
    INNER JOIN Genre ON Movie.GenreId = Genre.GenreId";
            using var command = new SqlCommand(sql, connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string title = reader.GetString(0);
                int year = reader.GetInt32(1);
                string genreName = reader.GetString(2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{title}: ({year}) - {genreName}");
                Console.ResetColor();

            }
            Console.WriteLine("\nPress any key to go return...");
            Console.ReadKey(true);
        }


        public static void MovieByGenre(string genre, SqlConnection connection) 
        {
            string sql = @"
        SELECT Movie.Title, Movie.ReleaseYear, Genre.Name
        FROM Movie
        INNER JOIN Genre
            ON Movie.GenreId = Genre.GenreId
        WHERE Genre.Name = @Genre
        ORDER BY Movie.Title";

            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Genre", genre);

            using var reader = command.ExecuteReader();

            bool movieFound = false;

            while (reader.Read()) 
            {
               movieFound = true;
                string title = reader.GetString(0);
                int year = reader.GetInt32(1);
                string genreName = reader.GetString(2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{title}: {year} - {genreName}");
                Console.ResetColor();
            }
           
            if(!movieFound)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("No movies found in this genre!");
                Console.ResetColor();
            }
        }
    }
}
