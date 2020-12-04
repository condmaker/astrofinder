using System;
using System.Text;

namespace Astrofinder
{
    public class Planet: IEquatable<Planet>
    {
        public static Comparison<Planet> CompareByName = 
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.Name, p2.Name);
        };

        public static Comparison<Planet> CompareByHostName = 
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.HostName, p2.HostName);
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
            return p1?.EqTemp?.CompareTo(p2.EqTemp) ?? -1;
        };


        //pl_name
        public string Name { get; private set; }
        //hostname
        public string HostName{ get;private set; }
        //discoverymethod
        public string DiscMethod { get; private set; }
        //disc_year 
        public short? DiscYear {get; set;}
        //pl_orber
        public float? OrbitalPeriod {get;set;}
        //pl_rade
        public float? Radius {get; set;}
        //pl_masse
        public float? Mass {get; set;}
        //pl_eqt
        public short? EqTemp { get; private set; }


        public Planet(){}

        public Planet(string name, string hostname, string discM = "",
        short? discY = null,  float? orber = null, float? radius = null,
        float? mass = null, short? eqTemp = null )
        {
            Name = name;
            HostName = hostname;
            DiscMethod = discM;
            DiscYear = discY;
            OrbitalPeriod = orber;
            Radius = radius;
            Mass = mass;
            EqTemp = eqTemp;
        }

        public bool Equals(Planet other)
        {
            return this.Name == other.Name; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(
              $"{Name,-14}  {HostName,-14}  {DiscMethod,-14}  {DiscYear,-14}");
            
            sb.Append(
              $"  {OrbitalPeriod,-14}  {Radius,-14}  {Mass,-14}  {EqTemp,-14}");

            return sb.ToString();
        }

    }
}