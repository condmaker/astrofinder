using System.Collections.Generic;

namespace Astrofinder
{
    public class Handler
    {
        private Searcher searcher;
        private PlanetQueryParams planetQueries;
        private StarQueryParams starQueries;

        //testing - delete
        public Handler()
        {
            List<Planet> p = new List<Planet>();
            p.Add(new Planet("Planeta 1", "star 1"));
            p.Add(new Planet("Planet 2", "star 1", discY: 1980));
            p.Add(new Planet("Planeta 3", "star 2"));
            p.Add(new Planet("Args 1", "star 2"));
            p.Add(new Planet("Args 2", "star 3"));

            IEnumerable<Star> s = new List<Star>();
            searcher = new Searcher(p, s);
        }


        // receber filename de UI e invocar FileReader
        public void ReadFile(string path)
        {
            FileReader fr = new FileReader(path);
            //searcher = new Searcher(); // falta os enumerables

            
            starQueries = new StarQueryParams();
            planetQueries = new PlanetQueryParams();
        }

        // Receber QueryParams e value de consoleclient e atualizar query params
        public void UpdateParams(QueryParam param, string value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        public void UpdateParams(QueryParam param, short? value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        public void UpdateParams(QueryParam param, float? value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        // Enviar lista para ConsoleClient
        public IEnumerable<Planet> SearchPlanets()
        {
            return searcher.SearchPlanets(planetQueries);
        }

        // Enviar lista para ConsoleClient
        public IEnumerable<Star> SearchStars()
        {
            return searcher.SearchStars(starQueries);
        }

        // Enviar planet / estrela para UI
        public Planet ViewPlanet(string name)
        {
            return searcher.GetPlanet(name);
        }

        // Enviar planet / estrela para UI
        public Star ViewStar(string name)
        {
            return searcher.GetStar(name);
        }
    }
}