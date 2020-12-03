using System.Collections.Generic;

namespace Astrofinder
{
    public class Searcher
    {
        private IEnumerable<Planet> Planets { get; }
        private IEnumerable<Star> Stars { get; }

        public Searcher(IEnumerable<Planet> Planets, IEnumerable<Star> Stars)
        {
            this.Planets = Planets;
            this.Stars = Stars;
        }

        //TODO
        public IEnumerable<Planet> SearchPlanets(PlanetQueryParams queries)
        {
            return new List<Planet>();
        }

        public IEnumerable<Star> SearchStars(StarQueryParams queries)
        {
            return new List<Star>();
        }

        public Planet GetPlanet(string name)
        {
            return new Planet();
        }

        public Star GetStar(string name)
        {
            return new Star();
        }
    }
}