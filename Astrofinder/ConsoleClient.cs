using System;
using System.Globalization;
using System.Collections.Generic;

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
        {
            Console.Clear();
            Console.WriteLine("★ Welcome to Astrofinder!");    
        }

        /// <summary>
        /// Prints the message asking for the user to input a path for 
        /// the file to be opened.
        /// </summary>
        public void LoadMessage()
        {
            Console.WriteLine("★ Please input a path to a .csv file:");
            Console.Write("> ");

            Input = Console.ReadLine();

            Console.Clear();
        }


        /// <summary>
        /// Notifies the user if the file loaded well or not.
        /// </summary>
        /// <param name="bl">Defines if the file was successfully loaded 
        /// or not.</param>
        public void FileLoad(bool bl = false, Exception e = null)
        {
            if (bl)
            {
                Console.WriteLine("★ File loaded successfully.");
                Console.Clear();
            }
            else
            {
                if (e is System.IO.FileNotFoundException)
                {
                    Console.WriteLine(
                        "★ File couldn't be loaded. Please input again:");
                }        
                else if (e is InvalidFileConfiguration){
                    Console.WriteLine(
                        "★ " + e.Message + " Please input again:");
                }
                 else if (e is Exception)
                {
                    Console.WriteLine(
                        "★ Invalid file. Please input again:");
                }
                    
                Console.Write("> ");

                Input = Console.ReadLine();

                Console.Clear();
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
            Console.WriteLine("★---------------------------");
            Console.Write("> ");

            Input = Console.ReadLine();

            Console.Clear();
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
            Console.WriteLine("| Planet Specific Commands - ");
            Console.WriteLine(
                "| PLANETNAME, HOSTNAME, DISCOVERYMETHOD, DISCOVERYYEAR,");
            Console.WriteLine(
                "| ORBITALPERIOD, PLANETRADIUS, PLANETMASS, PLANETTEMPERATURE");
            Console.WriteLine("|");
            Console.WriteLine("| Star Specific Commands - ");
            Console.WriteLine(
                "| STARNAME, STARAGE, SUNDISTANCE, ROTVELOCITY, ROTPERIOD,");
            Console.WriteLine(
                "| STARRADIUS, STARMASS, STARTEMPERATURE, PLANETNUM");
            Console.WriteLine("|");
            Console.WriteLine("★------------");
            Console.WriteLine("| Input T to view how to utilize SEARCH.");
            Console.WriteLine("★------------");
            Console.Write("> ");

            Input = Console.ReadLine();

            Console.Clear();

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
            Console.Write("| STARNAME 11 Com, DISCOVERRYYEAR_MAX 1998,");
            Console.WriteLine(" TEMP_MIN 3000");
            Console.WriteLine("|");
            Console.WriteLine(
                "| Numerical filters (like DISCOVERYYEAR) can have a max or");
            Console.WriteLine(
                "| min value with the '_MAX' and '_MIN' sufixes.");
            Console.WriteLine("|");
            Console.WriteLine("| Press any key to go back.");
            Console.WriteLine("★---------------------------");

            Console.ReadKey(true);

            // Space here for implementing star search if we do the advanced

            Console.Clear();

            SearchList();
        }

        /// <summary>
        /// Showcases a list of all the planets or starts searched by the user. 
        /// </summary>
        /// <param name="pCol">The list of planets or starts.</param>
        /// <typeparam name="T">The type of viewer-- either Planets or Stars.
        /// </typeparam>
        public void ListShowcase<T>(
            IEnumerable<T> pCol, short page, short fPage)
            where T : ICelestialBody
        {
            short jindex = 0;
            short num;
            ConsoleKey? eInput = null;

            while (Input != "q")
            {
                // Changes the legend between Planet and Star
                if (typeof(T) == typeof(Planet))
                {
                    SearchLegend(true);
                }
                else
                {
                    SearchLegend(false);
                }

                // Prints the current page on the Collection
                foreach (T item in pCol)
                {
                    Console.Write($"{jindex++,-4}");
                    Console.WriteLine(item.ToString());
                }

                Console.Write("\nPage ");
                Console.Write((page / 10) + 1);
                Console.Write("/");
                Console.WriteLine((fPage / 10) + 1);
                Console.Write("Press R to return or Q to leave. ");
                Console.WriteLine(
                    "To view a planet in more detail, input its number.");

                // Reads the user's key press
                eInput = Console.ReadKey(true).Key;

                // Verifies if the keypress is on the range of numbers, and
                // if it is, showcases the number's planet in more detail
                if (eInput >= ConsoleKey.D0 && eInput <= ConsoleKey.D9)
                {
                    // This last .ToString() is very bad.
                    if (short.TryParse(
                        eInput.ToString()[1].ToString(),
                        NumberStyles.Any, CultureInfo.InvariantCulture,
                        out num))
                    {
                        short hindex = 0;
                        foreach (T item in pCol)
                        {
                            if (hindex == num)
                            {
                                Console.Clear();

                                Console.WriteLine(item.ToStringDetailed());
                                Console.WriteLine("Press any key to return.");

                                break;
                            }

                            hindex++;
                        }

                        eInput = Console.ReadKey(true).Key;
                        Input = eInput.ToString().ToLower();
                        Console.Clear();

                        jindex = 0;

                        continue;
                    }
                    else
                        break;
                }

                break;

            }

            Input = eInput?.ToString().ToLower();

            Console.Clear();
        }

        /// <summary>
        /// Prints the message of an exception.
        /// </summary>
        /// <param name="i">Said exception.</param>
        public void PrintError(Exception i) => Console.WriteLine(i.Message);

        /// <summary>
        /// Message for when the program ends.
        /// </summary>
        public void EndMessage()
        {
            Console.WriteLine("★ Thank you for utilizing this program.");
        }

        /// <summary>
        /// Prints the legend for Planet/Star search.
        /// </summary>
        /// <param name="b">Will switch between Planet and Star modes.</param>
        private void SearchLegend(bool b = true)
        {
            if (b == true)
            {
                Console.Write(
                    "    Planet Name     Star Name       ");
                Console.Write(
                    "Discovery       Year of         ");
                Console.Write(
                    "Orbital Period  Orbital Radius  ");
                Console.Write(
                    "Mass           Eq.Temp.\n");

                // Line 2
                Console.Write(
                    "\t\t\t\t\t\t    Discovery\t    (Days)\t    (vs Earth)");
                Console.WriteLine(
                    "\t    (vs Earth)\t   (Kelvin)");

                Console.Write(
                    "    ----------------------------------------------------");
                Console.Write(
                    "--------------------------------------------------------");
                Console.WriteLine(
                    "-----------");
            }
            else
            {
                Console.Write(
                    "    Name            Star Age        ");
                Console.Write(
                    "Distance to     Rotational      ");
                Console.Write(
                    "Rotational      Radius         ");
                Console.Write(
                    "Mass            Temperature    Planets\n");

                // Line 2
                Console.Write(
                    "\t\t\t\t    the Sun\t    Velocity (km/s) ");
                Console.Write(
                    "Period (days)");
                Console.WriteLine(
                    "\t\t   (vs Earth)\t   (Kelvin)");

                Console.Write(
                    "    ----------------------------------------------------");
                Console.Write(
                    "--------------------------------------------------------");
                Console.WriteLine(
                    "-------------------------");
            }
        }

    }

}