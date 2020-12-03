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

        public void UpdateParam(string param, string value)
        {
            switch (param)
            {
                case "Name":
                    Name = value;
                    break;
                case "HostName":
                    HostName = value;
                    break;
                case "DiscMethod":
                    DiscMethod = value;
                    break;
                default:
                    break;
            }
        }

        public void UpdateParam(string param, short? value)
        {
            switch (param)
            {
                case "MinDiscYear":
                    MinDiscYear = value;
                    break;

                case "MaxDiscYear":
                    MaxDiscYear = value;
                    break;
                
                case "MinOrbitalPeriod":
                    MinOrbitalPeriod = value;
                    break;

                case "MaxOrbitalPeriod":
                    MaxOrbitalPeriod = value;
                    break;
                default:
                    break;
                    
            }
        }

            public void UpdateParam(string param, float? value)
        {
            switch (param)
            {
                case "MinRadius":
                    MinRadius = value;
                    break;

                case "MaxRadius":
                    MaxRadius = value;
                    break;
                
                case "MinMass":
                    MinMass = value;
                    break;

                case "MaxMass":
                    MaxMass = value;
                    break;

                case "MinTemp":
                    MinTemp = value;
                    break;

                case "MaxTemp":
                    MaxTemp = value;
                    break;
                default:
                    break;
            }
        }
    }
}