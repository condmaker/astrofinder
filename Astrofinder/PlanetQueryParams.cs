namespace Astrofinder
{
    /// <summary>
    /// Struct that stores all the values that can be used in a Planet Query.
    /// </summary>
    public struct PlanetQueryParams
    {
        /// <summary>
        /// Auto implemented property which represents a string contained 
        /// within the planets names.
        /// </summary>
        /// <value>The string to be queried in the planets names.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Auto implemented property which represents a string contained
        /// within the planet's hosts names.
        /// </summary>
        /// <value>The string to be queried in the planets hosts names.</value>
        public string HostName { get; private set; }

        /// <summary>
        /// Auto implemented property which represents a string contained
        /// within the planet's discovery method.
        /// </summary>
        /// <value>The string to be queried in the planets discovery 
        /// method.</value>
        public string DiscMethod { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// discovery year.
        /// </summary>
        /// <value>The planet's minimun discovery year.</value>
        public short? MinDiscYear { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// discovery year.
        /// </summary>
        /// <value>The planet's maximun discovery year.</value>
        public short? MaxDiscYear { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// orbital period.
        /// </summary>
        /// <value>The planet's minimun orbital period.</value>
        public short? MinOrbitalPeriod { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// orbital period.
        /// </summary>
        /// <value>The planet's maximun orbital period.</value>
        public short? MaxOrbitalPeriod { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// radius.
        /// </summary>
        /// <value>The planet's minimun radius.</value>
        public float? MinRadius { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// radius.
        /// </summary>
        /// <value>The planet's maximun radius.</value>
        public float? MaxRadius { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// mass.
        /// </summary>
        /// <value>The planet's minimun mass.</value>
        public float? MinMass { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// mass.
        /// </summary>
        /// <value>The planet's maximun mass.</value>
        public float? MaxMass { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// temperature.
        /// </summary>
        /// <value>The planet's minimun temperature.</value>
        public float? MinTemp { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// temperature.
        /// </summary>
        /// <value>The planet's maximun temperature.</value>
        public float? MaxTemp { get; private set; }

        /// <summary>
        /// Updates a specified parameter with a specified value.
        /// </summary>
        /// <param name="param">The specified Param to update.</param>
        /// <param name="value">The specified value.</param>
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

        /// <summary>
        /// Updates a specified parameter with a specified value.
        /// </summary>
        /// <param name="param">The specified Param to update.</param>
        /// <param name="value">The specified value.</param>
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

        /// <summary>
        /// Updates a specified parameter with a specified value.
        /// </summary>
        /// <param name="param">The specified Param to update.</param>
        /// <param name="value">The specified value.</param>
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