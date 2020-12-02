namespace Astrofinder
{
    public struct Planet
    {
        //Assumi q isto existia apesar de ser o hostname
        public string Name { get; private set;}
        //st_teff
        public string DiscMethod { get; private set;}
        //disc_year 
        public short? DiscYear { get; private set;}
        //pl_orber
        public float? OrbitalPeriod { get; private set;}
        //pl_rade
        public float? Radius { get; private set;}
        //pl_masse
        public float? Mass { get; private set;}
        //pl_eqt
        public short? EqTemp { get; private set;}
    }
}