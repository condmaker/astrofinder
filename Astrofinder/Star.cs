namespace Astrofinder
{
    public struct Star
    {
        //hostname-- Assumi q isto vai ser assim
        public string Name { get; private set; }        
        //st_teff 
        public short? Temperature { get; private set; }
        //st_age 
        public short? Age { get; private set; }
        //st_vsin 
        public float? RotVelocity { get; private set; }
        //st_rotp 
        public float? RotPeriod { get; private set; }
        //st_rad 
        public float? Radius { get; private set; }
        //st_mass 
        public float? Mass { get; private set; }
        //sy_dist 
        public float? SunDistance { get; private set; }
       
    }
}