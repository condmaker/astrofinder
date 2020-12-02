using System;

namespace Astrofinder
{
    public class Planet
    {
        public static Comparison<Planet> CompareByName = 
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.Name, p2.Name);
        };

        public static Comparison<Planet> CompareByHostName = 
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.Host, p2.Host);
        };

        public static Comparison<Planet> CompareByDiscMethod = 
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.DiscMethod, p2.DiscMethod);
        };

        public static Comparison<Planet> CompareByDiscYear = 
            delegate (Planet p1, Planet p2)
        {
            return p1?.DiscYear?.CompareTo(p2.DiscYear) ?? -1;
        };

        public static Comparison<Planet> CompareByOrbitalPeriod = 
            delegate (Planet p1, Planet p2)
        {
            return p1?.OrbitalPeriod?.CompareTo(p2.OrbitalPeriod) ?? -1;
        };

        public static Comparison<Planet> CompareByRadius = 
            delegate (Planet p1, Planet p2)
        {
            return p1?.Radius?.CompareTo(p2.Radius) ?? -1;
        };

        public static Comparison<Planet> CompareByMass = 
            delegate (Planet p1, Planet p2)
        {
            return p1?.Mass?.CompareTo(p2.Mass) ?? -1;
        };

        public static Comparison<Planet> CompareByTemperature = 
            delegate (Planet p1, Planet p2)
        {
            return p1?.Temperature?.CompareTo(p2.Temperature) ?? -1;
        };


        //pl_name
        public string Name {get; set;}
        //hostname
        public string Host {get; set;}
        //discoverymethod 
        public string DiscMethod {get; set;}
        //disc_year 
        public short? DiscYear {get; set;}
        //pl_orber
        public short? OrbitalPeriod {get;set;}
        //pl_rade
        public float? Radius {get; set;}
        //pl_masse
        public float? Mass {get; set;}
        //pl_eqt
        public float? Temperature {get; set;}
    }
}