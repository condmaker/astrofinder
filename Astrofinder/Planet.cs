using System;
using System.Text;

namespace Astrofinder
{
    /// <summary>
    /// Class responsible for storing data from a Planet.
    /// </summary>
    public class Planet : IEquatable<Planet>, ICelestialBody
    {
        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Names.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByName =
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.Name, p2.Name);
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their HostName.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByHostName =
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.HostName, p2.HostName);
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Discovery Methods.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByDiscMethod =
            delegate (Planet p1, Planet p2)
        {
            return String.Compare(p1.DiscMethod, p2.DiscMethod);
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Discovery Year.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByDiscYear =
            delegate (Planet p1, Planet p2)
        {
            if (p1.DiscYear == null & p2.DiscYear == null)
                return 0;
            if (p2.DiscYear == null)
                return -1;
            return p1?.DiscYear?.CompareTo(p2.DiscYear) ?? 1;
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Orbital Period.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByOrbPeriod =
            delegate (Planet p1, Planet p2)
        {
            if (p1.OrbPeriod == null & p2.OrbPeriod == null)
                return 0;
            if (p2.OrbPeriod == null)
                return -1;
            return p1?.OrbPeriod?.CompareTo(p2.OrbPeriod) ?? 1;
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Radius.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByRadius =
            delegate (Planet p1, Planet p2)
        {
            if (p1.Radius == null & p2.Radius == null)
                return 0;
            if (p2.Radius == null)
                return -1;
            return p1?.Radius?.CompareTo(p2.Radius) ?? 1;
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Mass.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByMass =
            delegate (Planet p1, Planet p2)
        {
            if (p1.Mass == null & p2.Mass == null)
                return 0;
            if (p2.Mass == null)
                return -1;
            return p1?.Mass?.CompareTo(p2.Mass) ?? 1;
        };

        /// <summary>
        /// Compares two specified Planet objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Temperature.
        /// </summary>
        /// <param name="p1">The first Planet to compare.</param>
        /// <param name="p2">The second Planet to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="p1"> is less than
        /// <paramref name="p2">, 0 if <paramref name="p1"> equals 
        /// <paramref name="p2">, and greater than 0 if <paramref name="p1">
        /// is greater than <paramref name="p2">.</returns>
        public static Comparison<Planet> CompareByTemperature =
            delegate (Planet p1, Planet p2)
        {
            if (p1.EqTemp == null & p2.EqTemp == null)
                return 0;
            if (p2.EqTemp == null)
                return -1;
            return p1?.EqTemp?.CompareTo(p2.EqTemp) ?? 1;
        };



        /// <summary>
        /// Planet name. Derived from pl_name column.
        /// </summary>
        /// <value>Planet's name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Planet's host star's name. Derived from hostname column.
        /// </summary>
        /// <value>Planet's host star name.</value>
        public string HostName { get; private set; }

        /// <summary>
        /// Planet's discovery method. Derived from discoverymethod column.
        /// </summary>
        /// <value>Planet's discovery method.</value>
        public string DiscMethod { get; private set; }

        /// <summary>
        /// Planet's discovery year. Derived from disc_year column.
        /// </summary>
        /// <value>Planet's discovery year.</value>
        public short? DiscYear { get; set; }

        /// <summary>
        /// Planet's orbital period . Derived from pl_orber column.
        /// </summary>
        /// <value>Planet's orbital period (in days).</value>
        public float? OrbPeriod { get; set; }

        /// <summary>
        /// Planet's radius relative to Earth. Derived from pl_rade column.
        /// </summary>
        /// <value>Planet's radius (relative to Earth).</value>
        public float? Radius { get; set; }

        /// <summary>
        /// Planet's mass relative to Earth. Derived from pl_masse column.
        /// </summary>
        /// <value>Planet's mass (relative to Earth).</value>
        public float? Mass { get; set; }

        /// <summary>
        /// Planet's temperature. Derived from pl_eqt column.
        /// </summary>
        /// <value>Planet's temperature (in Kelvin).</value>
        public short? EqTemp { get; private set; }

        /// <summary>
        /// Constructor method.Instantiates a new Planet.
        /// </summary>
        /// <param name="name">Planet's unique name.</param>
        /// <param name="hostname">Planet's host star name.</param>
        /// <param name="discM">Planet's discovery method.</param>
        /// <param name="discY">Planet's discovery year.</param>
        /// <param name="orber">Planet's orbital period.</param>
        /// <param name="radius">Planet's radius.</param>
        /// <param name="mass">Planet's mass.</param>
        /// <param name="eqTemp">Planet's temperature.</param>
        public Planet(string name, string hostname, string discM = "",
        short? discY = null, float? orber = null, float? radius = null,
        float? mass = null, short? eqTemp = null)
        {
            Name = name;
            HostName = hostname;
            DiscMethod = discM;
            DiscYear = discY;
            OrbPeriod = orber;
            Radius = radius;
            Mass = mass;
            EqTemp = eqTemp;
        }

        /// <summary>
        /// Determines whether the specified Planet is equal to the current 
        /// Planet.
        /// </summary>
        /// <param name="other">The Planet to compare with the current 
        /// Planet.</param>
        /// <returns><c>true</c> if the specified Planet is equal to the 
        /// current Planet; otherwise <c>false</c>.</returns>
        public bool Equals(Planet other)
        {
            return this.Name == other.Name;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string nS = "N/A";

            // Obligatory Parameters, cannot be null
            sb.Append(
             $"{Name.MaxLength(14),-14}  {HostName.MaxLength(14),-14}  ");
            // Optional Parameters, can be null
            sb.Append(
             $"{(DiscMethod != null ? DiscMethod.MaxLength(14) : nS),-14}  ");
            sb.Append(
             $"{(DiscYear.HasValue ? DiscYear.ToString() : nS),-14}  ");
            sb.Append(
             $"{(OrbPeriod.HasValue ? OrbPeriod.ToString() : nS),-14}  ");
            sb.Append(
             $"{(Radius.HasValue ? Radius.ToString() : nS),-14}  ");
            sb.Append(
             $"{(Mass.HasValue ? Mass.ToString() : nS),-14}  ");
            sb.Append(
             $"{(EqTemp.HasValue ? EqTemp.ToString() : nS),-14}");

            return sb.ToString();
        }
        public string ToStringDetailed()
        {
            StringBuilder sb = new StringBuilder();
            string nS = "N/A";

            sb.Append(
             $"Name: {Name, -14}\nStar Name: {HostName, -14}\n");
            sb.Append(
             $"Discovery Method: {DiscMethod, -14}\n");
            sb.Append(
             $"Discovery Year: ");
            sb.Append(
             $"{(DiscYear.HasValue ? DiscYear.ToString() : nS), -14}\n");
            sb.Append(
             $"Orbital Period (Days): ");
            sb.Append(
             $"{(OrbPeriod.HasValue ? OrbPeriod.ToString() : nS), -14}\n");
            sb.Append(
             $"Radius (vs Earth): ");
            sb.Append(
             $"{(Radius.HasValue ? Radius.ToString() : nS), -14}\n");
            sb.Append(
             $"Mass (vs Earth): ");
            sb.Append(
             $"{(Mass.HasValue ? Mass.ToString() : nS), -14}\n");
            sb.Append(
             $"Eq. Temperature (Kelvin): ");
            sb.Append(
             $"{(EqTemp.HasValue ? EqTemp.ToString() : nS), -14}\n");

            return sb.ToString();
        }

    }
}