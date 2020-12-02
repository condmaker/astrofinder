namespace Astrofinder
{
    public struct Planet
    {
        //pl_name
        public string Name {get; set;}
        //hostname
        public string Host {get; set;}
        //discoverymethod 
        public string DiscMethod {get; set;}
        //disc_year 
        public short DiscYear {get; set;}
        //pl_orber
        public short OrbitalPeriod {get;set;}
        //pl_rade
        public float Radius {get; set;}
        //pl_masse
        public float Mass {get; set;}
        //pl_eqt
        public float Temperature {get; set;}
    }
}