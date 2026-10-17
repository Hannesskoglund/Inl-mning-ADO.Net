using Microsoft.Data.SqlClient;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämning_ADO.Net.GUI
{
    internal class MenuDisplay
    {
    
      public static void  GenreMenu(SqlConnection connection)
        {


            while (true)
            {
                Console.Clear();

                var genres = MovieRepository.GetGenres(connection);

                var selectedGenre = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose a genre:")
                        .WrapAround()
                        .AddChoices(genres)
                        .AddChoices("Back to main menu")
                );

                if (selectedGenre == "Back to main menu")
                {
                    break;
                }

                MovieBrowse.MovieByGenre(selectedGenre, connection);

                Console.WriteLine("\nPress any key to go return...");
                Console.ReadKey(true);
            }





        }
    }
}
