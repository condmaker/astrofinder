namespace Astrofinder
{
    public struct Planet
    {
        //pl_name
        public string Name { get; private set; }
        //hostname
        public string HostName{ get;private set; }
        //discoverymethod
        public string DiscMethod { get; private set; }
        //disc_year 
        public short? DiscYear { get; private set; }
        //pl_orber
        public float? OrbitalPeriod { get; private set; }
        //pl_rade
        public float? Radius { get; private set; }
        //pl_masse
        public float? Mass { get; private set ; }
        //pl_eqt
        public short? EqTemp { get; private set; }
    
        
        //Don't really know y the "this" but without it there's an error
        //struct and properties shenanigans 
        public Planet(string name, string hostname, string discM = "",
        short? discY = null,  float? orber = null, float? radius = null,
        float? mass = null, short? eqTemp = null ) : this()
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

        
    }
}