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
    }
}