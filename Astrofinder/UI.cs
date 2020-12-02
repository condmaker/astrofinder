using System;
using System.Text;

namespace Astrofinder
{
    /// <summary>
    /// This is the class that manages all the on-screen text-based interface,
    /// as well as the user's inputs.
    /// </summary>
    public class UI
    {
        /// <summary>
        /// The string that identifies the input for a UI instance.
        /// </summary>
        public string Input { get; private set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        public UI()
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
        /// 
        /// </summary>
        public void MainMenu()
        {
            Console.WriteLine("★---------------------------");
            Console.WriteLine("| ASTROFINDER");
            Console.WriteLine("★------------");
            Console.WriteLine("| sp - Search for a planet.");
            Console.WriteLine("| ss - Search for a star.");
            Console.WriteLine("★---------------------------\n");
            Console.Write(">");

            Input = Console.ReadLine();
        }

        public void SearchList()
        {
            Console.WriteLine("★---------------------------");
            Console.WriteLine("| SEARCH");
            Console.WriteLine("★---------------------------");
        }
    }
}