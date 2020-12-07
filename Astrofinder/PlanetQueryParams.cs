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
        /// <value>The planet's minimum discovery year.</value>
        public short? MinDiscYear { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// discovery year.
        /// </summary>
        /// <value>The planet's maximum discovery year.</value>
        public short? MaxDiscYear { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// orbital period.
        /// </summary>
        /// <value>The planet's minimum orbital period.</value>
        public short? MinOrbPeriod { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// orbital period.
        /// </summary>
        /// <value>The planet's maximum orbital period.</value>
        public short? MaxOrbPeriod { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// radius.
        /// </summary>
        /// <value>The planet's minimum radius.</value>
        public float? MinRadius { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// radius.
        /// </summary>
        /// <value>The planet's maximum radius.</value>
        public float? MaxRadius { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// mass.
        /// </summary>
        /// <value>The planet's minimum mass.</value>
        public float? MinMass { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// mass.
        /// </summary>
        /// <value>The planet's maximum mass.</value>
        public float? MaxMass { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's minimun 
        /// temperature.
        /// </summary>
        /// <value>The planet's minimum temperature.</value>
        public float? MinTemp { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the planet's maximun 
        /// temperature.
        /// </summary>
        /// <value>The planet's maximum temperature.</value>
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
                    throw (new InvalidValueException(
                        "This parameter doesn't accept strings."));
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
                    MinOrbPeriod = value;
                    break;

                case QueryParam.P_MAX_ORBITAL_PERIOD:
                    MaxOrbPeriod = value;
                    break;
                default:
                    throw (new InvalidValueException(
                        "This parameter doesn't accept short values."));
                    
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
                    throw (new InvalidValueException(
                        "This parameter doesn't accept float values."));
            }
        }

        /// <summary>
        /// Clears all of the params on the current instance.
        /// </summary>
        public void ClearParams()
        {
            Name = null;
            HostName = null;
            DiscMethod = null;
            MinDiscYear = null;
            MaxDiscYear = null;
            MinOrbPeriod = null;
            MaxOrbPeriod = null;
            MinRadius = null;
            MaxRadius = null;
            MinMass = null;
            MaxMass = null;
            MinTemp = null;
            MaxTemp = null;
        }
    }
}