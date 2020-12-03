using System.Collections.Generic;

namespace Astrofinder
{
    public class Handler
    {
        private Searcher searcher;
        private PlanetQueryParams planetQueries;
        private StarQueryParams starQueries;


        // receber filename de UI e invocar FileReader
        void ReadFile(string path)
        {
            FileReader fr = new FileReader(path);
            //searcher = new Searcher(); // falta os enumerables

            
            starQueries = new StarQueryParams();
            planetQueries = new PlanetQueryParams();
        }

        // Receber QueryParams e value de consoleclient e atualizar query params
        void UpdateParams(QueryParam param, string value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        void UpdateParams(QueryParam param, short? value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        void UpdateParams(QueryParam param, float? value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        // Enviar lista para ConsoleClient
        IEnumerable<Planet> SearchPlanets()
        {
            return searcher.SearchPlanets(planetQueries);
        }

        // Enviar lista para ConsoleClient
        IEnumerable<Star> SearchStars()
        {
            return searcher.SearchStars(starQueries);
        }

        // Enviar planet / estrela para UI
        Planet ViewPlanet(string name)
        {
            return searcher.GetPlanet(name);
        }

        // Enviar planet / estrela para UI
        Star ViewStar(string name)
        {
            return searcher.GetStar(name);
        }
    }
}