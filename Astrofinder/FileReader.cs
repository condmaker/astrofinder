using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Astrofinder
{

    public class FileReader
    {
        

        private string path;

        //Collection that stores the Planet data / CHANGE TO ICOLLECTION LATER
        public List<Planet> planetCol;
        //Collection that stores the Star data / CHANGE TO ICOLLECTION LATER
        //private List<Star> starCol;

        //This Dictionary stores the parameters that can be found 
        //and extracted from the file,
        //as well as the index of the collumn they appear at
        private Dictionary<string, int?> par;


        /// <summary>
        /// Construtor for the FileReader class. 
        /// Takes the path for the file to read.
        /// </summary>
        
        public FileReader(string path)
        {

            //Check if the path given is an acceptable path
            //Check if the file contains name and hostname
            //Send message if not

            //Save the path to use later 
            this.path = path;

            //Instatiates the collection that stores the Planets
            planetCol = new List<Planet>();
            //Instatiates the collection that stores the Stars

            //Instatiates the Dictionary that stores the parameters 
            par = new Dictionary<string, int?>();

            //Adds all possible parameters related to the planets to the Dictionary
            par.Add("pl_name", null);
            par.Add("hostname", null);
            par.Add("discoverymethod", null);
            par.Add("disc_year", null);
            par.Add("pl_orber", null);
            par.Add("pl_rade", null);
            par.Add("pl_masse", null);
            par.Add("pl_eqt", null);

            //Adds all possible parameters related to the stars to the Dictionary


            //Reads the file
            ReadFile();
            
        }


        /// <summary>
        /// Opens the file that the user inputed and asigns each parameter to
        /// 2 lists: 1 of Stars amd 1 of Planets  
        /// </summary>
        public void ReadFile()
        {
            using (StreamReader sr = 
                new StreamReader(path))
            {
                bool firstLine = true;

                string row;
                while((row = sr.ReadLine()) != null)
                {

                    //Ignore comments
                    if (row.Length  <= 0) continue;
                    if(row[0] == '#')continue;

                    //Split row into a list of parameters
                    IList<string> spltRow = row.Split(",");

                    //First Row                   
                    if(firstLine)
                    {                                         
                        //Asign existing parameters and their corresponding collumn numb
                        for(int i = 0; i < spltRow.Count; i++)
                        {
                            string s = spltRow[i].Trim();
                            if(par.ContainsKey(s))
                            {
                                par[s] = i;
                            }
                        }
                        
                        firstLine = false;
                        continue;
                    }

                    
                    //Get current Planet name
                    string planetName = FormatParToString(par["pl_name"], spltRow);
                    
                    //Create a temp Planet with an equal name 
                    Planet tempPlanet = new Planet(planetName, "");

                    //Check if a Planet with the same name already exits in the collection
                    //Ignore Planet info 
                    if(!planetCol.Contains(tempPlanet))
                    {
                        //Create new Planet instance
                        Planet newPlanet = new Planet
                        (
                            name: 
                                planetName,
                            hostname: 
                                FormatParToString(par["hostname"], spltRow),
                            discM: 
                                FormatParToString(par["discoverymethod"], spltRow),
                            discY: 
                                FormatPar<short>(par["disc_year"], spltRow),
                            orber: 
                                FormatPar<float>(par["pl_orber"], spltRow),
                            radius:
                                FormatPar<float>(par["pl_rade"], spltRow),
                            mass:
                                FormatPar<float>(par["pl_masse"], spltRow),
                            eqTemp :  
                                FormatPar<short>(par["pl_eqt"], spltRow)
                        );

                        
                        //Add the new Planet to the planet list
                        planetCol.Add(newPlanet);
                    
                    }
                    //Create new Star instance




                    //Add the new Start to the star list

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
        /// <param name="row"> List that contains the data in a given order </param>
        /// <returns></returns>
        private string FormatParToString(int? index, IList<string> row)
        {
            if(par == null) return null;

            int newPar = index ?? 0;
            string value = row[newPar].Trim();

            return value;
        }


        //https://stackoverflow.com/questions/209160/nullable-type-as-a-generic-parameter-possible

        /// <summary>
        /// Formats the received string into the wanted struct type
        /// </summary>
        /// <param name="index"> index of the wanted data </param>
        /// <param name="row"> List that contains the data in a given order </param>
        /// <returns></returns>
        private Nullable<T> FormatPar<T>(int? index, IList<string> row) 
            where T: struct
        { 
            //Get formated string
            string val = FormatParToString(index, row);
            if(val == null) return null;
            
            //Format T
            T value;       
        
            //https://stackoverflow.com/questions/2961656/generic-tryparse
            

            //Parse the string into the wanted type
            try
            { 
                value = 
                    (T)TypeDescriptor.GetConverter(typeof(T))
                        .ConvertFromString( null , culture: CultureInfo.InvariantCulture, val);         
            }
            catch 
            {
                return null;
            }
            
            return value;

        }

    }
}