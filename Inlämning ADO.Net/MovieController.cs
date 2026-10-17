using Inlämning_ADO.Net.GUI;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_ADO.Net
{
    internal class MovieController
    {
        public static void AddMovie(SqlConnection connection)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Release Year: ");
            Console.Write("Release Year: ");
            int releaseyear;
            while (!int.TryParse(Console.ReadLine(), out releaseyear))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid year (e.g. 1999).");
                Console.ResetColor();
                Console.Write("Release Year: ");
            }
            var genres = MovieRepository.GetGenres(connection);

            var selectedGenre = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose a genre:")
                    .WrapAround()
                    .AddChoices(genres)
            );

            int genreID = MovieRepository.GetGenreId(connection, selectedGenre);
            MovieRepository.AddNewMovie(connection, genreID,title,releaseyear);    
        }

        public static void DeleteMovie(SqlConnection connection)
        {
            var movies= MovieRepository.ListOfMovies(connection);
            var selectedMovie = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose a Movie to delete:")
                        .WrapAround()
                        .AddChoices(movies)
                        .AddChoices("Back to main menu")
                );

            if (selectedMovie == "Back to main menu")
            {
                return;
            }

            MovieRepository.DeleteMovieByTitle(connection, selectedMovie);
        }
    }
}
