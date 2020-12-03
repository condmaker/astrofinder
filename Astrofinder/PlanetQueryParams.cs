namespace Astrofinder
{
    public struct PlanetQueryParams
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }

        public string HostName { get; private set; }

        public string DiscMethod { get; private set; }

        public short? MinDiscYear { get; private set; }

        public short? MaxDiscYear { get; private set; }

        public short? MinOrbitalPeriod { get; private set; }

        public short? MaxOrbitalPeriod { get; private set; }

        public float? MinRadius { get; private set; }

        public float? MaxRadius { get; private set; }

        public float? MinMass { get; private set; }

        public float? MaxMass { get; private set; }

        public float? MinTemp { get; private set; }

        public float? MaxTemp { get; private set; }

        public void UpdateParam(QueryParam param, string value)
        {
            if(value != null)
                value = value.ToLower();
            switch (param)
            {
                case QueryParam.P_NAME:
                    Name = value;
                    break;
                case QueryParam.P_HOST_NAME:
                    HostName = value;
                    break;
                case QueryParam.P_DISC_METHOD:
                    DiscMethod = value;
                    break;
                default:
                    break;
            }
        }

        public void UpdateParam(QueryParam param, short? value)
        {
            switch (param)
            {
                case QueryParam.P_MIN_DISC_YEAR:
                    MinDiscYear = value;
                    break;

                case QueryParam.P_MAX_DISC_YEAR:
                    MaxDiscYear = value;
                    break;
                
                case QueryParam.P_MIN_ORBITAL_PERIOD:
                    MinOrbitalPeriod = value;
                    break;

                case QueryParam.P_MAX_ORBITAL_PERIOD:
                    MaxOrbitalPeriod = value;
                    break;
                default:
                    break;
                    
            }
        }

            public void UpdateParam(QueryParam param, float? value)
        {
            switch (param)
            {
                case QueryParam.P_MIN_RADIUS:
                    MinRadius = value;
                    break;

                case QueryParam.P_MAX_RADIUS:
                    MaxRadius = value;
                    break;
                
                case QueryParam.P_MIN_MASS:
                    MinMass = value;
                    break;

                case QueryParam.P_MAX_MASS:
                    MaxMass = value;
                    break;

                case QueryParam.P_MIN_TEMP:
                    MinTemp = value;
                    break;

                case QueryParam.P_MAX_TEMP:
                    MaxTemp = value;
                    break;
                    
                default:
                    break;
            }
        }
    }
}