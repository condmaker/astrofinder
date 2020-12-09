using System;
using System.Text;

using System.Collections.Generic;

namespace Astrofinder
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Makes it so that the program supports unicode characters.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            InteractiveClient i = new InteractiveClient();

            i.MainLoop();            

        }

        
    }
}
