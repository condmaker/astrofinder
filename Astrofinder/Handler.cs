using System.Collections.Generic;

namespace Astrofinder
{
    /// <summary>
    /// Facade Class responsible for providing an interface between Client and 
    /// the Searcher subsystems.
    /// </summary>
    public class Handler
    {
        /// <summary>
        /// Searcher object which stores collections of Stars and Planets.
        /// </summary>
        private Searcher searcher;

        /// <summary>
        /// File Reader object which open a file and distributes its data to the 
        /// searcher
        /// </summary>
        private FileReader fileReader;

        /// <summary>
        /// PlanetQueryParams object which stores the current query parameters 
        /// for searching planets.
        /// </summary>
        private PlanetQueryParams planetQueries;

        /// <summary>
        /// StarQueryParams object which stores the current query parameters 
        /// for searching stars.
        /// </summary>
        private StarQueryParams starQueries;

        /// <summary>
        /// Method responsible for receiving a specified .csv file and storing 
        /// it's contents into the Searcher object.
        /// </summary>
        /// <param name="path">Path to the specified .csv file.</param>
        public void ReadFile(string path)
        {
            fileReader = new FileReader(path);
            searcher = new Searcher(fileReader.planetCol, fileReader.starCol);

            
            starQueries = new StarQueryParams();
            planetQueries = new PlanetQueryParams();
        }

        /// <summary>
        /// Updates an specified QueryParam with the specified Value.
        /// </summary>
        /// <param name="param">The QueryParam to update.</param>
        /// <param name="value">The specified value.</param>
        public void UpdateParams(QueryParam param, string value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        /// <summary>
        /// Updates an specified QueryParam with the specified Value.
        /// </summary>
        /// <param name="param">The QueryParam to update.</param>
        /// <param name="value">The specified value.</param>
        public void UpdateParams(QueryParam param, short? value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }
        
        /// <summary>
        /// Updates an specified QueryParam with the specified Value.
        /// </summary>
        /// <param name="param">The QueryParam to update.</param>
        /// <param name="value">The specified value.</param>
        public void UpdateParams(QueryParam param, float? value)
        {
            if (param < QueryParam.S_NAME)
                planetQueries.UpdateParam(param, value);
            else
                starQueries.UpdateParam(param, value);
        }

        /// <summary>
        /// Clears the current planet parameters set by the user.
        /// </summary>
        public void ClearPlanetParams() => planetQueries.ClearParams();

        /// <summary>
        /// Clears the current star parameters set by the user.
        /// </summary>
        public void ClearStarParams() => starQueries.ClearParams();

        /// <summary>
        /// Returns a Planet Colletion containing the results from the query 
        /// with the stored parameters.
        /// </summary>
        /// <returns>An IEnumerable<Planet> object with the results from the 
        /// query.</returns>
        public IEnumerable<Planet> SearchPlanets()
        {
            return searcher.SearchPlanets(planetQueries);
        }

        /// <summary>
        /// Returns a Star Colletion containing the results from the query with 
        /// the stored parameters.
        /// </summary>
        /// <returns>An IEnumerable<Star> object with the results from the 
        /// query.</returns>
        public IEnumerable<Star> SearchStars()
        {
            return searcher.SearchStars(starQueries);
        }

        /// <summary>
        /// Returns a Planet object with the specified name.
        /// </summary>
        /// <param name="name">The specified planet name.</param>
        /// <returns></returns>
        public Planet ViewPlanet(string name)
        {
            return searcher.GetPlanet(name);
        }

        /// <summary>
        /// Returns a Star object with the specified name.
        /// </summary>
        /// <param name="name">The specified star name.</param>
        /// <returns></returns>
        public Star ViewStar(string name)
        {
            return searcher.GetStar(name);
        }

        /// <summary>
        /// Returns a Planet Colletion containing the results from the complex 
        /// query with the stored parameters.
        /// </summary>
        /// <returns>An IEnumerable<Star> object with the results from the 
        /// query.</returns>
        public IEnumerable<Planet> AdvancedSearchPlanets(){
            return searcher.ComplexPlanetSearch(starQueries, planetQueries);
        }

        /// <summary>
        /// Returns a Star Colletion containing the results from the complex 
        /// query with the stored parameters.
        /// </summary>
        /// <returns>An IEnumerable<Star> object with the results from the 
        /// query.</returns>
        public IEnumerable<Star> AdvancedSearchStars(){
            return searcher.ComplexStarSearch(starQueries, planetQueries);
        }
    }
}