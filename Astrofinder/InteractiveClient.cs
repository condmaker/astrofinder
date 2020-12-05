using System;
using System.Linq;
using System.Collections.Generic;

namespace Astrofinder
{
    /// <summary>
    /// 
    /// </summary>
    public class InteractiveClient
    {
        private ConsoleClient cc;
        private Handler handler;
        private ICollection<Planet> pCol;
        private ICollection<Star> sCol;

        /// <summary>
        /// 
        /// </summary>
        public InteractiveClient()
        {
            cc = new ConsoleClient();
            handler = new Handler();
        }

        /// <summary>
        /// 
        /// </summary>
        public void MainLoop()
        {
            cc.StartingMessage();

            LoadNewFile();

            while (cc.Input != "q" && cc.Input != "escape") 
            {
                cc.MainMenu();

                switch (cc.Input.ToLower())
                {
                    case "sp":
                        SearchPlanet();
                        continue;
                    case "ss":
                        SearchStar();
                        continue;
                    case "l":
                        LoadNewFile();
                        continue;
                    case "r":
                        break;
                    case "q":
                        break;
                }
            }

            cc.EndMessage();
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadNewFile()
        {
            cc.LoadMessage();

            while (true)
            {
                // Very rudimentary.
                try
                {
                    handler.ReadFile(cc.Input);
                }
                catch (System.IO.FileNotFoundException i)
                {
                    cc.FileLoad();
                    continue;
                }

                cc.FileLoad(true);
                break;
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SearchPlanet()
        {
            IEnumerable<Planet> viewer;
            // Will store the user's position on the collection.
            short index;

            while (cc.Input != "q" && cc.Input != "r" && cc.Input != "escape")
            {
                index = 0;

                // Prints the legend for the search.
                cc.SearchList();

                // This will define filCol.
                switch (cc.Input)
                {
                    case "r":
                        continue;
                    case "q":
                        continue;
                }

                // TESTING PURPOSES. DELETE LATER.
                handler.UpdateParams(QueryParam.P_MIN_DISC_YEAR, 2008);
                handler.UpdateParams(QueryParam.P_MAX_DISC_YEAR, 2010);
                handler.UpdateParams(QueryParam.P_HOST_NAME, (string)null);
                pCol = new HashSet<Planet>(handler.SearchPlanets());

                do
                {
                    if (cc.Input == "uparrow")
                        index += 10;
                    else if (cc.Input == "downarrow")
                        index -= 10;

                    index = (short) Math.Clamp(
                        index, 0, (pCol.Count - (pCol.Count % 10)));

                    Console.WriteLine(cc.Input);
                    Console.WriteLine(index);

                    viewer = pCol.Skip(index).Take(10);

                    cc.ListShowcase<Planet>(viewer);

                } while (cc.Input != "r" && cc.Input != "q");

                // Returns to the start of the search.
                // Need to figure out how to go back to SEARCH.
                if (cc.Input == "r")
                    continue;
                // Quits the loops and consequentially the application.
                else if (cc.Input == "q")
                    break;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void SearchStar()
        {

        }
    }
}