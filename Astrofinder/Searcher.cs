using System.Collections.Generic;
using System.Linq;

namespace Astrofinder
{
    /// <summary>
    /// Class responsible for storing collections of Planets and Stars, and 
    /// executing the LINQ Queries.
    /// </summary>
    public class Searcher
    {
        /// <summary>
        /// Auto implemented read only property which represents the collection 
        /// of Planets.
        /// </summary>
        /// <value>Collection of Planets.</value>
        private IEnumerable<Planet> Planets { get; }

        /// <summary>
        /// Auto implemented read only property which represents the collection 
        /// of Stars.
        /// </summary>
        /// <value>Collection of Stars.</value>
        private IEnumerable<Star> Stars { get; }

        /// <summary>
        /// Constructor method, instantiates a new Searcher.
        /// </summary>
        /// <param name="Planets">Collection of Planets.</param>
        /// <param name="Stars">Collection of Stars.</param>
        public Searcher(IEnumerable<Planet> Planets, IEnumerable<Star> Stars)
        {
            this.Planets = new List<Planet>(Planets);

            this.Stars = new List<Star>(Stars);
        }

        /// <summary>
        /// Method responsible for executing the LINQ Query on the Planets 
        /// Collection and returning the results as IEnumerable<Planet>.
        /// </summary>
        /// <param name="q">Query Parameters.</param>
        /// <returns>Collection of Planets resulting from the query.</returns>
        public IEnumerable<Planet> SearchPlanets(PlanetQueryParams q)
        {
            IEnumerable<Planet> queriedPlanets = 
                from p in Planets
                where (
                        //Planet name
                        (p.Name.ToLower().Contains(q.Name ?? "")) &&

                        // Host name
                        p.HostName.ToLower().Contains(q.HostName ?? "") &&

                        // Discovery method
                        (p.DiscMethod.ToLower().Contains(q.DiscMethod ?? "") ||
                        (p.DiscMethod == null && q.DiscMethod == null) ) &&

                        // Greater  or equal to minimun discovery year
                        (p.DiscYear >= (q.MinDiscYear ?? p.DiscYear) && 
                        // Less or equal to maximun discovery year
                        p.DiscYear  <= (q.MaxDiscYear ?? p.DiscYear) || 
                        // Any discovery year and planet has no recorded
                        // discovery year
                        (q.MaxDiscYear == null && q.MinDiscYear == null &&
                        p.DiscYear == null)) &&

                        // Greater  or equal to minimun orbital period
                        (p.OrbPeriod >= 
                            (q.MinOrbPeriod ?? p.OrbPeriod)  && 
                        // Less or equal to maximun orbital period
                        p.OrbPeriod  <= 
                            (q.MaxOrbPeriod ?? p.OrbPeriod) || 
                        // Any orbital period, and planet has no recorded 
                        // orbital period
                        (p.OrbPeriod == null) &&
                        q.MaxOrbPeriod == null && 
                        q.MaxOrbPeriod == null) &&

                        // Greater  or equal to minimun radius
                        (p.Radius >= (q.MinRadius ?? p.Radius)  && 
                        // Less or equal to maximun radius
                        p.Radius  <= (q.MaxRadius ?? p.Radius) || 
                        // Any radius and planet has no recorded radius
                        (p.Radius == null &&
                        q.MinRadius == null && q.MaxRadius == null)) &&

                        // Greater  or equal to minimun mass
                        (p.Mass >= (q.MinMass ?? p.Mass)  && 
                        // Less or equal to maximun mass
                        p.Mass  <= (q.MaxMass ?? p.Mass) || 
                        // Any mass and planet has no recorded mass
                        (p.Mass == null &&
                        q.MinMass == null && q.MaxMass == null)) &&

                        // Greater  or equal to minimun temperature
                        (p.EqTemp >= (q.MinTemp ?? p.EqTemp)  && 
                        // Less or equal to maximun temperature
                        p.EqTemp  <= (q.MaxTemp ?? p.EqTemp) || 
                        // Any mass and planet has no recorded temperature
                        (p.EqTemp == null &&
                        q.MaxTemp == null && q.MinTemp == null))
                    ) // end  where
                select p;

            return queriedPlanets;
        }

        /// <summary>
        /// Method responsible for executing the LINQ Query on the Star 
        /// Collection and returning the results as IEnumerable<Star>.
        /// </summary>
        /// <param name="q">Query Parameters.</param>
        /// <returns>Collection of Stars resulting from the query.</returns>
        public IEnumerable<Star> SearchStars(StarQueryParams q)
        {
            
            IEnumerable<Star> queriedStars =
                from star in Stars
                where (
                        // Star name
                        star.Name.ToLower().Contains(q.Name ?? "") &&

                        // Greater  or equal to minimun temperature
                        (star.Temperature >= (q.MinTemp ?? star.Temperature) &&
                        // Less or equal ot maximun temperature
                        star.Temperature >= (q.MaxTemp ?? star.Temperature) ||
                        // Any temperature and star has no recorded temperature
                        (star.Temperature == null &&
                        q.MinTemp == null && q.MaxTemp == null)) &&

                        //Greater  or equal to minimun age
                        (star.Age >= (q.MinAge ?? star.Age) &&
                        // Less or equal ot maximun age
                        star.Age <= (q.MaxAge ?? star.Age) ||
                        // Any age and star has no recorded age
                        (star.Age == null &&
                        q.MinAge == null && q.MaxAge == null)) &&

                        // Greater  or equal to minimun rotation velocity
                        (star.RotVelocity >= (q.MinRotVel ?? star.RotVelocity)&&
                        // Less or equal ot maximun rotation velocity
                        star.RotVelocity <= (q.MaxRotVel ?? star.RotVelocity) ||
                        // Any Rot velocity and star has no recorded rotvelocity
                        (star.RotVelocity == null &&
                        q.MinRotVel == null && q.MaxRotVel == null)) &&

                        // Greater  or equal to minimun rotation period
                        (star.RotPeriod >= (q.MinRotPer ?? star.RotPeriod) &&
                        // Less or equal ot maximun rotation period
                        star.RotPeriod <= (q.MaxRotPer ?? star.RotPeriod) ||
                        // Any Rot period and star has no recorded rot period
                        (star.RotPeriod == null &&
                        q.MinRotPer == null && q.MaxRotPer == null)) &&

                        // Greater or equal to minimun radius
                        (star.Radius >= (q.MinRadius ?? star.Radius) &&
                        // Less or equal ot maximun age
                        star.Radius <= (q.MaxRadius ?? star.Radius)||
                        // Any radius and star has no recorded radius
                        (star.Radius == null &&
                        q.MinRadius == null && q.MaxRadius == null)) &&

                        // Greater or equal to minimun mass
                        (star.Mass >= (q.MinMass ?? star.Mass) &&
                        // Less or equal ot maximun age
                        star.Mass <= (q.MaxMass ?? star.Mass) ||
                        // Any age and star has no recorded age
                        (star.Mass == null &&
                        q.MinMass == null && q.MaxMass == null)) &&

                        // Greater  or equal to minimun distance to Sun
                        (star.SunDistance >=(q.MinSunDist ?? star.SunDistance)&&
                        // Less or equal ot maximun age
                        star.SunDistance <= (q.MaxSunDist ?? star.SunDistance)||
                        // Any dist. to sun and star has no recorded dist. to 
                        // sun
                        (star.SunDistance == null &&
                        q.MinSunDist ==null && q.MaxSunDist == null))
                    ) // end where
                select star;

            return queriedStars;
        }

        /// <summary>
        /// Returns a Planet object with specified name.
        /// </summary>
        /// <param name="name">Specified name.</param>
        /// <returns>Planet with given name.</returns>
        public Planet GetPlanet(string name)
        {
            Planet p = Planets.First<Planet>(planet => planet.Name.Equals(name));
            return p;
        }

        /// <summary>
        /// Returns a Star object with specified name.
        /// </summary>
        /// <param name="name">Specified name.</param>
        /// <returns>Star with given name.</returns>
        public Star GetStar(string name)
        {
            Star s = Stars.First<Star>(star => star.Name.Equals(name));
            return s;
        }

        /// <summary>
        /// Method responsible for executing a complex query on the Planet 
        /// collection, filtering parameters from both Planets and Stars, and 
        /// returning the results as IEnumerable<planet>.
        /// </summary>
        /// <param name="sq">Query parameters for the Stars.</param>
        /// <param name="pq">Query parameters for the planets</param>
        /// <returns>Collection of Planets resulting from the query.</returns>
        public IEnumerable<Planet> ComplexPlanetSearch(StarQueryParams sq, 
            PlanetQueryParams pq)
        {
            IEnumerable<Star> stars = SearchStars(sq);
            IEnumerable<Planet> planets = SearchPlanets(pq);

            IEnumerable<Planet> query =
                from s in stars
                join p in planets on s.Name equals p.HostName
                select p;

            return query;
        }

        /// <summary>
        /// Method responsible for executing a complex query on the Star 
        /// collection, filtering parameters from both Planets and Stars, and 
        /// returning the results as IEnumerable<planet>.
        /// </summary>
        /// <param name="sq">Query parameters for the Stars.</param>
        /// <param name="pq">Query parameters for the planets</param>
        /// <returns>Collection of Stars resulting from the query.</returns>
        public IEnumerable<Star> ComplexStarSearch(StarQueryParams sq, 
            PlanetQueryParams pq)
        {
            IEnumerable<Star> stars = SearchStars(sq);
            IEnumerable<Planet> planets = SearchPlanets(pq);

            IEnumerable<Star> query =
                from s in stars
                join p in planets on s.Name equals p.HostName
                select s;

            return query;
        }
    }
}