using System;
using System.Text;

using System.Collections.Generic;

namespace Astrofinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileReader p = new FileReader("");

            // Makes it so that the program supports unicode characters.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //ConsoleClient cc = new ConsoleClient();
            //cc.SearchList();

            // testing - delete later
            Console.WriteLine("Help =]");

            Handler handler = new Handler();
            handler.UpdateParams(QueryParam.P_NAME, "planet");
            List<Planet> queryResult = new List<Planet>(handler.SearchPlanets());
            foreach (Planet p in queryResult)
            {
                Console.WriteLine("{0} - {1}", p.Name, p.HostName);
            }
        }

        
    }
}
