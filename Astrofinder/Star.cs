namespace Astrofinder
{
    public struct Star
    {
        //hostname-- Assumi q isto vai ser assim
        public string Name {get; set;}        
        //st_teff 
        public short? Temperature {get; set;}
        //st_age 
        public short? Age {get;set;}
        //st_vsin 
        public float? RotVelocity {get; set;}
        //st_rotp 
        public float? RotPeriod {get; set;}
        //st_rad 
        public float? Radius {get; set;}
        //st_mass 
        public float? Mass {get; set;}
        //sy_dist 
        public float? SunDistance {get; set;}


    }
}