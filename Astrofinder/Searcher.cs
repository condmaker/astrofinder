using System.Collections.Generic;
using System.Linq;
using System;

namespace Astrofinder
{
    public class Searcher
    {
        private ICollection<Planet> Planets { get; }
        private IEnumerable<Star> Stars { get; }

        public Searcher(IEnumerable<Planet> Planets)
        {
            this.Planets = new List<Planet>(Planets);
            
            // todo
            this.Stars = new List<Star>();
        }

        public ICollection<Planet> SearchPlanets(PlanetQueryParams q)
        {
            IEnumerable<Planet> queriedPlanets = 
                from p in Planets
                where ((p.Name.ToLower().Contains(q.Name ?? "")) &&
                        p.HostName.ToLower().Contains(q.HostName ?? "") &&
                        p.DiscMethod.ToLower().Contains(q.DiscMethod ?? "")  &&
                        (p.DiscYear >= (q.MinDiscYear ?? p.DiscYear) && 
                        p.DiscYear  <= (q.MaxDiscYear ?? p.DiscYear) || 
                        p.DiscYear == null) &&
                        (p.OrbitalPeriod >= 
                            (q.MinOrbitalPeriod ?? p.OrbitalPeriod)  && 
                        p.OrbitalPeriod  <= 
                            (q.MaxOrbitalPeriod ?? p.OrbitalPeriod) || 
                        p.OrbitalPeriod == null) &&
                        (p.Radius >= (q.MinRadius ?? p.Radius)  && 
                        p.Radius  <= (q.MaxRadius ?? p.Radius) || 
                        p.Radius == null) &&
                        (p.Mass >= (q.MinMass ?? p.Mass)  && 
                        p.Mass  <= (q.MaxMass ?? p.Mass) || 
                        p.Mass == null) &&
                        (p.EqTemp >= (q.MinTemp ?? p.EqTemp)  && 
                        p.EqTemp  <= (q.MaxTemp ?? p.EqTemp) || 
                        p.EqTemp == null)
                        )
                select p;

            return queriedPlanets as ICollection<Planet>;
        }

        public IEnumerable<Star> SearchStars(StarQueryParams q)
        {
            
            IEnumerable<Star> queriedStars =
            from star in Stars
            where (star.Name.ToLower().Contains(q.Name ?? "") &&
                    star.Temperature >= (q.MinTemp ?? star.Temperature) &&
                    star.Temperature >= (q.MaxTemp ?? star.Temperature) &&
                    star.Age >= (q.MinAge ?? star.Age) &&
                    star.Age >= (q.MaxAge ?? star.Age) &&
                    star.RotVelocity >= (q.MinRotVel ?? star.RotVelocity) &&
                    star.RotVelocity >= (q.MaxRotVel ?? star.RotVelocity) &&
                    star.RotPeriod >= (q.MinRotPer ?? star.RotPeriod) &&
                    star.RotPeriod >= (q.MaxRotPer ?? star.RotPeriod) &&
                    star.Radius >= (q.MinRadius ?? star.Radius) &&
                    star.Radius >= (q.MaxRadius ?? star.Radius) &&
                    star.Mass >= (q.MinMass ?? star.Mass) &&
                    star.Mass >= (q.MaxMass ?? star.Mass) &&
                    star.SunDistance >= (q.MinSunDist ?? star.SunDistance) &&
                    star.SunDistance >= (q.MaxSunDist ?? star.SunDistance)
                    )
            select star;

            return queriedStars;
        }

        public Planet GetPlanet(string name)
        {
            Planet p = Planets.First<Planet>(planet => planet.Name ==  name);
            return p;
        }

        public Star GetStar(string name)
        {
            Star s = Stars.First<Star>(star => star.Name ==  name);
            return s;
        }
    }
}