namespace Astrofinder
{
    public class StarQueryParams
    {
        public string Name { get; private set; }

        public float? MinTemp { get; private set; }

        public float? MaxTemp { get; private set; }

        public float? MinAge { get; private set; }

        public float? MaxAge { get; private set; }

        public float? MinRotVel { get; private set; }

        public float? MaxRotVel { get; private set; }

        public float? MinRotPer { get; private set; }

        public float? MaxRotPer { get; private set; }

        public float? MinRadius { get; private set; }

        public float? MaxRadius { get; private set; }

        public float? MinMass { get; private set; }

        public float? MaxMass { get; private set; }

        public float? MinSunDist { get; private set; }

        public float? MaxSunDist { get; private set; }

        public void UpdateParam(QueryParam param, string value)
        {
            switch (param)
            {
                case QueryParam.S_NAME:
                    Name = value;
                    break;

                default:
                    break;
            }
        }

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
                    break;
                    
            }
        }
    }
}