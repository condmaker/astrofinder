using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astrofinder
{
    /// <summary>
    /// This is the class that manages all the on-screen text-based interface,
    /// as well as the user's inputs.
    /// </summary>
    public class ConsoleClient
    {
        /// <summary>
        /// The string that identifies the input for a instance.
        /// </summary>
        public string Input { get; private set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        public ConsoleClient()
        {
        }

        /// <summary>
        /// Prints the first message that the user will see, prompting him to
        /// load a file.
        /// </summary>
        public void StartingMessage()
            => Console.WriteLine("★ Welcome to Astrofinder!");

        public void LoadMessage()
        {
            Console.WriteLine("★ Please input a path to a .csv file:");
            Console.Write(">");

            Input = Console.ReadLine();

            // Sends the input to the handler (OUTSIDE OF CLASS, TO NOT BREAK
            // THE 'S' PRINCIPLE). )
        }


        /// <summary>
        /// Notifies the user if the file loaded well or not.
        /// </summary>
        /// <param name="bl">Defines if the file was successfully loaded 
        /// or not.</param>
        public void FileLoad(bool bl = false)
        {
            if (!bl)
                Console.WriteLine("★ File loaded successfully.");
            else
            {
                Console.WriteLine(
                    "★ File couldn't be loaded. Please input again:");
                Console.Write(">");

                Input = Console.ReadLine();
            }
        }

        /// <summary>
        /// Prints a screen to the user showcasing the main commands of the
        /// program, that are available at every point.
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("★---------------------------");
            Console.WriteLine("| ASTROFINDER");
            Console.WriteLine("★------------");
            Console.WriteLine("| sp - Search for a planet.");
            Console.WriteLine("| ss - Search for a star.");
            Console.WriteLine("| l  - Load another file.");
            Console.WriteLine("| r  - Return");
            Console.WriteLine("| q  - Quit");
            Console.WriteLine("★---------------------------\n");
            Console.Write(">");

            Input = Console.ReadLine();

            ClearScreen(10);
        }

        /// <summary>
        /// Prints a search list to the user, specifying the available inputs 
        /// and storing them on the instance's Input. Can also lead to
        /// SearchTutorial().
        /// </summary>
        public void SearchList()
        {
            Console.WriteLine("★---------------------------");
            Console.WriteLine("| SEARCH");
            Console.WriteLine("★------------");
            Console.WriteLine("| Available Commands: ");
            Console.WriteLine("|");
            Console.WriteLine("| General - ");
            Console.WriteLine(
                "| NAME, STARNAME, DISCOVERYMETHOD, DISCOVERYYEAR");
            Console.WriteLine("|");    
            Console.WriteLine("| Planet Specific Commands - ");    
            Console.WriteLine(
                "| ORBITALPERIOD, PLANETRADIUS, PLANETMASS, PLANETTEMPERATURE");
            Console.WriteLine("|");    
            Console.WriteLine("| Star Specific Commands - ");        
            Console.WriteLine(
                "| STARTEMPERATURE, STARRADIUS, STARMASS, STARAGE,");
            Console.WriteLine(
                "| STARROTATIONVELOCITY, STARROTATIONPERIOD, STARDISTANCE");
            Console.WriteLine("|");        
            Console.WriteLine("★------------");
            Console.WriteLine("| Input T to view how to utilize SEARCH.");
            Console.WriteLine("★------------");
            Console.Write(">");

            Input = Console.ReadLine();

            ClearScreen(19);

            if (Input.ToLower() == "t") SearchTutorial();
        }

        /// <summary>
        /// Teaches the user how to filter his search.
        /// </summary>
        public void SearchTutorial()
        {
            Console.WriteLine("★---------------------------");
            Console.Write(
                "| In order to search the celestial bodies with the desired");
            Console.WriteLine(
                " filters,");
            Console.WriteLine(
                "| first input *what* you want to search and then");
            Console.WriteLine(
                "| the respective value, sepatating multiple searches with");
            Console.WriteLine(
                "| commas. For example:");
            Console.WriteLine("|");
            Console.Write("| STARNAME 11 Com, YEARDISCOVERED_MAX 1998,");
            Console.WriteLine(" TEMP_MIN 3000");
            Console.WriteLine("|");
            Console.WriteLine(
                "| Numerical filters (like YEARDISCOVERED) can have a max or");
            Console.WriteLine(
                "| min value with the '_MAX' and '_MIN' sufixes.");
            // Space here for implementing star search if we do the advanced

            ClearScreen(12);

            SearchList();
        }

        /// <summary>
        /// Showcases a list of all the planets or starts searched by the user. 
        /// The list is interactible and the user can select a planet/star to
        /// observe it better. The list will be divided by pages, and there
        /// will be 10 planets max. per page.
        /// 
        /// Need to implement single object viewer.
        /// </summary>
        /// <param name="pCol">The list of planets or starts.</param>
        /// <typeparam name="T">The type of viewer-- either Planets or Stars.
        /// </typeparam>
        public void ListNavigation<T>(ICollection<T> pCol ) where T : Planet
            //Star
        {
            short index = 0;
            IEnumerable<T> viewer;

            // Legend goes here
            Console.WriteLine("");
            Console.WriteLine("★---------------------------");

            do
            {
                if (Input == "UpArrow")
                    index += 10;
                else if (Input == "DownArrow")
                    index -= 10;

                // This may not work
                index = Lerp(0, (short)(pCol.Count - (pCol.Count % 10)), index);

                viewer = pCol.Skip(index).Take(10); 

                foreach (T item in viewer)
                    Console.WriteLine(item.ToString());

                Input = Console.ReadKey(true).Key.ToString();

                // This'll set the cursor position at the start of the line
                // so that the next set of prints rewrite the current page.
                Console.SetCursorPosition(
                    Console.CursorLeft, Console.CursorTop - 10);

            } while (Input != "r" || Input != "q");

            // Puts the cursor where the legend is in order to overwrite it.
            Console.SetCursorPosition(
                Console.CursorLeft, Console.CursorTop - 2);

        }

        public void EndMessage()
        {
            Console.WriteLine("★ Thank you for utilizing this program.");
        }

        /// <summary>
        /// A method to clear the console screen.
        /// </summary>
        /// <param name="lines">Number of lines to clear.</param>
        private void ClearScreen(short lines)
        {
            Console.SetCursorPosition(
                    Console.CursorLeft, Console.CursorTop - lines);
            
            for (short i = 0; i < lines; i++)
                Console.WriteLine();

            Console.SetCursorPosition(
                    Console.CursorLeft, Console.CursorTop - lines);
        }

        // Method based on
        // https://stackoverflow.com/questions/33044848/c-sharp-lerping-from-position-to-position
        // This maybe shouldn't be here.
        private short Lerp(short limA, short limB, short num ) 
            => (short) (limA * (1 - num) + limB * num);
    }
    
}