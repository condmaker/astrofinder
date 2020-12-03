using System;
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
        /// The string that identifies the input for a UI instance.
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
        {
            Console.WriteLine("★ Welcome to Astrofinder!");
            Console.WriteLine("★ Please select a .csv file:");
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
            Console.WriteLine("| r  - Load another file.");
            Console.WriteLine("| q  - Quit");
            Console.WriteLine("★---------------------------\n");
            Console.Write(">");

            Input = Console.ReadLine();
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

            SearchList();
        }
    }
}