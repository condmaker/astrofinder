using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Astrofinder
{

    public class FileReader
    {
        
        // Directory path to the file imputed by the user  
        private string path;

        // Number of columns in the first line
        // The program expects that all lines have this numbers of columns
        private short totalColNumb; 

        // Collection that stores all the Planet instances. 
        public ICollection<Planet> planetCol { get; private set; }

        // Collection that stores all the Star instances.
        public List<Star> starCol { get; private set; } 
 
        // This Dictionary stores the parameters that can be found 
        // and extracted from the file,
        // as well as the index of the collumn they appear at.
        private Dictionary<string, int?> par;


        /// <summary>
        /// Construtor for the FileReader class. 
        /// Takes the path for the file to read. 
        /// </summary>
        /// <param name="path">Directory path to the file imputed by the 
        /// user</param>
        public FileReader(string path)
        {
            // Save the path to use later 
            this.path = path;

            // Instatiates the collection that stores the Planets
            planetCol = new List<Planet>();
            // Instatiates the collection that stores the Stars
            starCol = new List<Star>();
            // Instatiates the Dictionary that stores the parameters 
            par = new Dictionary<string, int?>();

            // Adds all possible parameters related to the planets to the
            // Dictionary
            par.Add("pl_name", null);
            par.Add("hostname", null);
            par.Add("discoverymethod", null);
            par.Add("disc_year", null);
            par.Add("pl_orber", null);
            par.Add("pl_rade", null);
            par.Add("pl_masse", null);
            par.Add("pl_eqt", null);

            // Adds all possible parameters related to the stars to the 
            // Dictionary
            par.Add("st_teff", null);
            par.Add("st_age", null);
            par.Add("st_vsin", null);
            par.Add("st_rotp", null);
            par.Add("st_rad", null);
            par.Add("st_mass", null);
            par.Add("sy_dist", null);

            //Reads the file
            ReadFile();
            
        }


        /// <summary>
        /// Opens the file that the user imputed and asigns each parameter to
        /// 2 lists: 1 of Stars amd 1 of Planets  
        /// </summary>
        public void ReadFile()
        {
            // Open file to read
            using (StreamReader sr = new StreamReader(path))
            {
                bool firstLine = true;
                string row;

                // Loop through each line of the file
                while((row = sr.ReadLine()) != null)
                {

                    // Ignore comments and empty lines
                    if (row.Length  <= 0) continue;
                    if (row[0] == '#') continue;

                    // Split row into a list of parameters
                    IList<string> spltRow = row.Split(",");

                    // Analyze the first row of the file and organize  
                    // the dictionary, with the parameters, accordingly                   
                    if(firstLine)
                    {                                         
                        // Asign existing parameters and their 
                        // corresponding collumn numb
                        for(int i = 0; i < spltRow.Count; i++)
                        {
                            string s = spltRow[i].Trim();
                            if(par.ContainsKey(s))
                            {
                                par[s] = i;
                            }
                        }
                        
                        
                        // Check if the file contains name and hostname
                        // Send message if not
                        if(par["hostname"] == null && par["pl_name"] == null)
                        {
                            // Send Message
                            return;
                        }

                        totalColNumb = (short) spltRow.Count;

                        firstLine = false;
                        continue;
                    }
            
                    // Check if line has the expected number of columns
                    if(spltRow.Count != totalColNumb)
                    {
                        // Send Message
                        return;
                    }


                    // Get the current Planet name
                    string planetName = 
                        FormatParToString(par["pl_name"], spltRow);
                    
                    // Create a temporary Planet with an equal name 
                    Planet tempPlanet = new Planet(planetName, "");

                    // Check if a Planet with the same name already 
                    // exits in the collection and add one if thats not the case                    
                    if(!planetCol.Contains(tempPlanet))
                    {
                        //Create new Planet instance
                        Planet newPlanet = new Planet
                        (
                            name: 
                                planetName,
                            hostname: 
                                FormatParToString(
                                    par["hostname"], spltRow),
                            discM: 
                                FormatParToString(
                                    par["discoverymethod"], spltRow),
                            discY: 
                                FormatPar<short>(
                                    par["disc_year"], spltRow),
                            orber: 
                                FormatPar<float>(
                                    par["pl_orber"], spltRow),
                            radius:
                                FormatPar<float>(
                                    par["pl_rade"], spltRow),
                            mass:
                                FormatPar<float>(
                                    par["pl_masse"], spltRow),
                            eqTemp :  
                                FormatPar<short>(
                                    par["pl_eqt"], spltRow)
                        );

                        
                        //Add the new Planet to the planet list
                        planetCol.Add(newPlanet);
                    
                    }
                    
                    //Create new Star instance
                    Star newStar = new Star
                    (
                        name: 
                            FormatParToString(par["hostname"], spltRow),
                        planetName: 
                            planetName,
                        temp: 
                            FormatPar<float>(par["st_teff"],spltRow),
                        age: 
                            FormatPar<float>(par["st_age"],spltRow),
                        rotVel: 
                            FormatPar<float>(par["st_vsin"],spltRow),
                        rotPer: 
                            FormatPar<float>(par["st_rotp"],spltRow),
                        radius: 
                            FormatPar<float>(par["st_rad"],spltRow),
                        mass:
                            FormatPar<float>(par["st_mass"],spltRow),
                        sunDis:
                            FormatPar<float>(par["sy_dist"],spltRow)                           
                    );

                    // Check if a Star with the same name already 
                    // exits in the collection
                    if(starCol.Contains(newStar)){
                        // Update information of the current Star
                        int index = starCol.IndexOf(newStar);
                        starCol[index].UpdateStar(newStar, planetName);
                    }
                    else
                    {
                        // Add the new Star to the star list
                        starCol.Add(newStar);
                    }                   
                }
            }
        
            
            //Testing stuff. DELETE LATER
            // Planet testplanet = planetCol[28];
            // Console.WriteLine(testplanet.Name + " -- " + testplanet.Mass
            // );

            /*foreach(Planet p in planetCol){
                Console.WriteLine(p.Name);
            }*/
        
        }

        /// <summary>
        /// Formats the received string into a string the program can utilize
        /// </summary>
        /// <param name="index"> index of the wanted data</param>
        /// <param name="row"> List that contains the data in a given order 
        /// </param>
        /// <returns></returns>
        private string FormatParToString(int? index, IList<string> row)
        {
            if(index == null) return null;

            int newPar = index ?? 0;

            string value = row[newPar].Trim();

            return value;
        }


        //  https://stackoverflow.com/questions/209160/nullable-type-as-a-generic-parameter-possible
        /// <summary>
        /// Formats the received string into the wanted struct type
        /// </summary>
        /// <param name="index"> index of the wanted data </param>
        /// <param name="row"> List that contains the data in a given order 
        /// </param>
        /// <returns></returns>
        private Nullable<T> FormatPar<T>(int? index, IList<string> row) 
            where T: struct
        { 
            // Get formated string
            string val = FormatParToString(index, row);
            if(val == null) return null;
            
            // Format T
            T value;       
        
            // https://stackoverflow.com/questions/2961656/generic-tryparse
            // Parse the string into the wanted type
            try
            { 
                value = 
                    (T)TypeDescriptor.GetConverter(typeof(T))
                        .ConvertFromString(
                            null , culture: CultureInfo.InvariantCulture, val);         
            }
            catch 
            {
                return null;
            }
            
            return value;

        }

    }
}