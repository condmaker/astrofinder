using System;

namespace Astrofinder
{
    /// <summary>
    /// Class responsible for storing data from a Star.
    /// </summary>
    public class Star : IEquatable<Star>
    {
        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Names.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByName = 
            delegate (Star s1, Star s2)
        {
            return String.Compare(s1.Name, s2.Name);
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Temperature.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByTemperature = 
            delegate (Star s1, Star s2)
        {
            return s1?.Temperature?.CompareTo(s2.Temperature) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Radius.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByRadius = 
            delegate (Star s1, Star s2)
        {
            return s1?.Radius?.CompareTo(s2.Radius) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Mass.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByMass = 
            delegate (Star s1, Star s2)
        {
            return s1?.Mass?.CompareTo(s2.Mass) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Age.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByAge = 
            delegate (Star s1, Star s2)
        {
            return s1?.Age?.CompareTo(s2.Age) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Rotation Velocity.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByRotVelocity = 
            delegate (Star s1, Star s2)
        {
            return s1?.RotVelocity?.CompareTo(s2.RotVelocity) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Rotation Period.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareByRotPeriod = 
            delegate (Star s1, Star s2)
        {
            return s1?.RotPeriod?.CompareTo(s2.RotPeriod) ?? -1;
        };

        /// <summary>
        /// Compares two specified Star objetcts and returns an integer
        /// that indicates their relative position in the sort order,
        /// based by their Distance to the Sun.
        /// </summary>
        /// <param name="s1">The first Star to compare.</param>
        /// <param name="s2">The second Star to compare.</param>
        /// <returns>A signed integer that indicates the relative values of x 
        /// and y. Less than 0 if <paramref name="s1"> is less than
        /// <paramref name="s2">, 0 if <paramref name="s1"> equals 
        /// <paramref name="s2">, and greater than 0 if <paramref name="s1">
        /// is greater than <paramref name="s2">.</returns>
        public static Comparison<Star> CompareBySunDistance = 
            delegate (Star s1, Star s2)
        {
            return s1?.SunDistance?.CompareTo(s2.SunDistance) ?? -1;
        };


        /// <summary>
        /// Star's name. Derived from hostname column.
        /// </summary>
        /// <value>Star's name.</value>
        public string Name { get; private set; }      

        /// <summary>
        /// Star's effective temperature. Derived from st_teff column.
        /// </summary>
        /// <value>Star's effective temperature (in Kelvin).</value>
        public float? Temperature { get; private set; }
        
        /// <summary>
        /// Star's age. Derived from st_age column.
        /// </summary>
        /// <value>Star's age (in Giga-Years).</value>
        public float? Age { get; private set; }

        /// <summary>
        /// Star's rotation velocity. Derived from st_vsin column.
        /// </summary>
        /// <value>Star's rotation velocity (in km/s).</value>
        public float? RotVelocity { get; private set; }

        /// <summary>
        /// Star's rotation period. Derived from st_rotp column.
        /// </summary>
        /// <value>Star's rotation period (in days).</value>
        public float? RotPeriod { get; private set; }

        /// <summary>
        /// Star's radius relative to the Sun. Derived from st_rad column.
        /// </summary>
        /// <value>Star's radius (relative to the Sun).</value>
        public float? Radius { get; private set; }

        /// <summary>
        /// Star's mass relative to the Sun. Derived from st_mass column.
        /// </summary>
        /// <value>Star's mass (relative to the Sun).</value>
        public float? Mass { get; private set; }

        /// <summary>
        /// Star's distance to the Sun. Derived from sy_dist column.
        /// </summary>
        /// <value>Star's distance to the Sun (In Parsecs).</value>
        public float? SunDistance { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string OrbitingPlanets { get; private set; }

        /// <summary>
        /// Determines whether the specified Star is equal to the current 
        /// Star.
        /// </summary>
        /// <param name="other">The Star to compare with the current 
        /// Star.</param>
        /// <returns><c>true</c> if the specified Star is equal to the 
        /// current Star; otherwise <c>false</c>.</returns>
        public bool Equals(Star other)
        {
            return this.Name == other.Name; 
        }
    }
}