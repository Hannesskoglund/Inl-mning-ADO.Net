using Inlämning_ADO.Net.GUI;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_ADO.Net
{
    internal class App
    {
        public static void Run(SqlConnection connection)
        {
            while (true)
            {
                Console.Clear();
            var options = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Choose one of the following options!")
        .WrapAround()
        .AddChoices("Browse movies", "Browse movies by genre", "Add movie", "Delete movie", "Quit"));




            switch (options) {

                case "Browse movies":
                        MovieBrowse.AllMovies(connection);
                        break;

                case "Browse movies by genre":
                        MenuDisplay.GenreMenu(connection);
                        
                        break;

                case "Add movie":
                        MovieController.AddMovie(connection);
                        break;

                case "Delete movie":
                        MovieController.DeleteMovie(connection);
                        break;
                case "Quit":
                    Environment.Exit(0);
                    break;
            }

            }
        }


       
    }
}
