using System.IO;
using System;
using System.Collections.Generic;


namespace Astrofinder
{

    public class FileReader
    {
        
        private List<Planet> testlist = new List<Planet>();
        private Dictionary<string, int> par;

        public FileReader()
        {
            par = new Dictionary<string, int>();
            par.Add("pl_name", 0);
            par.Add("hostname", 0);

            teste();
            
        }

        public void teste()
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
                    Planet newPlanet = new Planet
                    (
                        name: spltRow[par["pl_name"]].Trim(),
                        hostname: spltRow[par["hostname"]].Trim()
                    );

                    //Asign new instance to a list
                    testlist.Add(newPlanet);

                }



            }
        
        
            Planet testplanet = testlist[24];
            Console.WriteLine(testplanet.Name + " -- " + testplanet.HostName );
        
        }

        


    }
}