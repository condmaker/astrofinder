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
            searcher = new Searcher(); // falta os enumerables
        }

        // Receber QueryParams
         de UI e atualizar query params
        void UpdateParams(string filter)
        {

        }

        // Enviar lista para ConsoleClient
        IEnumerable<Planet> SearchPlanets()
        {
            searcher.SearchPlanets(planetQueries);
        }

        // Enviar lista para ConsoleClient
        List<Star> SearchStars()
        {

        }

        // Enviar planet / estrela para UI
        Planet ViewPlanet(string name)
        {

        }

        // Enviar planet / estrela para UI
        Star ViewStar(string name)
        {

        }
    }
}