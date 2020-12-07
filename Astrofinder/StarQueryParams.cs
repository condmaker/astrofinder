namespace Astrofinder
{
    /// <summary>
    /// Struct that stores all the values that can be used in a Star Query.
    /// </summary>
    public class StarQueryParams
    {
        /// <summary>
        /// Auto implemented property which represents a string contained 
        /// within the stars names.
        /// </summary>
        /// <value>The string to be queried in the stars names.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// temperature.
        /// </summary>
        /// <value>The star's minimun temperature.</value>
        public float? MinTemp { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// temperature.
        /// </summary>
        /// <value>The star's maximun temperature.</value>
        public float? MaxTemp { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// age.
        /// </summary>
        /// <value>The star's minimun age.</value>
        public float? MinAge { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// age.
        /// </summary>
        /// <value>The star's maximun age.</value>
        public float? MaxAge { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// rotation velocity.
        /// </summary>
        /// <value>The star's minimun rotation velocity.</value>
        public float? MinRotVel { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// rotation velocity.
        /// </summary>
        /// <value>The star's maximun rotation velocity.</value>
        public float? MaxRotVel { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// rotation period.
        /// </summary>
        /// <value>The star's minimun rotation period.</value>
        public float? MinRotPer { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// rotation period.
        /// </summary>
        /// <value>The star's maximun rotation period.</value>
        public float? MaxRotPer { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// radius.
        /// </summary>
        /// <value>The star's minimun radius.</value>
        public float? MinRadius { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// radius.
        /// </summary>
        /// <value>The star's maximun radius.</value>
        public float? MaxRadius { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// mass.
        /// </summary>
        /// <value>The star's minimun mass.</value>
        public float? MinMass { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// mass.
        /// </summary>
        /// <value>The star's maximun mass.</value>
        public float? MaxMass { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's minimun 
        /// distance to the sun.
        /// </summary>
        /// <value>The star's minimun distance to the sun.</value>
        public float? MinSunDist { get; private set; }

        /// <summary>
        /// Auto implemented property which represents the star's maximun 
        /// distance to the sun.
        /// </summary>
        /// <value>The star's maximun distance to the sun.</value>
        public float? MaxSunDist { get; private set; }

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
                case QueryParam.S_NAME:
                    Name = value;
                    break;

                default:
                    throw (new InvalidValueException("This parameter doesn't accept strings."));
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
                case QueryParam.S_MIN_TEMP:
                    MinTemp = value;
                    break;

                case QueryParam.S_MAX_TEMP:
                    MaxTemp = value;
                    break;
                
                case QueryParam.S_MIN_AGE:
                    MinAge = value;
                    break;

                case QueryParam.S_MAX_AGE:
                    MaxAge = value;
                    break;

                case QueryParam.S_MIN_ROT_VEL:
                    MinRotVel = value;
                    break;

                case QueryParam.S_MAX_ROT_VEL:
                    MaxRotVel = value;
                    break;

                case QueryParam.S_MIN_ROT_PERIOD:
                    MinRotPer = value;
                    break;

                case QueryParam.S_MAX_ROT_PERIOD:
                    MaxRotPer = value;
                    break;

                case QueryParam.S_MIN_RADIUS:
                    MinRadius = value;
                    break;

                case QueryParam.S_MAX_RADIUS:
                    MaxRadius = value;
                    break;

                case QueryParam.S_MIN_MASS:
                    MinMass = value;
                    break;

                case QueryParam.S_MAX_MASS:
                    MaxMass = value;
                    break;

                case QueryParam.S_MIN_SUN_DISTANCE:
                    MinSunDist = value;
                    break;

                case QueryParam.S_MAX_SUN_DISTANCE:
                    MaxSunDist = value;
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
            MinAge = null;
            MaxAge = null;
            MinRotVel = null;
            MaxRotVel = null;
            MinRotPer = null;
            MaxRotPer = null;
            MinSunDist = null;
            MaxSunDist = null;
            MinRadius = null;
            MaxRadius = null;
            MinMass = null;
            MaxMass = null;
            MinTemp = null;
            MaxTemp = null;
        }
    }
}