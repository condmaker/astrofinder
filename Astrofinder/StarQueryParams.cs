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

        public void UpdateParam(string param, string value)
        {
            switch (param)
            {
                case "Name":
                    Name = value;
                    break;

                default:
                    break;
            }
        }

        public void UpdateParam(string param, float? value)
        {
            switch (param)
            {
                case "MinTemp":
                    MinTemp = value;
                    break;

                case "MaxTemp":
                    MaxTemp = value;
                    break;
                
                case "MinAge":
                    MinAge = value;
                    break;

                case "MaxAge":
                    MaxAge = value;
                    break;

                case "MinRotVel":
                    MinRotVel = value;
                    break;

                case "MaxRotVel":
                    MaxRotVel = value;
                    break;

                case "MinRotPer":
                    MinRotPer = value;
                    break;

                case "MaxRotPer":
                    MaxRotPer = value;
                    break;

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

                case "MinSunDist":
                    MinSunDist = value;
                    break;

                case "MaxSunDist":
                    MaxSunDist = value;
                    break;

                default:
                    break;
                    
            }
        }
    }
}