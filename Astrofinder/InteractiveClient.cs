using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Astrofinder
{
    /// <summary>
    /// The class where the program runs. Includes the main loop.
    /// </summary>
    public class InteractiveClient
    {
        /// <summary>
        /// An instance of a ConsoleClient for user inputs and console screen
        /// management.
        /// </summary>
        private ConsoleClient cc;
        /// <summary>
        /// An instance of a Handler to manage searches and files.
        /// </summary>
        private Handler handler;

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
            // Shows a starting message to the user and attempts to load a file
            cc.StartingMessage();
            LoadNewFile();

            // If the file load is successful, it enters the main loop.
            while (cc.Input != "q")
            {
                cc.MainMenu();

                switch (cc.Input.ToLower())
                {
                    case "sp":
                        SearchCelestialBody<Planet>();
                        continue;
                    case "ss":
                        SearchCelestialBody<Star>();
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

            // Gives the user an goodbye message and returns, effectively 
            // ending the program.
            cc.EndMessage();
            return;
        }

        /// <summary>
        /// Method that attempts to load a file by reading the user's input.
        /// </summary>
        private void LoadNewFile()
        {
            // Gives the user a message and asks his input to load a file.
            cc.LoadMessage();

            while (cc.Input != "q")
            {
                // Tries to read the file and handles the exceptions if there
                // are any
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
                    if (cc.Input == "q") continue;

                    cc.FileLoad(e: h);
                    continue;
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
        private void SearchCelestialBody<T>() where T : ICelestialBody
        {
            // An IEnumerable to store the collection to be printed on
            // the screen.
            IEnumerable<T> viewer;
            // The collection of planets that the user has/will filter.
            ICollection<Planet> pCol = null;
            // The collection of stars that the user has/will filter.
            ICollection<Star> sCol = null;

            // Will store the user's position on the collection.
            short index;
            // The index upper limit.
            short count;
            // A switch between the two types of celestial bodies.
            bool typeCheck = false;

            // Observes if the type inputted is Planet or Star.
            if (typeof(T) == typeof(Planet))
                typeCheck = true;
            else if (typeof(T) == typeof(Star))
                typeCheck = false;
            else
                return;

            // The main search loop.
            while (cc.Input != "q")
            {
                index = 0;

                // Clears the planet and star parameter collections clean so 
                // that the user can filter the searches again.
                handler.ClearPlanetParams();
                handler.ClearStarParams();

                // Prints the legend for the search.
                cc.SearchList();

                // Tries to convert the user parameters.
                try
                {
                    if (typeCheck)
                        ConvertParams<Planet>(pCol);
                    else
                        ConvertParams<Star>(sCol);
                }
                catch (Exception i)
                {
                    cc.PrintError(i);
                    continue;
                }

                // Creates a collection depending on the type of search.
                if (typeCheck)
                    pCol = new List<Planet>(handler.AdvancedSearchPlanets());
                else
                    sCol = new List<Star>(handler.AdvancedSearchStars());

                // Checks if the user inpputed a return or leave.
                if (cc.Input == "r") break;
                else if (cc.Input == "q") break;

                // Asks the user if he wishes to order the inquiry list.
                cc.OrderInquiry();

                // Observes the input.
                if (cc.Input.Split(" ")[0].ToLower() == "orderbyplanet")
                {
                    try
                    {
                        pCol = OrderByPlanet(
                                cc.Input.Split(" ")[1], 
                                pCol as List<Planet>);
                    }
                    catch (ArgumentNullException)
                    {
                        cc.PrintError(
                            new InvalidValueException(
                               "You can't order by stars on a planet search."));
                        continue;
                    }
                    catch (InvalidValueException j)
                    {
                        cc.PrintError(j);
                        continue;
                    }
                    catch (Exception)
                    {
                        cc.PrintError(
                            new InvalidValueException(
                               "Something wrong happened. Try again."));
                        continue;
                    }
                }
                else if (cc.Input.Split(" ")[0].ToLower() == "orderbystar")
                {
                    try
                    {
                        sCol = OrderByStar(
                                cc.Input.Split(" ")[1], 
                                sCol as List<Star>);
                    }
                    catch (ArgumentNullException)
                    {
                        cc.PrintError(
                            new InvalidValueException(
                               "You can't order by planets on a star search."));
                        continue;
                    }
                    catch (InvalidValueException k)
                    {
                        cc.PrintError(k);
                        continue;
                    }
                    catch (Exception)
                    {
                        cc.PrintError(
                            new InvalidValueException(
                               "Something wrong happened. Try again."));
                        continue;
                    }
                }

                // Checks if the player pressed to leave/return again.
                if (cc.Input == "r") break;
                else if (cc.Input == "q") break;

                if (typeCheck)
                    count = (short)(pCol.Count - (pCol.Count % 10));
                else
                    count = (short)(sCol.Count - (sCol.Count % 10));

                do
                {
                    if (cc.Input == "downarrow")
                        index += 10;
                    else if (cc.Input == "uparrow")
                        index -= 10;

                    index = (short)Math.Clamp(index, (short)0, count);

                    if (typeCheck)
                        viewer = pCol.Skip(index).Take(10).Cast<T>();
                    else
                        viewer = sCol.Skip(index).Take(10).Cast<T>();

                    cc.ListShowcase<T>(viewer, index, count);

                } while (cc.Input != "r" && cc.Input != "q");

                // Returns to the start of the search.
                if (cc.Input == "r")
                    continue;
                // Quits the loops and consequentially the application.
                else if (cc.Input == "q")
                    break;
            }

        }

        /// <summary>
        /// Method that converts the user's input to valid parameters.
        /// </summary>
        private void ConvertParams<T>(ICollection<T> col) 
            where T : ICelestialBody
        {
            string[] s, sLoop;
            string sNumLoop = null;
            bool v = true;

            // Maximum number of strings on the array.
            s = new string[8];

            // Splits the user's input into various strings.
            try
            {
                s = cc.Input.ToLower().Split(", ");
            }
            catch (Exception)
            {
                s.Append(cc.Input.ToLower());
            }

            for (short i = 0; i < s.Length; i++)
            {
                // Catch the current query's parameters
                sLoop = s[i].Split(" ")[0].Split("_");
                // Observes if the user's input can be separated, and if it
                // can't observes if said input is to return/leave
                try
                {
                    sNumLoop = s[i].Split(" ")[1];
                }
                catch (IndexOutOfRangeException)
                {
                    if (cc.Input.Trim() == "r" ||
                        cc.Input.Trim() == "q" || cc.Input.Trim() == "")
                        return;
                }

                // If query doesn't have a _MAX or _MIN affix, it simply 
                // splits the string into two.
                if (sLoop.Length == 1)
                    sLoop = s[i].Split(" ");

                // Observes the current parameter and updates the handler based
                // on it.
                ParamSwitch<T>(sLoop, sNumLoop, col, ref v);

                if (!v)
                {
                    handler.ClearPlanetParams();
                    throw new InvalidValueException(
                        "One or more commands in your search were not valid.");
                }
            }
        }

        /// <summary>
        /// Updates multiple planet parameters according to user input.
        /// </summary>
        /// <param name="sLoop">The user input.</param>
        /// <param name="sNumLoop">Additional input if the user wrote a
        /// numerical parameter.</param>
        /// <param name="v">An reference bool that will be set to false
        /// if one or more commands are invalid</param>
        private void ParamSwitch<T>(string[] sLoop, string sNumLoop, 
            ICollection<T> col, ref bool v) where T : ICelestialBody
        {
            switch (sLoop[0])
            {
                case "planetname":
                    ParamUpdate(QueryParam.P_NAME, sLoop[1], ref v);
                    break;
                case "hostname":
                    ParamUpdate(QueryParam.P_HOST_NAME, sLoop[1], ref v);
                    break;
                case "discoverymethod":
                    ParamUpdate(QueryParam.P_DISC_METHOD, sLoop[1], ref v);
                    break;
                case "discoveryyear":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.P_MIN_DISC_YEAR,
                        QueryParam.P_MAX_DISC_YEAR, ref v);
                    break;
                case "orbitalperiod":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.P_MIN_ORBITAL_PERIOD,
                        QueryParam.P_MAX_ORBITAL_PERIOD, ref v);
                    break;
                case "planetradius":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.P_MIN_RADIUS,
                        QueryParam.P_MAX_RADIUS, ref v);
                    break;
                case "planetmass":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.P_MIN_MASS,
                        QueryParam.P_MAX_MASS, ref v);
                    break;
                case "planettemperature":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.P_MIN_TEMP,
                        QueryParam.P_MAX_TEMP, ref v);
                    break;
                case "starname":
                    ParamUpdate(QueryParam.S_NAME, sLoop[1], ref v);
                    break;
                case "starage":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_AGE,
                        QueryParam.S_MAX_AGE, ref v);
                    break;
                case "sundistance":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_SUN_DISTANCE,
                        QueryParam.S_MAX_SUN_DISTANCE, ref v);
                    break;
                case "rotvelocity":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_ROT_VEL,
                        QueryParam.S_MAX_ROT_VEL, ref v);
                    break;
                case "rotperiod":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_ROT_PERIOD,
                        QueryParam.S_MAX_ROT_PERIOD, ref v);
                    break;
                case "starradius":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_RADIUS,
                        QueryParam.S_MAX_RADIUS, ref v);
                    break;
                case "starmass":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_MASS,
                        QueryParam.S_MAX_MASS, ref v);
                    break;
                case "startemperature":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_TEMP,
                        QueryParam.S_MAX_TEMP, ref v);
                    break;
                case "planetnum":
                    NumParamUpdate(sLoop, sNumLoop,
                        QueryParam.S_MIN_NUM_PLANETS,
                        QueryParam.S_MAX_NUM_PLANETS, ref v);
                    break;
                default:
                    v = false;
                    break;
            }
        }

        /// <summary>
        /// Updates a specific numerical parameter.
        /// </summary>
        /// <param name="input">The user input</param>
        /// <param name="sNum">The number to filter, inputted by the user,
        ///  on string format</param>
        /// <param name="paramF">The 'min' parameter</param>
        /// <param name="paramS">The 'max' parameter</param>
        /// <param name="v">An reference bool that will be set to false
        /// if one or more commands are invalid</param>
        private void NumParamUpdate(
            string[] input, string sNum, QueryParam paramF, QueryParam paramS,
            ref bool v)
        {
            StringBuilder sb;
            float num;
            bool numVerif;

            sb = new StringBuilder();
            // Attempts to parse the number the user inputted on sNum
            numVerif = float.TryParse(sNum, out num);

            // Returns an exception in case the parsing was unsuccessful
            if (!numVerif)
            {
                sb.Append("The number you entered on '");
                sb.Append(input[0]);
                sb.Append("' was invalid.");
                throw new InvalidValueException(sb.ToString());
            }

            // Updates the parameter(s) accordingly.
            if (input[1] == "min")
            {
                ParamUpdate(
                    paramF,
                    num,
                    ref v);
            }
            else if (input[1] == "max")
            {
                ParamUpdate(
                    paramS,
                    num,
                    ref v);
            }
            else
            {
                ParamUpdate(
                    paramF,
                    num,
                    ref v);
                ParamUpdate(
                    paramS,
                    num,
                    ref v);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="col"></param>
        private ICollection<Planet> OrderByPlanet(
            string input, List<Planet> col) 
        {
            switch (input.ToLower())
            {
                case "planetname":
                    col.Sort(Planet.CompareByName);
                    break;
                case "hostname":
                    col.Sort(Planet.CompareByHostName);
                    break;
                case "discoverymethod":
                    col.Sort(Planet.CompareByDiscMethod);
                    break;
                case "discoveryyear":
                    col.Sort(Planet.CompareByDiscYear);
                    break;
                case "orbitalperiod":
                    col.Sort(Planet.CompareByOrbPeriod);
                    break;
                case "planetradius":
                    col.Sort(Planet.CompareByRadius);
                    break;
                case "planetmass":
                    col.Sort(Planet.CompareByMass);
                    break;
                case "planettemperature":
                    col.Sort(Planet.CompareByTemperature);
                    break;
                case "":
                    break;
                default:
                    throw new InvalidValueException(
                        "Your input is invalid. Please try again.");
            }

            return col as ICollection<Planet>;
        }

        /// <summary>
        /// Orders a list of stars by the users input.
        /// </summary>
        /// <param name="input">What will it be ordered by.</param>
        /// <param name="col">the list to be updated.</param>
        private ICollection<Star> OrderByStar(
            string input, List<Star> col) 
        {
            switch (input.ToLower())
            {
                case "starname":
                    col.Sort(Star.CompareByName);
                    break;
                case "starage":
                    col.Sort(Star.CompareByAge);
                    break;
                case "sundistance":
                    col.Sort(Star.CompareBySunDistance);
                    break;
                case "rotvelocity":
                    col.Sort(Star.CompareByRotVelocity);
                    break;
                case "rotperiod":
                    col.Sort(Star.CompareByRotPeriod);
                    break;
                case "starradius":
                    col.Sort(Star.CompareByRadius);
                    break;
                case "starmass":
                    col.Sort(Star.CompareByMass);
                    break;
                case "startemperature":
                    col.Sort(Star.CompareByTemperature);
                    break;
                case "planetnum":
                    col.Sort(Star.CompareByPlanets);
                    break;
                case "":
                    break;
                default:
                    throw new InvalidValueException(
                        "Your input is invalid. Please try again.");
            }

            return col as ICollection<Star>;
        }

        /// <summary>
        /// Updates the current query parameters.
        /// </summary>
        /// <param name="param">The parameter to update.</param>
        /// <param name="s">The parameter itself. In this case, a 
        /// string.</param>
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
        /// <param name="param">The parameter to update. In this case, a 
        /// float.</param>
        /// <param name="s">The parameter itself.</param>
        /// <param name="val">A bool that will update if the parameter
        /// update is unsuccessful.</param>
        private void ParamUpdate(QueryParam param, float? s, ref bool val)
        {
            try
            {
                handler.UpdateParams(
                    param, s);
            }
            catch (InvalidValueException v)
            {
                try
                {
                    handler.UpdateParams(
                    param, (short?)s);
                }
                catch (InvalidValueException)
                {
                    cc.PrintError(v);
                    val = false;
                }
            }
        }
    }
}