using System;
using System.Linq;
using System.Collections.Generic;

namespace Astrofinder
{
    /// <summary>
    /// The class where the program runs. Includes the main loop.
    /// </summary>
    public class InteractiveClient
    {
        private ConsoleClient cc;
        private Handler handler;
        private ICollection<Planet> pCol;
        private ICollection<Star> sCol;

        /// <summary>
        /// Class constructor. Instantiates a new Console Client and a Handler.
        /// </summary>
        public InteractiveClient()
        {
            cc = new ConsoleClient();
            handler = new Handler();
        }

        /// <summary>
        /// The main loop of the program. Everything branches out from here.
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
        /// Method that attempts to load a file by reading the user's input.
        /// </summary>
        private void LoadNewFile()
        {
            cc.LoadMessage();

            while (cc.Input != "q")
            {
                // Very rudimentary.
                try
                {
                    handler.ReadFile(cc.Input);
                }
                catch (System.IO.FileNotFoundException i)
                {
                    if (cc.Input == "q") continue;

                    cc.FileLoad(e: i);
                    continue;
                }
                catch (Exception h)
                {
                    cc.FileLoad(e: h);
                }

                cc.FileLoad(true);
                break;
            }
            return;
        }

        /// <summary>
        /// The method that is responsible for the user to filter and search
        /// for the respective planets.
        /// </summary>
        private void SearchPlanet()
        {
            // An IEnumerable to store the collection to be printed on
            // the screen.
            IEnumerable<Planet> viewer;

            // Will store the user's position on the collection.
            short index;
            // The index upper limit.
            short pCount;

            // The main search loop.
            while (cc.Input != "q")
            {
                index = 0;

                // Prints the legend for the search.
                cc.SearchList();

                // This will define filCol.
                try
                {
                    ConvertParamsPlanet();
                }
                catch (Exception i)
                {
                    continue;
                }

                if (cc.Input == "r") break;

                // TESTING PURPOSES. DELETE LATER.
                handler.UpdateParams(QueryParam.P_MIN_DISC_YEAR, 2008);
                handler.UpdateParams(QueryParam.P_MAX_DISC_YEAR, 2010);
                handler.UpdateParams(QueryParam.P_HOST_NAME, (string)null);
                pCol = new HashSet<Planet>(handler.SearchPlanets());

                pCount = (short)(pCol.Count - (pCol.Count % 10));

                do
                {
                    if (cc.Input == "uparrow")
                        index += 10;
                    else if (cc.Input == "downarrow")
                        index -= 10;

                    index = (short) Math.Clamp(index, (short)0, pCount);

                    viewer = pCol.Skip(index).Take(10);

                    cc.ListShowcase<Planet>(viewer, index, pCount, true);

                } while (cc.Input != "r" && cc.Input != "q");

                // Returns to the start of the search.
                // Need to figure out how to go back to SEARCH.
                if (cc.Input == "r")
                {
                    continue;
                }
                // Quits the loops and consequentially the application.
                else if (cc.Input == "q")
                    break;
            }

        }

        /// <summary>
        /// Method that converts the user's input to valid parameters.
        /// </summary>
        private void ConvertParamsPlanet()
        {
            string[] s, sLoop;
            bool v = true;

            // Maximum number of strings on the array.
            s = new string[8];

            // Splits the user's input into various strings.
            try
            {
                s = cc.Input.ToLower().Split(",");
            }
            catch (Exception i)
            {
                s.Append(cc.Input.ToLower());
            }

            for (short i = 0; i < s.Length; i++)
            {
                try
                {
                    sLoop = s[i].Split(" ")[0].Split("_");
                }
                catch (Exception j)
                {
                    sLoop = s[i].Split(" ", 1);
                }
                switch (sLoop[0])
                {
                    case "name":
                        ParamUpdate(QueryParam.P_NAME, sLoop[1], ref v);
                        break;
                    case "starname":
                        ParamUpdate(QueryParam.P_HOST_NAME, sLoop[1], ref v);
                        break;
                    case "discoverymethod":
                        ParamUpdate(QueryParam.P_DISC_METHOD, sLoop[1], ref v);
                        break;
                    case "discoveryyear":
                        break;
                    case "orbitalperiod":
                        break;
                    case "planetradius":
                        break;
                    case "planetmass":
                        break;
                    case "planettemperature":
                        break;
                    default:
                        cc.InvalidSearch();
                        v = false;
                        break;
                }

                if (!v)
                {
                    handler.ClearPlanetParams();
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SearchStar()
        {

        }

        /// <summary>
        /// Updates the current query parameters.
        /// </summary>
        /// <param name="param">The parameter to update.</param>
        /// <param name="s">The parameter itself.</param>
        /// <param name="val">A bool that will update if the parameter
        /// update is unsuccessful.</param>
        private void ParamUpdate(QueryParam param, string s, ref bool val)
        {
            try
            {
                handler.UpdateParams(
                    param, s);
            }
            catch (InvalidValueException v)
            {
                cc.PrintError(v);
                val = false;
            }
        }
        /// <summary>
        /// Updates the current query parameters.
        /// </summary>
        /// <param name="param">The parameter to update.</param>
        /// <param name="s">The parameter itself.</param>
        /// <param name="val">A bool that will update if the parameter
        /// update is unsuccessful.</param>
        private void ParamUpdate(QueryParam param, short? s, ref bool val)
        {
            try
            {
                handler.UpdateParams(
                    param, s);
            }
            catch (InvalidValueException v)
            {
                cc.PrintError(v);
                val = false;
            }
        }
    }
}