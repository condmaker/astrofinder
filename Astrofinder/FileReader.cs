using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Astrofinder
{

    public class FileReader
    {
        
        private List<Planet> planetCol;
        private Dictionary<string, int?> par;

        public FileReader()
        {
            planetCol = new List<Planet>();
            par = new Dictionary<string, int?>();
            par.Add("pl_name", null);
            par.Add("hostname", null);
            par.Add("discoverymethod", null);
            par.Add("disc_year", null);
            par.Add("pl_orber", null);
            par.Add("pl_rade", null);
            par.Add("pl_masse", null);
            par.Add("pl_eqt", null);

            ReadFile();
            
        }

        public void ReadFile()
        {
            using (StreamReader sr = 
                new StreamReader("PS_2020.11.24_00.43.49.csv"))
            {
                bool firstLine = true;

                string row;
                while((row = sr.ReadLine()) != null)
                {

                    //Ignore comments
                    if(row[0] == '#')continue;

                    //Split row into a list of parameters
                    IList<string> spltRow = row.Split(",");

                    //First Row                   
                    if(firstLine)
                    {                                         
                        //Asign existing parameters and their curresponding collumn numb
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


                    //Create new Planet instance
                    //Don't really like the Trim but going to keep it there for now
                    //God this needs a rework
                    Planet newPlanet = new Planet
                    (
                        name: 
                            FormatParToString(par["pl_name"], spltRow),
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

                    //Asign new instance to a list
                    planetCol.Add(newPlanet);

                }



            }
        
        
            Planet testplanet = planetCol[21];
            Console.WriteLine(testplanet.Name + " -- " + testplanet.Mass
            );
        
        }








        /// <summary>
        /// Formats the received string into a string the program can utilize
        /// </summary>
        /// <param name="par"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private string FormatParToString(int? par, IList<string> row)
        {
            if(par == null) return null;

            int newPar = par ?? 0;
            string value = row[newPar].Trim();

            return value;
        }


        //https://stackoverflow.com/questions/209160/nullable-type-as-a-generic-parameter-possible

        /// <summary>
        /// Formats the received string into a int the program can utilize
        /// </summary>
        /// <param name="par"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private Nullable<T> FormatPar<T>(int? par, IList<string> row) 
            where T: struct
        { 
            //Get formated string
            string val = FormatParToString(par, row);
            if(val == null) return null;
            
            //Format T
            T value;       
        
            //https://stackoverflow.com/questions/2961656/generic-tryparse
            
            try
            {
                value = 
                    (T)TypeDescriptor.GetConverter(typeof(T))
                        .ConvertFromString(val);         
            }
            catch 
            {
                return null;
            }
            
            return value;

        }

    }
}